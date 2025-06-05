using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

using CSGenio.business;
using CSGenio.core.persistence;
using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.reporting;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioMVC.Resources;
using GenioMVC.ViewModels;
using GenioMVC.ViewModels.Contr;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL AJF INCLUDE_CONTROLLER CONTR]/

namespace GenioMVC.Controllers
{
	public partial class ContrController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_F_CNTRCT_CANCEL = new("CONTRACT36364", "F_cntrct_Cancel", "Contr") { vueRouteName = "form-F_CNTRCT", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_F_CNTRCT_SHOW = new("CONTRACT36364", "F_cntrct_Show", "Contr") { vueRouteName = "form-F_CNTRCT", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_F_CNTRCT_NEW = new("CONTRACT36364", "F_cntrct_New", "Contr") { vueRouteName = "form-F_CNTRCT", mode = "NEW" };
		private static readonly NavigationLocation ACTION_F_CNTRCT_EDIT = new("CONTRACT36364", "F_cntrct_Edit", "Contr") { vueRouteName = "form-F_CNTRCT", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_F_CNTRCT_DUPLICATE = new("CONTRACT36364", "F_cntrct_Duplicate", "Contr") { vueRouteName = "form-F_CNTRCT", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_F_CNTRCT_DELETE = new("CONTRACT36364", "F_cntrct_Delete", "Contr") { vueRouteName = "form-F_CNTRCT", mode = "DELETE" };

		#endregion

		#region F_cntrct private

		private void FormHistoryLimits_F_cntrct()
		{

		}

		#endregion

		#region F_cntrct_Show

// USE /[MANUAL AJF CONTROLLER_SHOW F_CNTRCT]/

		[HttpPost]
		public ActionResult F_cntrct_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new F_cntrct_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "F_cntrct_Show_GET",
				AreaName = "contr",
				Location = ACTION_F_CNTRCT_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_cntrct();
// USE /[MANUAL AJF BEFORE_LOAD_SHOW F_CNTRCT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_SHOW F_CNTRCT]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region F_cntrct_New

// USE /[MANUAL AJF CONTROLLER_NEW_GET F_CNTRCT]/
		[HttpPost]
		public ActionResult F_cntrct_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new F_cntrct_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "F_cntrct_New_GET",
				AreaName = "contr",
				FormName = "F_CNTRCT",
				Location = ACTION_F_CNTRCT_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_F_cntrct();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_LOAD_NEW F_CNTRCT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_NEW F_CNTRCT]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Contr/F_cntrct_New
// USE /[MANUAL AJF CONTROLLER_NEW_POST F_CNTRCT]/
		[HttpPost]
		public ActionResult F_cntrct_New([FromBody]F_cntrct_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "F_cntrct_New",
				ViewName = "F_cntrct",
				AreaName = "contr",
				Location = ACTION_F_CNTRCT_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_SAVE_NEW F_CNTRCT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_SAVE_NEW F_CNTRCT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_LOAD_NEW_EX F_CNTRCT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_NEW_EX F_CNTRCT]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region F_cntrct_Edit

// USE /[MANUAL AJF CONTROLLER_EDIT_GET F_CNTRCT]/
		[HttpPost]
		public ActionResult F_cntrct_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new F_cntrct_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "F_cntrct_Edit_GET",
				AreaName = "contr",
				FormName = "F_CNTRCT",
				Location = ACTION_F_CNTRCT_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_cntrct();
// USE /[MANUAL AJF BEFORE_LOAD_EDIT F_CNTRCT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_EDIT F_CNTRCT]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Contr/F_cntrct_Edit
// USE /[MANUAL AJF CONTROLLER_EDIT_POST F_CNTRCT]/
		[HttpPost]
		public ActionResult F_cntrct_Edit([FromBody]F_cntrct_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "F_cntrct_Edit",
				ViewName = "F_cntrct",
				AreaName = "contr",
				Location = ACTION_F_CNTRCT_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_SAVE_EDIT F_CNTRCT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_SAVE_EDIT F_CNTRCT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_LOAD_EDIT_EX F_CNTRCT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_EDIT_EX F_CNTRCT]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region F_cntrct_Delete

// USE /[MANUAL AJF CONTROLLER_DELETE_GET F_CNTRCT]/
		[HttpPost]
		public ActionResult F_cntrct_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new F_cntrct_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "F_cntrct_Delete_GET",
				AreaName = "contr",
				FormName = "F_CNTRCT",
				Location = ACTION_F_CNTRCT_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_cntrct();
// USE /[MANUAL AJF BEFORE_LOAD_DELETE F_CNTRCT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_DELETE F_CNTRCT]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Contr/F_cntrct_Delete
// USE /[MANUAL AJF CONTROLLER_DELETE_POST F_CNTRCT]/
		[HttpPost]
		public ActionResult F_cntrct_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new F_cntrct_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "F_cntrct_Delete",
				ViewName = "F_cntrct",
				AreaName = "contr",
				Location = ACTION_F_CNTRCT_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_DESTROY_DELETE F_CNTRCT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_DESTROY_DELETE F_CNTRCT]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult F_cntrct_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("F_CNTRCT");
		}

		#endregion

		#region F_cntrct_Duplicate

// USE /[MANUAL AJF CONTROLLER_DUPLICATE_GET F_CNTRCT]/

