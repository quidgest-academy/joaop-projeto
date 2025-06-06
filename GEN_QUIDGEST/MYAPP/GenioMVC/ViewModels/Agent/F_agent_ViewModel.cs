using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Agent
{
	public class F_agent_ViewModel : FormViewModel<Models.Agent>, IPreparableForSerialization
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		#region Foreign keys

		#endregion
		/// <summary>
		/// Title: "Photo's Agent" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(30, 50)]
		public GenioMVC.Models.ImageModel ValPhoto { get; set; }
		/// <summary>
		/// Title: "Gender" | Type: "AC"
		/// </summary>
		public string ValGender { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValGender { get; set; }
		/// <summary>
		/// Title: "Agent´s Name" | Type: "C"
		/// </summary>
		public string ValName { get; set; }
		/// <summary>
		/// Title: "Agent's Email" | Type: "C"
		/// </summary>
		public string ValEmail { get; set; }
		/// <summary>
		/// Title: "Agent's Phone" | Type: "C"
		/// </summary>
		public string ValPhone { get; set; }
		/// <summary>
		/// Title: "Percentage of the Comission" | Type: "N"
		/// </summary>
		public decimal? ValPerc_com { get; set; }
		/// <summary>
		/// Title: "Total earn through comission" | Type: "$"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValTotcomis { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodagent { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public F_agent_ViewModel() : base(null!) { }

		public F_agent_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FF_AGENT", nestedForm) { }

		public F_agent_ViewModel(UserContext userContext, Models.Agent row, bool nestedForm = false) : base(userContext, "FF_AGENT", row, nestedForm) { }

		public F_agent_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("agent", id);
			Model = Models.Agent.Find(id, userContext, "FF_AGENT", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_20;
			this.RoleToEdit = CSGenio.framework.Role.ROLE_20;
		}

		#region Form conditions

		public override StatusMessage InsertConditions()
		{
			return InsertConditions(m_userContext);
		}

		public static StatusMessage InsertConditions(UserContext userContext)
		{
			var m_userContext = userContext;
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Agent model = new Models.Agent(userContext) { Identifier = "FF_AGENT" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FF_AGENT");
			if (navigation != null)
				model.LoadKeysFromHistory(navigation, navigation.CurrentLevel.Level);

			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			var tableResult = model.EvaluateTableConditions(ConditionType.UPDATE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage DeleteConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			var tableResult = model.EvaluateTableConditions(ConditionType.DELETE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage ViewConditions()
		{
			var model = Model;
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Agent m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Agent) to ViewModel (F_agent) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValPhoto = ViewModelConversion.ToImage(m.ValPhoto);
				ValGender = ViewModelConversion.ToString(m.ValGender);
				ValName = ViewModelConversion.ToString(m.ValName);
				ValEmail = ViewModelConversion.ToString(m.ValEmail);
				ValPhone = ViewModelConversion.ToString(m.ValPhone);
				ValPerc_com = ViewModelConversion.ToNumeric(m.ValPerc_com);
				ValTotcomis = ViewModelConversion.ToNumeric(m.ValTotcomis);
				ValCodagent = ViewModelConversion.ToString(m.ValCodagent);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Agent) to ViewModel (F_agent) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Agent m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (F_agent) to Model (Agent) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				if (ValPhoto == null || !ValPhoto.IsThumbnail)
					m.ValPhoto = ViewModelConversion.ToImage(ValPhoto);
				m.ValGender = ViewModelConversion.ToString(ValGender);
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValEmail = ViewModelConversion.ToString(ValEmail);
				m.ValPhone = ViewModelConversion.ToString(ValPhone);
				m.ValPerc_com = ViewModelConversion.ToNumeric(ValPerc_com);
				m.ValCodagent = ViewModelConversion.ToString(ValCodagent);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValTotcomis = ViewModelConversion.ToNumeric(ValTotcomis);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (F_agent) to Model (Agent) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
				throw;
			}
		}

		/// <summary>
		/// Sets the value of a single property of the view model based on the provided table and field names.
		/// </summary>
		/// <param name="fullFieldName">The full field name in the format "table.field".</param>
		/// <param name="value">The field value.</param>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="fullFieldName"/> is null.</exception>
		public override void SetViewModelValue(string fullFieldName, object value)
		{
			try
			{
				ArgumentNullException.ThrowIfNull(fullFieldName);
				// Obtain a valid value from JsonValueKind that can come from "prefillValues" during the pre-filling of fields during insertion
				var _value = ViewModelConversion.ToRawValue(value);

				switch (fullFieldName)
				{
					case "agent.photo":
						this.ValPhoto = ViewModelConversion.ToImage(_value);
						break;
					case "agent.gender":
						this.ValGender = ViewModelConversion.ToString(_value);
						break;
					case "agent.name":
						this.ValName = ViewModelConversion.ToString(_value);
						break;
					case "agent.email":
						this.ValEmail = ViewModelConversion.ToString(_value);
						break;
					case "agent.phone":
						this.ValPhone = ViewModelConversion.ToString(_value);
						break;
					case "agent.perc_com":
						this.ValPerc_com = ViewModelConversion.ToNumeric(_value);
						break;
					case "agent.codagent":
						this.ValCodagent = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (F_agent) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (F_agent)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Agent.Find(id ?? Navigation.GetStrValue("agent"), m_userContext, "FF_AGENT"); }
			finally { Model ??= new Models.Agent(m_userContext) { Identifier = "FF_AGENT" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Agent.Find(Navigation.GetStrValue("agent"), m_userContext, "FF_AGENT");
			}
			finally
			{
				if (Model == null)
					throw new ModelNotFoundException("Model not found");

				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
					LoadDefaultValues();
				else
					oldvalues = Model.klass;
			}

			Model.Identifier = "FF_AGENT";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
				// TODO: It needs to be analyzed whether we should disable the security of field filling here. If there is any case where the field with the block condition can only be calculated after the double calculation of the formulas.
				MapToModel(Model);
				// Preencher operações internas
				Model.klass.fillInternalOperations(m_userContext.PersistentSupport, oldvalues);
				MapFromModel(Model);
			}

			// Load just the selected row primary keys for checklists.
			// Needed for submitting forms incase checklists are in collapsible zones that have not been expanded to load the checklist data.
			LoadChecklistsSelectedIDs();
		}

		protected override void FillExtraProperties()
		{
		}

		protected override void LoadDocumentsProperties(Models.Agent row)
		{
		}

		/// <summary>
		/// Load Partial
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public override void LoadPartial(NameValueCollection qs, bool lazyLoad = false)
		{
			// MH [bugfix] - Quando o POST da ficha falha, ao recaregar a view os documentos na BD perdem alguma informação (ex: name do file)
			if (Model == null)
			{
				// Precisamos fazer o Find to obter as chaves dos documentos que já foram anexados
				// TODO: Conseguir passar estas chaves no POST to poder retirar o Find.
				Model = Models.Agent.Find(Navigation.GetStrValue("agent"), m_userContext, "FF_AGENT");
				if (Model == null)
				{
					Model = new Models.Agent(m_userContext) { Identifier = "FF_AGENT" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("agent");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL AJF VIEWMODEL_LOADPARTIAL F_AGENT]/
		}

// USE /[MANUAL AJF VIEWMODEL_NEW F_AGENT]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValName", Resources.Resources.AGENT_S_NAME23140, ValName, 85);

			validator.Required("ValName", Resources.Resources.AGENT_S_NAME23140, ViewModelConversion.ToString(ValName), FieldType.TEXT.GetFormatting());
			validator.StringLength("ValEmail", Resources.Resources.AGENT_S_EMAIL56414, ValEmail, 50);

			validator.Required("ValEmail", Resources.Resources.AGENT_S_EMAIL56414, ViewModelConversion.ToString(ValEmail), FieldType.TEXT.GetFormatting());
			validator.StringLength("ValPhone", Resources.Resources.AGENT_S_PHONE23147, ValPhone, 14);

			validator.Required("ValPhone", Resources.Resources.AGENT_S_PHONE23147, ViewModelConversion.ToString(ValPhone), FieldType.TEXT.GetFormatting());

			validator.Required("ValPerc_com", Resources.Resources.PERCENTAGE_OF_THE_CO01872, ViewModelConversion.ToNumeric(ValPerc_com), FieldType.NUMERIC.GetFormatting());


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL AJF VIEWMODEL_SAVE F_AGENT]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL AJF VIEWMODEL_APPLY F_AGENT]/

// USE /[MANUAL AJF VIEWMODEL_DUPLICATE F_AGENT]/

// USE /[MANUAL AJF VIEWMODEL_DESTROY F_AGENT]/
		public override void Destroy(string id)
		{
			Model = Models.Agent.Find(id, m_userContext, "FF_AGENT");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		/// <summary>
		/// Load selected row primary keys for all checklists
		/// </summary>
		public void LoadChecklistsSelectedIDs()
		{
		}

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"agent.photo" => ViewModelConversion.ToImage(modelValue),
				"agent.gender" => ViewModelConversion.ToString(modelValue),
				"agent.name" => ViewModelConversion.ToString(modelValue),
				"agent.email" => ViewModelConversion.ToString(modelValue),
				"agent.phone" => ViewModelConversion.ToString(modelValue),
				"agent.perc_com" => ViewModelConversion.ToNumeric(modelValue),
				"agent.totcomis" => ViewModelConversion.ToNumeric(modelValue),
				"agent.codagent" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		/// <inheritdoc/>
		protected override void SetTicketToImageFields()
		{
			if (ValPhoto != null)
				ValPhoto.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaAGENT, CSGenioAagent.FldPhoto.Field, null, ValCodagent);
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL AJF VIEWMODEL_CUSTOM F_AGENT]/

		#endregion
	}
}
