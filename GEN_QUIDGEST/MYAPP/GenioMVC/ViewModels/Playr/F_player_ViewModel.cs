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
		/// Title: "Agent´s Name" | Type: "CE"
		/// </summary>
		public string ValCodagent { get; set; }
		/// <summary>
		/// Title: "Country" | Type: "CE"
		/// </summary>
		public string ValCodcntry { get; set; }

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
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Cntry> TableCntryCountry { get; set; }
		/// <summary>
		/// Title: "Position" | Type: "C"
		/// </summary>
		public string ValPosic { get; set; }
		/// <summary>
		/// Title: "Agent´s Name" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Agent> TableAgentName { get; set; }

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
				ValCodcntry = ViewModelConversion.ToString(m.ValCodcntry);
				ValUndctc = ViewModelConversion.ToInteger(m.ValUndctc);
				ValGender = ViewModelConversion.ToString(m.ValGender);
				ValName = ViewModelConversion.ToString(m.ValName);
				ValBirthdat = ViewModelConversion.ToDateTime(m.ValBirthdat);
				ValAge = ViewModelConversion.ToNumeric(m.ValAge);
				ValPosic = ViewModelConversion.ToString(m.ValPosic);
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
				m.ValCodagent = ViewModelConversion.ToString(ValCodagent);
				m.ValCodcntry = ViewModelConversion.ToString(ValCodcntry);
				m.ValUndctc = ViewModelConversion.ToInteger(ValUndctc);
				m.ValGender = ViewModelConversion.ToString(ValGender);
				m.ValName = ViewModelConversion.ToString(ValName);
				m.ValBirthdat = ViewModelConversion.ToDateTime(ValBirthdat);
				m.ValPosic = ViewModelConversion.ToString(ValPosic);
				m.ValCodplayr = ViewModelConversion.ToString(ValCodplayr);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

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
					case "playr.codagent":
						this.ValCodagent = ViewModelConversion.ToString(_value);
						break;
					case "playr.codcntry":
						this.ValCodcntry = ViewModelConversion.ToString(_value);
						break;
					case "playr.undctc":
						this.ValUndctc = ViewModelConversion.ToInteger(_value);
						break;
					case "playr.gender":
						this.ValGender = ViewModelConversion.ToString(_value);
						break;
					case "playr.name":
						this.ValName = ViewModelConversion.ToString(_value);
						break;
					case "playr.birthdat":
						this.ValBirthdat = ViewModelConversion.ToDateTime(_value);
						break;
					case "playr.posic":
						this.ValPosic = ViewModelConversion.ToString(_value);
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

			Load_F_playercntrycountry_(qs, lazyLoad);
			Load_F_playeragentname____(qs, lazyLoad);
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

		/// <summary>
		/// TableCntryCountry -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_F_playercntrycountry_(NameValueCollection qs, bool lazyLoad = false)
		{
			bool f_playercntrycountry_DoLoad = true;
			CriteriaSet f_playercntrycountry_Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("cntry", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					f_playercntrycountry_Conds.Equal(CSGenioAcntry.FldCodcntry, hValue);
					this.ValCodcntry = DBConversion.ToString(hValue);
				}
			}

			TableCntryCountry = new TableDBEdit<Models.Cntry>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_cntry") != null)
				{
					this.ValCodcntry = Navigation.GetStrValue("RETURN_cntry");
					Navigation.CurrentLevel.SetEntry("RETURN_cntry", null);
				}
				FillDependant_F_playerTableCntryCountry(lazyLoad);
				return;
			}

			if (f_playercntrycountry_DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableCntryCountry, "sTableCntryCountry", "dTableCntryCountry", qs, "cntry");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcntry.FldCountry), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableCntryCountry_tableFilters"]))
					TableCntryCountry.TableFilters = bool.Parse(qs["TableCntryCountry_tableFilters"]);
				else
					TableCntryCountry.TableFilters = false;

				query = qs["qTableCntryCountry"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAcntry.FldCountry, query + "%");
				}
				f_playercntrycountry_Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableCntryCountry"] != null ? qs["pTableCntryCountry"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry, CSGenioAcntry.FldZzstate };

