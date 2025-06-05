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
using GenioMVC.ViewModels.Playr;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL AJF INCLUDE_CONTROLLER PLAYR]/

namespace GenioMVC.Controllers
{
	public partial class PlayrController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_F_PLAYER_CANCEL = new("PLAYER57424", "F_player_Cancel", "Playr") { vueRouteName = "form-F_PLAYER", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_F_PLAYER_SHOW = new("PLAYER57424", "F_player_Show", "Playr") { vueRouteName = "form-F_PLAYER", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_F_PLAYER_NEW = new("PLAYER57424", "F_player_New", "Playr") { vueRouteName = "form-F_PLAYER", mode = "NEW" };
		private static readonly NavigationLocation ACTION_F_PLAYER_EDIT = new("PLAYER57424", "F_player_Edit", "Playr") { vueRouteName = "form-F_PLAYER", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_F_PLAYER_DUPLICATE = new("PLAYER57424", "F_player_Duplicate", "Playr") { vueRouteName = "form-F_PLAYER", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_F_PLAYER_DELETE = new("PLAYER57424", "F_player_Delete", "Playr") { vueRouteName = "form-F_PLAYER", mode = "DELETE" };

		#endregion

		#region F_player private

		private void FormHistoryLimits_F_player()
		{

		}

		#endregion

		#region F_player_Show

// USE /[MANUAL AJF CONTROLLER_SHOW F_PLAYER]/

		[HttpPost]
		public ActionResult F_player_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new F_player_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "F_player_Show_GET",
				AreaName = "playr",
				Location = ACTION_F_PLAYER_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_player();
// USE /[MANUAL AJF BEFORE_LOAD_SHOW F_PLAYER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_SHOW F_PLAYER]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region F_player_New

// USE /[MANUAL AJF CONTROLLER_NEW_GET F_PLAYER]/
		[HttpPost]
		public ActionResult F_player_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new F_player_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "F_player_New_GET",
				AreaName = "playr",
				FormName = "F_PLAYER",
				Location = ACTION_F_PLAYER_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_F_player();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_LOAD_NEW F_PLAYER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_NEW F_PLAYER]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Playr/F_player_New
// USE /[MANUAL AJF CONTROLLER_NEW_POST F_PLAYER]/
		[HttpPost]
		public ActionResult F_player_New([FromBody]F_player_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "F_player_New",
				ViewName = "F_player",
				AreaName = "playr",
				Location = ACTION_F_PLAYER_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_SAVE_NEW F_PLAYER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_SAVE_NEW F_PLAYER]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_LOAD_NEW_EX F_PLAYER]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_NEW_EX F_PLAYER]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region F_player_Edit

// USE /[MANUAL AJF CONTROLLER_EDIT_GET F_PLAYER]/
		[HttpPost]
		public ActionResult F_player_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new F_player_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "F_player_Edit_GET",
				AreaName = "playr",
				FormName = "F_PLAYER",
				Location = ACTION_F_PLAYER_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_player();
// USE /[MANUAL AJF BEFORE_LOAD_EDIT F_PLAYER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_EDIT F_PLAYER]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Playr/F_player_Edit
// USE /[MANUAL AJF CONTROLLER_EDIT_POST F_PLAYER]/
		[HttpPost]
		public ActionResult F_player_Edit([FromBody]F_player_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "F_player_Edit",
				ViewName = "F_player",
				AreaName = "playr",
				Location = ACTION_F_PLAYER_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_SAVE_EDIT F_PLAYER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_SAVE_EDIT F_PLAYER]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_LOAD_EDIT_EX F_PLAYER]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_EDIT_EX F_PLAYER]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region F_player_Delete

// USE /[MANUAL AJF CONTROLLER_DELETE_GET F_PLAYER]/
		[HttpPost]
		public ActionResult F_player_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new F_player_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "F_player_Delete_GET",
				AreaName = "playr",
				FormName = "F_PLAYER",
				Location = ACTION_F_PLAYER_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_player();
