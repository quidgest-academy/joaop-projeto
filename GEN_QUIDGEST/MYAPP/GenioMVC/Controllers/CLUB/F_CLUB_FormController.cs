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
using GenioMVC.ViewModels.Club;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL AJF INCLUDE_CONTROLLER CLUB]/

namespace GenioMVC.Controllers
{
	public partial class ClubController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_F_CLUB_CANCEL = new("CLUB_NAME40175", "F_club_Cancel", "Club") { vueRouteName = "form-F_CLUB", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_F_CLUB_SHOW = new("CLUB_NAME40175", "F_club_Show", "Club") { vueRouteName = "form-F_CLUB", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_F_CLUB_NEW = new("CLUB_NAME40175", "F_club_New", "Club") { vueRouteName = "form-F_CLUB", mode = "NEW" };
		private static readonly NavigationLocation ACTION_F_CLUB_EDIT = new("CLUB_NAME40175", "F_club_Edit", "Club") { vueRouteName = "form-F_CLUB", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_F_CLUB_DUPLICATE = new("CLUB_NAME40175", "F_club_Duplicate", "Club") { vueRouteName = "form-F_CLUB", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_F_CLUB_DELETE = new("CLUB_NAME40175", "F_club_Delete", "Club") { vueRouteName = "form-F_CLUB", mode = "DELETE" };

		#endregion

		#region F_club private

		private void FormHistoryLimits_F_club()
		{

		}

		#endregion

		#region F_club_Show

// USE /[MANUAL AJF CONTROLLER_SHOW F_CLUB]/

		[HttpPost]
		public ActionResult F_club_Show_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new F_club_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "F_club_Show_GET",
				AreaName = "club",
				Location = ACTION_F_CLUB_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_club();
// USE /[MANUAL AJF BEFORE_LOAD_SHOW F_CLUB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_SHOW F_CLUB]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region F_club_New

// USE /[MANUAL AJF CONTROLLER_NEW_GET F_CLUB]/
		[HttpPost]
		public ActionResult F_club_New_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			var model = new F_club_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "F_club_New_GET",
				AreaName = "club",
				FormName = "F_CLUB",
				Location = ACTION_F_CLUB_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_F_club();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_LOAD_NEW F_CLUB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_NEW F_CLUB]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Club/F_club_New
// USE /[MANUAL AJF CONTROLLER_NEW_POST F_CLUB]/
		[HttpPost]
		public ActionResult F_club_New([FromBody]F_club_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "F_club_New",
				ViewName = "F_club",
				AreaName = "club",
				Location = ACTION_F_CLUB_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_SAVE_NEW F_CLUB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_SAVE_NEW F_CLUB]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_LOAD_NEW_EX F_CLUB]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_NEW_EX F_CLUB]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region F_club_Edit

// USE /[MANUAL AJF CONTROLLER_EDIT_GET F_CLUB]/
		[HttpPost]
		public ActionResult F_club_Edit_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new F_club_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "F_club_Edit_GET",
				AreaName = "club",
				FormName = "F_CLUB",
				Location = ACTION_F_CLUB_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_club();
// USE /[MANUAL AJF BEFORE_LOAD_EDIT F_CLUB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_EDIT F_CLUB]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Club/F_club_Edit
// USE /[MANUAL AJF CONTROLLER_EDIT_POST F_CLUB]/
		[HttpPost]
		public ActionResult F_club_Edit([FromBody]F_club_ViewModel model, [FromQuery]bool redirect)
		{
			var eventSink = new EventSink()
			{
				MethodName = "F_club_Edit",
				ViewName = "F_club",
				AreaName = "club",
				Location = ACTION_F_CLUB_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_SAVE_EDIT F_CLUB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_SAVE_EDIT F_CLUB]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_LOAD_EDIT_EX F_CLUB]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_EDIT_EX F_CLUB]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region F_club_Delete

// USE /[MANUAL AJF CONTROLLER_DELETE_GET F_CLUB]/
		[HttpPost]
		public ActionResult F_club_Delete_GET([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new F_club_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "F_club_Delete_GET",
				AreaName = "club",
				FormName = "F_CLUB",
				Location = ACTION_F_CLUB_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_F_club();
// USE /[MANUAL AJF BEFORE_LOAD_DELETE F_CLUB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_DELETE F_CLUB]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Club/F_club_Delete
// USE /[MANUAL AJF CONTROLLER_DELETE_POST F_CLUB]/
		[HttpPost]
		public ActionResult F_club_Delete([FromBody]RequestIdModel requestModel)
		{
			var id = requestModel.Id;
			var model = new F_club_ViewModel (UserContext.Current, id);
			model.MapFromModel();

			var eventSink = new EventSink()
			{
				MethodName = "F_club_Delete",
				ViewName = "F_club",
				AreaName = "club",
				Location = ACTION_F_CLUB_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_DESTROY_DELETE F_CLUB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_DESTROY_DELETE F_CLUB]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult F_club_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("F_CLUB");
		}

		#endregion

		#region F_club_Duplicate

// USE /[MANUAL AJF CONTROLLER_DUPLICATE_GET F_CLUB]/

		[HttpPost]
		public ActionResult F_club_Duplicate_GET([FromBody]RequestNewGetModel requestModel)
		{
			var id = requestModel.Id;
			var isNewLocation = requestModel.IsNewLocation;

			var model = new F_club_ViewModel(UserContext.Current);
			var eventSink = new EventSink()
			{
				MethodName = "F_club_Duplicate_GET",
				AreaName = "club",
				FormName = "F_CLUB",
				Location = ACTION_F_CLUB_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_LOAD_DUPLICATE F_CLUB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_DUPLICATE F_CLUB]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Club/F_club_Duplicate
// USE /[MANUAL AJF CONTROLLER_DUPLICATE_POST F_CLUB]/
		[HttpPost]
		public ActionResult F_club_Duplicate([FromBody]F_club_ViewModel model, [FromQuery]bool redirect = true)
		{
			var eventSink = new EventSink()
			{
				MethodName = "F_club_Duplicate",
				ViewName = "F_club",
				AreaName = "club",
				Location = ACTION_F_CLUB_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_SAVE_DUPLICATE F_CLUB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_SAVE_DUPLICATE F_CLUB]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_LOAD_DUPLICATE_EX F_CLUB]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_LOAD_DUPLICATE_EX F_CLUB]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region F_club_Cancel

		//
		// GET: /Club/F_club_Cancel
// USE /[MANUAL AJF CONTROLLER_CANCEL_GET F_CLUB]/
		public ActionResult F_club_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					var model = new GenioMVC.Models.Club(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("club");

// USE /[MANUAL AJF BEFORE_CANCEL F_CLUB]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL AJF AFTER_CANCEL F_CLUB]/

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

				Navigation.SetValue("ForcePrimaryRead_club", "true", true);
			}

			Navigation.ClearValue("club");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion



		// POST: /Club/F_club_SaveEdit
		[HttpPost]
		public ActionResult F_club_SaveEdit([FromBody] F_club_ViewModel model)
		{
			var eventSink = new EventSink()
			{
				MethodName = "F_club_SaveEdit",
				ViewName = "F_club",
				AreaName = "club",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL AJF BEFORE_APPLY_EDIT F_CLUB]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL AJF AFTER_APPLY_EDIT F_CLUB]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class F_clubDocumValidateTickets : RequestDocumValidateTickets
		{
			public F_club_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsF_club([FromBody] F_clubDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return base.UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