// USE /[MANUAL AJF OVERRQ F_PLAYER_CNTRYCOUNTRY]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("cntry", FormMode.New) || Navigation.checkFormMode("cntry", FormMode.Duplicate))
					f_playercntrycountry_Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAcntry.FldZzstate, 0)
						.Equal(CSGenioAcntry.FldCodcntry, Navigation.GetStrValue("cntry")));
				else
					f_playercntrycountry_Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAcntry.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("cntry", "country");
				ListingMVC<CSGenioAcntry> listing = Models.ModelBase.Where<CSGenioAcntry>(m_userContext, false, f_playercntrycountry_Conds, fields, offset, numberItems, sorts, "LED_F_PLAYERCNTRYCOUNTRY_", true, false, firstVisibleColumn: firstVisibleColumn);

				TableCntryCountry.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableCntryCountry.Query = query;
				TableCntryCountry.Elements = listing.RowsForViewModel<GenioMVC.Models.Cntry>((r) => new GenioMVC.Models.Cntry(m_userContext, r, true, _fieldsToSerialize_F_PLAYERCNTRYCOUNTRY_));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_cntry") != null)
				{
					this.ValCodcntry = Navigation.GetStrValue("RETURN_cntry");
					Navigation.CurrentLevel.SetEntry("RETURN_cntry", null);
				}

				TableCntryCountry.List = new SelectList(TableCntryCountry.Elements.ToSelectList(x => x.ValCountry, x => x.ValCodcntry,  x => x.ValCodcntry == this.ValCodcntry), "Value", "Text", this.ValCodcntry);
				FillDependant_F_playerTableCntryCountry();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableCntryCountry (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Cntry</param>
		public ConcurrentDictionary<string, object> GetDependant_F_playerTableCntryCountry(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAcntry.FldCodcntry, CSGenioAcntry.FldCountry];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAcntry tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAcntry.FldCodcntry, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableCntryCountry (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_F_playerTableCntryCountry(bool lazyLoad = false)
		{
			var row = GetDependant_F_playerTableCntryCountry(this.ValCodcntry);
			try
			{

				// Fill List fields
				this.ValCodcntry = ViewModelConversion.ToString(row["cntry.codcntry"]);
				TableCntryCountry.Value = (string)row["cntry.country"];
				if (GenFunctions.emptyG(this.ValCodcntry) == 1)
				{
					this.ValCodcntry = "";
					TableCntryCountry.Value = "";
					Navigation.ClearValue("cntry");
				}
				else if (lazyLoad)
				{
					TableCntryCountry.SetPagination(1, 0, false, false, 1);
					TableCntryCountry.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodcntry),
							Text = Convert.ToString(TableCntryCountry.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodcntry);
				}

				TableCntryCountry.Selected = this.ValCodcntry;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableCntryCountry): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_F_PLAYERCNTRYCOUNTRY_ = ["Cntry", "Cntry.ValCodcntry", "Cntry.ValZzstate", "Cntry.ValCountry"];

		/// <summary>
		/// TableAgentName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_F_playeragentname____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool f_playeragentname____DoLoad = true;
			CriteriaSet f_playeragentname____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("agent", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					f_playeragentname____Conds.Equal(CSGenioAagent.FldCodagent, hValue);
					this.ValCodagent = DBConversion.ToString(hValue);
				}
			}

			TableAgentName = new TableDBEdit<Models.Agent>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_agent") != null)
				{
					this.ValCodagent = Navigation.GetStrValue("RETURN_agent");
					Navigation.CurrentLevel.SetEntry("RETURN_agent", null);
				}
				FillDependant_F_playerTableAgentName(lazyLoad);
				return;
			}

			if (f_playeragentname____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableAgentName, "sTableAgentName", "dTableAgentName", qs, "agent");
				if (requestedSort != null)
					sorts.Add(requestedSort);

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableAgentName_tableFilters"]))
					TableAgentName.TableFilters = bool.Parse(qs["TableAgentName_tableFilters"]);
				else
					TableAgentName.TableFilters = false;

				query = qs["qTableAgentName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAagent.FldName, query + "%");
				}
				f_playeragentname____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableAgentName"] != null ? qs["pTableAgentName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAagent.FldCodagent, CSGenioAagent.FldName, CSGenioAagent.FldEmail, CSGenioAagent.FldPhone, CSGenioAagent.FldZzstate };