// USE /[MANUAL AJF BEFORE_LOAD_DELETE F_PLAYER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_DELETE F_PLAYER]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Playr/F_player_Delete
// USE /[MANUAL AJF CONTROLLER_DELETE_POST F_PLAYER]/
		[HttpPost]
		public ActionResult F_player_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new F_player_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "F_player_Delete",
				ViewName = "F_player",
				AreaName = "playr",
				Location = ACTION_F_PLAYER_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_DESTROY_DELETE F_PLAYER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_DESTROY_DELETE F_PLAYER]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult F_player_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("F_PLAYER");
		}

		#endregion

		#region F_player_Duplicate

// USE /[MANUAL AJF CONTROLLER_DUPLICATE_GET F_PLAYER]/

		[HttpPost]
		public ActionResult F_player_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new F_player_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "F_player_Duplicate_GET",
				AreaName = "playr",
				FormName = "F_PLAYER",
				Location = ACTION_F_PLAYER_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_LOAD_DUPLICATE F_PLAYER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_DUPLICATE F_PLAYER]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Playr/F_player_Duplicate
// USE /[MANUAL AJF CONTROLLER_DUPLICATE_POST F_PLAYER]/
		[HttpPost]
		public ActionResult F_player_Duplicate([FromBody]F_player_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "F_player_Duplicate",
				ViewName = "F_player",
				AreaName = "playr",
				Location = ACTION_F_PLAYER_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_SAVE_DUPLICATE F_PLAYER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_SAVE_DUPLICATE F_PLAYER]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_LOAD_DUPLICATE_EX F_PLAYER]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_DUPLICATE_EX F_PLAYER]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region F_player_Cancel

		//
		// GET: /Playr/F_player_Cancel
// USE /[MANUAL AJF CONTROLLER_CANCEL_GET F_PLAYER]/
		public ActionResult F_player_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Playr(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("playr");

// USE /[MANUAL AJF BEFORE_CANCEL F_PLAYER]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL AJF AFTER_CANCEL F_PLAYER]/

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

				Navigation.SetValue("ForcePrimaryRead_playr", "true", true);
			}

			Navigation.ClearValue("playr");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class F_player_ValAgtinfoModel : RequestLookupModel
		{
			public F_player_ViewModel Model { get; set; }
		}

		//
		// GET: /Playr/F_player_ValAgtinfo
		// POST: /Playr/F_player_ValAgtinfo
		[ActionName("F_player_ValAgtinfo")]
		public ActionResult F_player_ValAgtinfo([FromBody] F_player_ValAgtinfoModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			int perPage = CSGenio.framework.Configuration.NrRegDBedit;
			string rowsPerPageOptionsString = "";

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_agent")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_agent");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			var requestValues = new NameValueCollection();
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Playr parentCtx = requestModel.Model == null ? null : new(UserContext.Current);
			requestModel.Model?.Init(UserContext.Current);
			requestModel.Model?.MapToModel(parentCtx);
			F_player_ValAgtinfo_ViewModel model = new(UserContext.Current, parentCtx);

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
			// Verificar se o user clicou to exportar os dados da Qlisting
			if (requestValues["ExportList"] != null && Convert.ToBoolean(requestValues["ExportList"]) && requestValues["ExportType"] != null)
			{
				string file = "F_player_ValAgtinfo_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + "." + requestValues["ExportType"];
				ListingMVC<CSGenioAagent> listing = null;
				CriteriaSet conditions = null;
				List<CSGenio.framework.Exports.QColumn> columns = null;
				model.LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, Request.IsAjaxRequest());
				byte[] fileBytes = null;

// USE /[MANUAL AJF OVERRQEXPORT F_PLAYER_PSEUDAGTINFO]/
				fileBytes = new CSGenio.framework.Exports(UserContext.Current.User).ExportList(listing, conditions, columns, requestValues["ExportType"], Resources.Resources.AGENT_INFO01863);

				QCache.Instance.ExportFiles.Put(file, fileBytes);
				return Json(GetJsonForDownloadExportFile(file, requestValues["ExportType"]));
			}

			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}


		// POST: /Playr/F_player_SaveEdit
		[HttpPost]
		public ActionResult F_player_SaveEdit([FromBody] F_player_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "F_player_SaveEdit",
				ViewName = "F_player",
				AreaName = "playr",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_APPLY_EDIT F_PLAYER]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_APPLY_EDIT F_PLAYER]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class F_playerDocumValidateTickets : RequestDocumValidateTickets
		{
			public F_player_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsF_player([FromBody] F_playerDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return base.UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