		[HttpPost]
		public ActionResult F_cntrct_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new F_cntrct_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "F_cntrct_Duplicate_GET",
				AreaName = "contr",
				FormName = "F_CNTRCT",
				Location = ACTION_F_CNTRCT_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_LOAD_DUPLICATE F_CNTRCT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_DUPLICATE F_CNTRCT]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Contr/F_cntrct_Duplicate
// USE /[MANUAL AJF CONTROLLER_DUPLICATE_POST F_CNTRCT]/
		[HttpPost]
		public ActionResult F_cntrct_Duplicate([FromBody]F_cntrct_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "F_cntrct_Duplicate",
				ViewName = "F_cntrct",
				AreaName = "contr",
				Location = ACTION_F_CNTRCT_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_SAVE_DUPLICATE F_CNTRCT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_SAVE_DUPLICATE F_CNTRCT]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_LOAD_DUPLICATE_EX F_CNTRCT]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_DUPLICATE_EX F_CNTRCT]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region F_cntrct_Cancel

		//
		// GET: /Contr/F_cntrct_Cancel
// USE /[MANUAL AJF CONTROLLER_CANCEL_GET F_CNTRCT]/
		public ActionResult F_cntrct_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Contr(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("contr");

// USE /[MANUAL AJF BEFORE_CANCEL F_CNTRCT]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL AJF AFTER_CANCEL F_CNTRCT]/

				}
				catch (Exception e)
				{
					sp.rollbackTransaction();
					sp.closeConnection();

					var exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
					if (e is GenioException && (e as GenioException).UserMessage != null)
						exceptionUserMessage = Translations.Get((e as GenioException).UserMessage, UserContext.Current.User.Language);
					return JsonERROR(exceptionUserMessage);
				}

				Navigation.SetValue("ForcePrimaryRead_contr", "true", true);
			}

			Navigation.ClearValue("contr");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class F_cntrct_PlayrValNameModel : RequestLookupModel
		{
			public F_cntrct_ViewModel Model { get; set; }
		}

		//
		// GET: /Contr/F_cntrct_PlayrValName
		// POST: /Contr/F_cntrct_PlayrValName
		[ActionName("F_cntrct_PlayrValName")]
		public ActionResult F_cntrct_PlayrValName([FromBody] F_cntrct_PlayrValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_playr")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_playr");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Contr parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			F_cntrct_PlayrValName_ViewModel model = new(UserContext.Current, parentCtx);

			// Table configuration load options
			CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions tableConfigOptions = new CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions();

			// Determine which table configuration to use and load it
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = TableUiSettings.Load(
				UserContext.Current.PersistentSupport,
				model.Uuid,
				UserContext.Current.User,
				tableConfigOptions
			).DetermineTableConfig(
				requestModel?.TableConfiguration,
				requestModel?.UserTableConfigName,
				(bool)requestModel?.LoadDefaultView,
				tableConfigOptions
			);

			// Determine rows per page
			tableConfig.RowsPerPage = CSGenio.framework.TableConfiguration.TableConfigurationHelpers.DetermineRowsPerPage(tableConfig.RowsPerPage, perPage, rowsPerPageOptionsString);

			// Determine which columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class F_cntrct_ClubValNameModel : RequestLookupModel
		{
			public F_cntrct_ViewModel Model { get; set; }
		}

		//
		// GET: /Contr/F_cntrct_ClubValName
		// POST: /Contr/F_cntrct_ClubValName
		[ActionName("F_cntrct_ClubValName")]
		public ActionResult F_cntrct_ClubValName([FromBody] F_cntrct_ClubValNameModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_club")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_club");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Contr parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			F_cntrct_ClubValName_ViewModel model = new(UserContext.Current, parentCtx);

			// Table configuration load options
			CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions tableConfigOptions = new CSGenio.framework.TableConfiguration.TableConfigurationLoadOptions();

			// Determine which table configuration to use and load it
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = TableUiSettings.Load(
				UserContext.Current.PersistentSupport,
				model.Uuid,
				UserContext.Current.User,
				tableConfigOptions
			).DetermineTableConfig(
				requestModel?.TableConfiguration,
				requestModel?.UserTableConfigName,
				(bool)requestModel?.LoadDefaultView,
				tableConfigOptions
			);

			// Determine rows per page
			tableConfig.RowsPerPage = CSGenio.framework.TableConfiguration.TableConfigurationHelpers.DetermineRowsPerPage(tableConfig.RowsPerPage, perPage, rowsPerPageOptionsString);

			// Determine which columns have totalizers
			tableConfig.TotalizerColumns = requestModel.TotalizerColumns;

			// For tables with multiple selection enabled, determine currently selected rows
			tableConfig.SelectedRows = requestModel.SelectedRows;

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}


		// POST: /Contr/F_cntrct_SaveEdit
		[HttpPost]
		public ActionResult F_cntrct_SaveEdit([FromBody] F_cntrct_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "F_cntrct_SaveEdit",
				ViewName = "F_cntrct",
				AreaName = "contr",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_APPLY_EDIT F_CNTRCT]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_APPLY_EDIT F_CNTRCT]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class F_cntrctDocumValidateTickets : RequestDocumValidateTickets
		{
			public F_cntrct_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsF_cntrct([FromBody] F_cntrctDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return base.UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
