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
using GenioMVC.ViewModels.Cntry;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL AJF INCLUDE_CONTROLLER CNTRY]/

namespace GenioMVC.Controllers
{
	public partial class CntryController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_F_CNTRY_CANCEL = new("COUNTRY64133", "F_cntry_Cancel", "Cntry") { vueRouteName = "form-F_CNTRY", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_F_CNTRY_SHOW = new("COUNTRY64133", "F_cntry_Show", "Cntry") { vueRouteName = "form-F_CNTRY", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_F_CNTRY_NEW = new("COUNTRY64133", "F_cntry_New", "Cntry") { vueRouteName = "form-F_CNTRY", mode = "NEW" };
		private static readonly NavigationLocation ACTION_F_CNTRY_EDIT = new("COUNTRY64133", "F_cntry_Edit", "Cntry") { vueRouteName = "form-F_CNTRY", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_F_CNTRY_DUPLICATE = new("COUNTRY64133", "F_cntry_Duplicate", "Cntry") { vueRouteName = "form-F_CNTRY", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_F_CNTRY_DELETE = new("COUNTRY64133", "F_cntry_Delete", "Cntry") { vueRouteName = "form-F_CNTRY", mode = "DELETE" };

		#endregion

		#region F_cntry private

		private void FormHistoryLimits_F_cntry()
		{

		}

		#endregion

		#region F_cntry_Show

// USE /[MANUAL AJF CONTROLLER_SHOW F_CNTRY]/

		[HttpPost]
		public ActionResult F_cntry_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new F_cntry_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "F_cntry_Show_GET",
				AreaName = "cntry",
				Location = ACTION_F_CNTRY_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_cntry();
// USE /[MANUAL AJF BEFORE_LOAD_SHOW F_CNTRY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_SHOW F_CNTRY]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region F_cntry_New

// USE /[MANUAL AJF CONTROLLER_NEW_GET F_CNTRY]/
		[HttpPost]
		public ActionResult F_cntry_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new F_cntry_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "F_cntry_New_GET",
				AreaName = "cntry",
				FormName = "F_CNTRY",
				Location = ACTION_F_CNTRY_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_F_cntry();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_LOAD_NEW F_CNTRY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_NEW F_CNTRY]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Cntry/F_cntry_New
// USE /[MANUAL AJF CONTROLLER_NEW_POST F_CNTRY]/
		[HttpPost]
		public ActionResult F_cntry_New([FromBody]F_cntry_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "F_cntry_New",
				ViewName = "F_cntry",
				AreaName = "cntry",
				Location = ACTION_F_CNTRY_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_SAVE_NEW F_CNTRY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_SAVE_NEW F_CNTRY]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_LOAD_NEW_EX F_CNTRY]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_NEW_EX F_CNTRY]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region F_cntry_Edit

// USE /[MANUAL AJF CONTROLLER_EDIT_GET F_CNTRY]/
		[HttpPost]
		public ActionResult F_cntry_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new F_cntry_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "F_cntry_Edit_GET",
				AreaName = "cntry",
				FormName = "F_CNTRY",
				Location = ACTION_F_CNTRY_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_cntry();
// USE /[MANUAL AJF BEFORE_LOAD_EDIT F_CNTRY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_EDIT F_CNTRY]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Cntry/F_cntry_Edit
// USE /[MANUAL AJF CONTROLLER_EDIT_POST F_CNTRY]/
		[HttpPost]
		public ActionResult F_cntry_Edit([FromBody]F_cntry_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "F_cntry_Edit",
				ViewName = "F_cntry",
				AreaName = "cntry",
				Location = ACTION_F_CNTRY_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_SAVE_EDIT F_CNTRY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_SAVE_EDIT F_CNTRY]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_LOAD_EDIT_EX F_CNTRY]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_EDIT_EX F_CNTRY]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region F_cntry_Delete

// USE /[MANUAL AJF CONTROLLER_DELETE_GET F_CNTRY]/
		[HttpPost]
		public ActionResult F_cntry_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new F_cntry_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "F_cntry_Delete_GET",
				AreaName = "cntry",
				FormName = "F_CNTRY",
				Location = ACTION_F_CNTRY_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_cntry();
// USE /[MANUAL AJF BEFORE_LOAD_DELETE F_CNTRY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_DELETE F_CNTRY]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Cntry/F_cntry_Delete
// USE /[MANUAL AJF CONTROLLER_DELETE_POST F_CNTRY]/
		[HttpPost]
		public ActionResult F_cntry_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new F_cntry_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "F_cntry_Delete",
				ViewName = "F_cntry",
				AreaName = "cntry",
				Location = ACTION_F_CNTRY_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_DESTROY_DELETE F_CNTRY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_DESTROY_DELETE F_CNTRY]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult F_cntry_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("F_CNTRY");
		}

		#endregion

		#region F_cntry_Duplicate

// USE /[MANUAL AJF CONTROLLER_DUPLICATE_GET F_CNTRY]/

		[HttpPost]
		public ActionResult F_cntry_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new F_cntry_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "F_cntry_Duplicate_GET",
				AreaName = "cntry",
				FormName = "F_CNTRY",
				Location = ACTION_F_CNTRY_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_LOAD_DUPLICATE F_CNTRY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_DUPLICATE F_CNTRY]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Cntry/F_cntry_Duplicate
// USE /[MANUAL AJF CONTROLLER_DUPLICATE_POST F_CNTRY]/
		[HttpPost]
		public ActionResult F_cntry_Duplicate([FromBody]F_cntry_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "F_cntry_Duplicate",
				ViewName = "F_cntry",
				AreaName = "cntry",
				Location = ACTION_F_CNTRY_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_SAVE_DUPLICATE F_CNTRY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_SAVE_DUPLICATE F_CNTRY]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_LOAD_DUPLICATE_EX F_CNTRY]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_DUPLICATE_EX F_CNTRY]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region F_cntry_Cancel

		//
		// GET: /Cntry/F_cntry_Cancel
// USE /[MANUAL AJF CONTROLLER_CANCEL_GET F_CNTRY]/
		public ActionResult F_cntry_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Cntry(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("cntry");

// USE /[MANUAL AJF BEFORE_CANCEL F_CNTRY]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL AJF AFTER_CANCEL F_CNTRY]/

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

				Navigation.SetValue("ForcePrimaryRead_cntry", "true", true);
			}

			Navigation.ClearValue("cntry");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion



		// POST: /Cntry/F_cntry_SaveEdit
		[HttpPost]
		public ActionResult F_cntry_SaveEdit([FromBody] F_cntry_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "F_cntry_SaveEdit",
				ViewName = "F_cntry",
				AreaName = "cntry",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_APPLY_EDIT F_CNTRY]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_APPLY_EDIT F_CNTRY]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class F_cntryDocumValidateTickets : RequestDocumValidateTickets
		{
			public F_cntry_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsF_cntry([FromBody] F_cntryDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return base.UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
