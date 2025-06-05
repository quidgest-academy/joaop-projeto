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

namespace GenioMVC.ViewModels.Playr
{
	public class F_player_ViewModel : FormViewModel<Models.Playr>, IPreparableForSerialization
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		#region Foreign keys
		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValCodagent { get; set; }

		#endregion
		/// <summary>
		/// Title: "Under Contract?" | Type: "AL"
		/// </summary>
		public int ValUndctc { get; set; }
		/// <summary>
		/// Title: "" | Type: "PSEUD"
		/// </summary>
		[JsonIgnore]
		public SelectList List_ValUndctc { get; set; }
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
		/// Title: "Name of the player" | Type: "C"
		/// </summary>
		public string ValName { get; set; }
		/// <summary>
		/// Title: "Position" | Type: "C"
		/// </summary>
		public string ValPosic { get; set; }
		/// <summary>
		/// Title: "Birthdate" | Type: "D"
		/// </summary>
		public DateTime? ValBirthdat { get; set; }
		/// <summary>
		/// Title: "Player's Age" | Type: "N"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValAge { get; set; }
		/// <summary>
		/// Title: "Country" | Type: "C"
		/// </summary>
		public string ValCountry { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodplayr { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public F_player_ViewModel() : base(null!) { }

		public F_player_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FF_PLAYER", nestedForm) { }

		public F_player_ViewModel(UserContext userContext, Models.Playr row, bool nestedForm = false) : base(userContext, "FF_PLAYER", row, nestedForm) { }

		public F_player_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("playr", id);
			Model = Models.Playr.Find(id, userContext, "FF_PLAYER", fieldsToQuery: fieldsToLoad);
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
			Models.Playr model = new Models.Playr(userContext) { Identifier = "FF_PLAYER" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FF_PLAYER");
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
		public override void MapFromModel(Models.Playr m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Playr) to ViewModel (F_player) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodagent = ViewModelConversion.ToString(m.ValCodagent);
				ValUndctc = ViewModelConversion.ToInteger(m.ValUndctc);
				ValGender = ViewModelConversion.ToString(m.ValGender);
				ValName = ViewModelConversion.ToString(m.ValName);
				ValPosic = ViewModelConversion.ToString(m.ValPosic);
				ValBirthdat = ViewModelConversion.ToDateTime(m.ValBirthdat);
				ValAge = ViewModelConversion.ToNumeric(m.ValAge);
				ValCountry = ViewModelConversion.ToString(m.ValCountry);
				ValCodplayr = ViewModelConversion.ToString(m.ValCodplayr);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Playr) to ViewModel (F_player) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Playr m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (F_player) to Model (Playr) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValUndctc = ViewModelConversion.ToInteger(ValUndctc);
				m.ValGender = ViewModelConversion.ToString(ValGender);
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValPosic = ViewModelConversion.ToString(ValPosic);
				m.ValBirthdat = ViewModelConversion.ToDateTime(ValBirthdat);
				m.ValCountry = ViewModelConversion.ToString(ValCountry);
				m.ValCodplayr = ViewModelConversion.ToString(ValCodplayr);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValCodagent = ViewModelConversion.ToString(ValCodagent);
				m.ValAge = ViewModelConversion.ToNumeric(ValAge);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (F_player) to Model (Playr) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "playr.undctc":
						this.ValUndctc = ViewModelConversion.ToInteger(_value);
						break;
					case "playr.gender":
						this.ValGender = ViewModelConversion.ToString(_value);
						break;
					case "playr.name":
						this.ValName = ViewModelConversion.ToString(_value);
						break;
					case "playr.posic":
						this.ValPosic = ViewModelConversion.ToString(_value);
						break;
					case "playr.birthdat":
						this.ValBirthdat = ViewModelConversion.ToDateTime(_value);
						break;
					case "playr.country":
						this.ValCountry = ViewModelConversion.ToString(_value);
						break;
					case "playr.codplayr":
						this.ValCodplayr = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (F_player) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (F_player)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Playr.Find(id ?? Navigation.GetStrValue("playr"), m_userContext, "FF_PLAYER"); }
			finally { Model ??= new Models.Playr(m_userContext) { Identifier = "FF_PLAYER" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Playr.Find(Navigation.GetStrValue("playr"), m_userContext, "FF_PLAYER");
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

			Model.Identifier = "FF_PLAYER";
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

		protected override void LoadDocumentsProperties(Models.Playr row)
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
				Model = Models.Playr.Find(Navigation.GetStrValue("playr"), m_userContext, "FF_PLAYER");
				if (Model == null)
				{
					Model = new Models.Playr(m_userContext) { Identifier = "FF_PLAYER" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("playr");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

// USE /[MANUAL AJF VIEWMODEL_LOADPARTIAL F_PLAYER]/
		}

// USE /[MANUAL AJF VIEWMODEL_NEW F_PLAYER]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValName", Resources.Resources.NAME_OF_THE_PLAYER61428, ValName, 85);
			validator.StringLength("ValPosic", Resources.Resources.POSITION54869, ValPosic, 50);
			validator.StringLength("ValCountry", Resources.Resources.COUNTRY64133, ValCountry, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL AJF VIEWMODEL_SAVE F_PLAYER]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL AJF VIEWMODEL_APPLY F_PLAYER]/

// USE /[MANUAL AJF VIEWMODEL_DUPLICATE F_PLAYER]/

// USE /[MANUAL AJF VIEWMODEL_DESTROY F_PLAYER]/
		public override void Destroy(string id)
		{
			Model = Models.Playr.Find(id, m_userContext, "FF_PLAYER");
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
				"playr.codagent" => ViewModelConversion.ToString(modelValue),
				"playr.undctc" => ViewModelConversion.ToInteger(modelValue),
				"playr.gender" => ViewModelConversion.ToString(modelValue),
				"playr.name" => ViewModelConversion.ToString(modelValue),
				"playr.posic" => ViewModelConversion.ToString(modelValue),
				"playr.birthdat" => ViewModelConversion.ToDateTime(modelValue),
				"playr.age" => ViewModelConversion.ToNumeric(modelValue),
				"playr.country" => ViewModelConversion.ToString(modelValue),
				"playr.codplayr" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL AJF VIEWMODEL_CUSTOM F_PLAYER]/

		#endregion
	}
}