// USE /[MANUAL AJF OVERRQ F_PLAYER_AGENTNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("agent", FormMode.New) || Navigation.checkFormMode("agent", FormMode.Duplicate))
					f_playeragentname____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAagent.FldZzstate, 0)
						.Equal(CSGenioAagent.FldCodagent, Navigation.GetStrValue("agent")));
				else
					f_playeragentname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAagent.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("agent", "email");
				ListingMVC<CSGenioAagent> listing = Models.ModelBase.Where<CSGenioAagent>(m_userContext, false, f_playeragentname____Conds, fields, offset, numberItems, sorts, "LED_F_PLAYERAGENTNAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableAgentName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableAgentName.Query = query;
				TableAgentName.Elements = listing.RowsForViewModel<GenioMVC.Models.Agent>((r) => new GenioMVC.Models.Agent(m_userContext, r, true, _fieldsToSerialize_F_PLAYERAGENTNAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_agent") != null)
				{
					this.ValCodagent = Navigation.GetStrValue("RETURN_agent");
					Navigation.CurrentLevel.SetEntry("RETURN_agent", null);
				}

				TableAgentName.List = new SelectList(TableAgentName.Elements.ToSelectList(x => x.ValName, x => x.ValCodagent,  x => x.ValCodagent == this.ValCodagent), "Value", "Text", this.ValCodagent);
				FillDependant_F_playerTableAgentName();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableAgentName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Agent</param>
		public ConcurrentDictionary<string, object> GetDependant_F_playerTableAgentName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAagent.FldCodagent, CSGenioAagent.FldName];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAagent tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAagent.FldCodagent, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableAgentName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_F_playerTableAgentName(bool lazyLoad = false)
		{
			var row = GetDependant_F_playerTableAgentName(this.ValCodagent);
			try
			{

				// Fill List fields
				this.ValCodagent = ViewModelConversion.ToString(row["agent.codagent"]);
				TableAgentName.Value = (string)row["agent.name"];
				if (GenFunctions.emptyG(this.ValCodagent) == 1)
				{
					this.ValCodagent = "";
					TableAgentName.Value = "";
					Navigation.ClearValue("agent");
				}
				else if (lazyLoad)
				{
					TableAgentName.SetPagination(1, 0, false, false, 1);
					TableAgentName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodagent),
							Text = Convert.ToString(TableAgentName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodagent);
				}

				TableAgentName.Selected = this.ValCodagent;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableAgentName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_F_PLAYERAGENTNAME____ = ["Agent", "Agent.ValCodagent", "Agent.ValZzstate", "Agent.ValEmail", "Agent.ValPhone"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"playr.codagent" => ViewModelConversion.ToString(modelValue),
				"playr.codcntry" => ViewModelConversion.ToString(modelValue),
				"playr.undctc" => ViewModelConversion.ToInteger(modelValue),
				"playr.gender" => ViewModelConversion.ToString(modelValue),
				"playr.name" => ViewModelConversion.ToString(modelValue),
				"playr.birthdat" => ViewModelConversion.ToDateTime(modelValue),
				"playr.age" => ViewModelConversion.ToNumeric(modelValue),
				"playr.posic" => ViewModelConversion.ToString(modelValue),
				"playr.codplayr" => ViewModelConversion.ToString(modelValue),
				"cntry.codcntry" => ViewModelConversion.ToString(modelValue),
				"cntry.country" => ViewModelConversion.ToString(modelValue),
				"agent.codagent" => ViewModelConversion.ToString(modelValue),
				"agent.name" => ViewModelConversion.ToString(modelValue),
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
