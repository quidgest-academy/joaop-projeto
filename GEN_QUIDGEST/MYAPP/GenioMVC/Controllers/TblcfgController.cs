using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using Microsoft.AspNetCore.Mvc;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.Controllers.Tblcfg
{
	public class TblcfgController : ControllerBase
	{
        public TblcfgController(UserContextService userContextService) : base(userContextService)
        {
        }

		public ActionResult Index()
		{
			return Json(new { Success = true });
		}

		public class RequestConfigModel
		{
            public string Uuid { get; set; }
            public string ConfigName { get; set; }
        }

        public class RequestConfigSelectedModel : RequestConfigModel
        {
            public bool IsSelected { get; set; }
        }

        public class RequestConfigSaveModel : RequestConfigSelectedModel
        {
            public string? Data { get; set; }
        }

        public class RequestConfigRenameModel : RequestConfigSelectedModel
        {
            public string? RenameFromName { get; set; }
        }

        public class RequestConfigCopyModel : RequestConfigSelectedModel
        {
            public string? CopyFromName { get; set; }
        }

        [HttpPost]
		public ActionResult SaveConfig([FromBody] RequestConfigSaveModel requestModel)
		{
			// Don't allow changes in maintenance mode
			if(Maintenance.Current.IsActive)
                return Json(new { Success = false, Message = Resources.Resources.O_SISTEMA_ENCONTRA_S37912 });

            var uuid = requestModel.Uuid;
			var configName = requestModel.ConfigName;
			var isSelected = requestModel.IsSelected;
			var data = requestModel.Data;

			User user = UserContext.Current.User;
			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

			//Get saved configuration
			CSGenioAtblcfg userTableConfig = CSGenioAtblcfg.searchList(sp, user, CriteriaSet.And()
				.Equal(CSGenioAtblcfg.FldCodpsw, user.Codpsw)
				.Equal(CSGenioAtblcfg.FldUuid, uuid)
				.Equal(CSGenioAtblcfg.FldName, configName))
				.FirstOrDefault();

			//If record doesn't exist, create new record
			if (userTableConfig == null)
			{
                userTableConfig = new CSGenioAtblcfg(user);
				sp.openConnection();
                userTableConfig.insert(sp);
				sp.closeConnection();

                userTableConfig.ValCodpsw = user.Codpsw;
                userTableConfig.ValUuid = uuid;
                userTableConfig.ValName = configName;
                userTableConfig.ValConfig = "";
			}

            //Store configuration data
            userTableConfig.ValConfig = data;

			//Set to current version
			userTableConfig.ValUsrsetv = Configuration.UserSettingsVersion;

			try
			{
				//Save record
				sp.openTransaction();
                userTableConfig.change(sp, (CriteriaSet)null);
				sp.closeTransaction();

				CSGenioAtblcfgsel userTableConfigSelectedInfo = CSGenioAtblcfgsel.searchList(sp, user, CriteriaSet.And()
					.Equal(CSGenioAtblcfgsel.FldCodpsw, user.Codpsw)
					.Equal(CSGenioAtblcfgsel.FldUuid, uuid))
					.FirstOrDefault();

				//If record doesn't exist, create it
				if (userTableConfigSelectedInfo == null)
				{
					userTableConfigSelectedInfo = new CSGenioAtblcfgsel(user);
					sp.openConnection();
					userTableConfigSelectedInfo.insert(sp);
					sp.closeConnection();

					userTableConfigSelectedInfo.ValCodpsw = user.Codpsw;
					userTableConfigSelectedInfo.ValUuid = uuid;
					userTableConfigSelectedInfo.ValCodtblcfg = userTableConfig.ValCodtblcfg;

					//Save record
					sp.openTransaction();
					userTableConfigSelectedInfo.change(sp, (CriteriaSet)null);
					sp.closeTransaction();
				}
				// If this record is set as the default record
				// add the corresponding record that specifies the default
				else if (isSelected)
				{
					userTableConfigSelectedInfo.ValCodtblcfg = userTableConfig.ValCodtblcfg;

					//Save record
					sp.openTransaction();
					userTableConfigSelectedInfo.change(sp, (CriteriaSet)null);
					sp.closeTransaction();
				}

				//Clear cache
				TableUiSettings.Invalidate(uuid, user);

				return Json(new { Success = true });
			}
			catch (Exception e)
			{
				sp.rollbackTransaction();
				sp.closeConnection();

				return Json(new { Success = false, e.Message });
			}
		}

		[HttpPost]
        public ActionResult SelectConfig([FromBody] RequestConfigModel requestModel)
		{
            // Don't allow changes in maintenance mode
            if (Maintenance.Current.IsActive)
                return Json(new { Success = false, Message = Resources.Resources.O_SISTEMA_ENCONTRA_S37912 });

            var uuid = requestModel.Uuid;
            var configName = requestModel.ConfigName;

			User user = UserContext.Current.User;
			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

			//If clearing what is set as the default configuration
			if (string.IsNullOrEmpty(configName))
			{
				//Get record of what view is set as default
				CSGenioAtblcfgsel userTableConfigSelectedInfo = CSGenioAtblcfgsel.searchList(sp, user, CriteriaSet.And()
					.Equal(CSGenioAtblcfgsel.FldCodpsw, user.Codpsw)
					.Equal(CSGenioAtblcfgsel.FldUuid, uuid))
					.FirstOrDefault();

				//If record exists, delete it
				if (userTableConfigSelectedInfo != null)
				{
					sp.openConnection();
					userTableConfigSelectedInfo.delete(sp);
					sp.closeConnection();

					//Clear cache
					TableUiSettings.Invalidate(uuid, user);
				}

				return JsonOK();
			}

			//Get saved configuration
			CSGenioAtblcfg userTableConfig = CSGenioAtblcfg.searchList(sp, user, CriteriaSet.And()
				.Equal(CSGenioAtblcfg.FldCodpsw, user.Codpsw)
				.Equal(CSGenioAtblcfg.FldUuid, uuid)
				.Equal(CSGenioAtblcfg.FldName, configName))
				.FirstOrDefault();

			//If record doesn't exist
			if (userTableConfig == null)
				return Json(new { Success = false });

			try
			{
				//Get record of what view is selected
				CSGenioAtblcfgsel userTableConfigSelectedInfo = CSGenioAtblcfgsel.searchList(sp, user, CriteriaSet.And()
					.Equal(CSGenioAtblcfgsel.FldCodpsw, user.Codpsw)
					.Equal(CSGenioAtblcfgsel.FldUuid, uuid))
					.FirstOrDefault();

				//If record doesn't exist, create it
				if (userTableConfigSelectedInfo == null)
				{
					userTableConfigSelectedInfo = new CSGenioAtblcfgsel(user);
					sp.openConnection();
					userTableConfigSelectedInfo.insert(sp);
					sp.closeConnection();

					userTableConfigSelectedInfo.ValCodpsw = user.Codpsw;
					userTableConfigSelectedInfo.ValUuid = uuid;
				}

				userTableConfigSelectedInfo.ValCodtblcfg = userTableConfig.ValCodtblcfg;

				//Save record
				sp.openTransaction();
				userTableConfigSelectedInfo.change(sp, (CriteriaSet)null);
				sp.closeTransaction();

				//Clear cache
				TableUiSettings.Invalidate(uuid, user);

				return Json(new { Success = true });
			}
			catch (Exception e)
			{
				sp.rollbackTransaction();
				sp.closeConnection();

				return Json(new { Success = false, e.Message });
			}
		}

		[HttpPost]
		public ActionResult GetConfig([FromBody] RequestConfigModel requestModel)
		{
            var uuid = requestModel.Uuid;
            var configName = requestModel.ConfigName;

			User user = UserContext.Current.User;
			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

			//Get saved configuration
			CSGenioAtblcfg userTableConfig = CSGenioAtblcfg.searchList(sp, user, CriteriaSet.And()
				.Equal(CSGenioAtblcfg.FldCodpsw, user.Codpsw)
				.Equal(CSGenioAtblcfg.FldUuid, uuid)
				.Equal(CSGenioAtblcfg.FldName, configName))
				.FirstOrDefault();

			//If record doesn't exist
			if (userTableConfig == null)
				return Json(new { Success = false });

			return Json(new
			{
				Success = true,
				Config = userTableConfig.ValConfig,
				ConfigName = configName
			});
		}

		[HttpPost]
		public ActionResult DeleteConfig([FromBody] RequestConfigModel requestModel)
		{
            // Don't allow changes in maintenance mode
            if (Maintenance.Current.IsActive)
                return Json(new { Success = false, Message = Resources.Resources.O_SISTEMA_ENCONTRA_S37912 });

            var uuid = requestModel.Uuid;
            var configName = requestModel.ConfigName;

			User user = UserContext.Current.User;
			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

			bool deletedDefaultView = false;

			//Get saved configuration
			CSGenioAtblcfg userTableConfig = CSGenioAtblcfg.searchList(sp, user, CriteriaSet.And()
				.Equal(CSGenioAtblcfg.FldCodpsw, user.Codpsw)
				.Equal(CSGenioAtblcfg.FldUuid, uuid)
				.Equal(CSGenioAtblcfg.FldName, configName))
				.FirstOrDefault();

			//If record doesn't exist
			if (userTableConfig == null)
				return Json(new { Success = false });

			try
			{
				CSGenioAtblcfgsel userTableConfigSelectedInfo = CSGenioAtblcfgsel.searchList(sp, user, CriteriaSet.And()
					.Equal(CSGenioAtblcfgsel.FldCodpsw, user.Codpsw)
					.Equal(CSGenioAtblcfgsel.FldUuid, uuid))
					.FirstOrDefault();

				//If record exists
				if (userTableConfigSelectedInfo != null)
				{
					//If view is selected as default
					if (userTableConfigSelectedInfo.ValCodtblcfg.Equals(userTableConfig.ValCodtblcfg))
					{
						sp.openTransaction();
						userTableConfigSelectedInfo.delete(sp);
                        userTableConfig.delete(sp);
						sp.closeTransaction();
						deletedDefaultView = true;
					}
					//If view is not selected as default
					else
					{
						sp.openTransaction();
                        userTableConfig.delete(sp);
						sp.closeTransaction();
					}
				}
				//If record does not exist
				else
				{
					sp.openTransaction();
                    userTableConfig.delete(sp);
					sp.closeTransaction();
				}

				//Clear cache
				TableUiSettings.Invalidate(uuid, user);

				return Json(new
				{
					Success = true,
					DeletedDefaultView = deletedDefaultView
				});
			}
			catch (Exception e)
			{
				sp.rollbackTransaction();
				sp.closeConnection();

				return Json(new { Success = false, e.Message });
			}
		}

        [HttpPost]
        public ActionResult RenameConfig([FromBody] RequestConfigRenameModel requestModel)
        {
            User user = UserContext.Current.User;

            // Don't allow changes in maintenance mode
            if (Maintenance.Current.IsActive)
                return JsonERROR(Translations.Get("The system is under maintenance! We apologize for the inconvenience.", user.Language));

            PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

            var uuid = requestModel.Uuid;
            var configName = requestModel.ConfigName;
            var isSelected = requestModel.IsSelected;
            var renameFromName = requestModel.RenameFromName;

            //Get saved configuration
            List<CSGenioAtblcfg> userTableConfigs = CSGenioAtblcfg.searchList(sp, user, CriteriaSet.And()
                .Equal(CSGenioAtblcfg.FldCodpsw, user.Codpsw)
                .Equal(CSGenioAtblcfg.FldUuid, uuid)
				.SubSet(
                    CriteriaSet.Or()
						.Equal(CSGenioAtblcfg.FldName, renameFromName)
                        .Equal(CSGenioAtblcfg.FldName, configName)
                )
            );

			//Get saved configuration
			CSGenioAtblcfg userTableConfigToRename = userTableConfigs.Where(config => config.ValName.Equals(renameFromName)).ToList().FirstOrDefault();

            //If record to rename doesn't exist
            if (userTableConfigToRename == null)
            {
                return Json(new
                {
                    Success = false,
                    ErrorNo = 1,
                    ErrorMsg = Translations.Get("Erro ao guardar o registo.", user.Language)
                });
            }

            //Check if saved configuration with new name already exists
            CSGenioAtblcfg userTableConfigWithNewName = userTableConfigs.Where(config => config.ValName.Equals(configName)).ToList().FirstOrDefault();

            //If record already exists
            if (userTableConfigWithNewName != null)
            {
                return Json(new
                {
                    Success = false,
                    ErrorNo = 2,
                    ErrorMsg = Translations.Get("Essa vista já existe.", user.Language)
                });
            }

            //Update record
            userTableConfigToRename.ValName = configName;

            try
            {
                //Save record
                sp.openTransaction();
                userTableConfigToRename.change(sp, (CriteriaSet)null);
                sp.closeTransaction();

				CSGenioAtblcfgsel userTableConfigSelectedInfo = CSGenioAtblcfgsel.searchList(sp, user, CriteriaSet.And()
					.Equal(CSGenioAtblcfgsel.FldCodpsw, user.Codpsw)
					.Equal(CSGenioAtblcfgsel.FldUuid, uuid))
					.FirstOrDefault();

				// If this record is set as the default record
				// add / update the corresponding record that specifies the default
				if (isSelected)
				{
					sp.openTransaction();

					//If record doesn't exist, create it
					if (userTableConfigSelectedInfo == null)
					{
						userTableConfigSelectedInfo = new CSGenioAtblcfgsel(user);

						userTableConfigSelectedInfo.ValCodpsw = user.Codpsw;
						userTableConfigSelectedInfo.ValUuid = uuid;
						userTableConfigSelectedInfo.ValCodtblcfg = userTableConfigToRename.ValCodtblcfg;

						userTableConfigSelectedInfo.insert(sp);
					}

					// Update and save
					userTableConfigSelectedInfo.ValCodtblcfg = userTableConfigToRename.ValCodtblcfg;
					userTableConfigSelectedInfo.change(sp, (CriteriaSet)null);
					sp.closeTransaction();
				}
				// If this configuration is the default and is being set as not being the default
				else if (userTableConfigSelectedInfo.ValCodtblcfg.Equals(userTableConfigToRename.ValCodtblcfg))
				{
                    sp.openTransaction();
                    userTableConfigSelectedInfo.delete(sp);
                    sp.closeTransaction();
                }

                //Clear cache
                TableUiSettings.Invalidate(uuid, user);

                return Json(new
                {
                    Success = true,
                    LoadDefaultView = isSelected
                });
            }
            catch
            {
                sp.rollbackTransaction();
                sp.closeConnection();

                return Json(new { Success = false, Message = Translations.Get("Erro ao guardar o registo.", user.Language) });
            }
        }

        [HttpPost]
		public ActionResult CopyConfig([FromBody] RequestConfigCopyModel requestModel)
		{
            // Don't allow changes in maintenance mode
            if (Maintenance.Current.IsActive)
                return Json(new { Success = false, Message = Resources.Resources.O_SISTEMA_ENCONTRA_S37912 });

            var uuid = requestModel.Uuid;
            var configName = requestModel.ConfigName;
            var isSelected = requestModel.IsSelected;
            var copyFromName = requestModel.CopyFromName;

			User user = UserContext.Current.User;
			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

			//Get saved configuration
			CSGenioAtblcfg userTableConfigToCopy = CSGenioAtblcfg.searchList(sp, user, CriteriaSet.And()
				.Equal(CSGenioAtblcfg.FldCodpsw, user.Codpsw)
				.Equal(CSGenioAtblcfg.FldUuid, uuid)
				.Equal(CSGenioAtblcfg.FldName, copyFromName))
				.FirstOrDefault();

			//If record to copy doesn't exist
			if (userTableConfigToCopy == null)
			{
				return Json(new
				{
					Success = false,
					ErrorNo = 1,
					ErrorMsg = "copyFromName view does not exist"
				});
			}

			//Check for saved configuration
			CSGenioAtblcfg userTableConfig = CSGenioAtblcfg.searchList(sp, user, CriteriaSet.And()
				.Equal(CSGenioAtblcfg.FldCodpsw, user.Codpsw)
				.Equal(CSGenioAtblcfg.FldUuid, uuid)
				.Equal(CSGenioAtblcfg.FldName, configName))
				.FirstOrDefault();

			//If record already exists
			if (userTableConfig != null)
			{
				return Json(new
				{
					Success = false,
					ErrorNo = 2,
					ErrorMsg = "configName view already exists"
				});
			}

            //Create new record
            userTableConfig = new CSGenioAtblcfg(user);
			sp.openConnection();
            userTableConfig.insert(sp);
			sp.closeConnection();

            userTableConfig.ValCodpsw = user.Codpsw;
            userTableConfig.ValUuid = uuid;
            userTableConfig.ValName = configName;
            userTableConfig.ValConfig = userTableConfigToCopy.ValConfig;

			try
			{
				//Save record
				sp.openTransaction();
                userTableConfig.change(sp, (CriteriaSet)null);
				sp.closeTransaction();

				CSGenioAtblcfgsel userTableConfigSelectedInfo = CSGenioAtblcfgsel.searchList(sp, user, CriteriaSet.And()
					.Equal(CSGenioAtblcfgsel.FldCodpsw, user.Codpsw)
					.Equal(CSGenioAtblcfgsel.FldUuid, uuid))
					.FirstOrDefault();

				// If this record is set as the default record
				// add / update the corresponding record that specifies the default
				if (isSelected)
				{
					//If record doesn't exist, create it
					if (userTableConfigSelectedInfo == null)
					{
						userTableConfigSelectedInfo = new CSGenioAtblcfgsel(user);
						sp.openConnection();
						userTableConfigSelectedInfo.insert(sp);
						sp.closeConnection();

						userTableConfigSelectedInfo.ValCodpsw = user.Codpsw;
						userTableConfigSelectedInfo.ValUuid = uuid;
						userTableConfigSelectedInfo.ValCodtblcfg = userTableConfig.ValCodtblcfg;

						//Save record
						sp.openTransaction();
						userTableConfigSelectedInfo.change(sp, (CriteriaSet)null);
						sp.closeTransaction();
					}

					userTableConfigSelectedInfo.ValCodtblcfg = userTableConfig.ValCodtblcfg;

					//Save record
					sp.openTransaction();
					userTableConfigSelectedInfo.change(sp, (CriteriaSet)null);
					sp.closeTransaction();
				}

				//Clear cache
				TableUiSettings.Invalidate(uuid, user);

				return Json(new
				{
					Success = true,
					LoadDefaultView = isSelected
				});
			}
			catch (Exception e)
			{
				sp.rollbackTransaction();
				sp.closeConnection();

				return Json(new { Success = false, e.Message });
			}
		}
	}
}
