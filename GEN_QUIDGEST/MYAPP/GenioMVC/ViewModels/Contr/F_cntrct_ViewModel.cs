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

namespace GenioMVC.ViewModels.Contr
{
	public class F_cntrct_ViewModel : FormViewModel<Models.Contr>, IPreparableForSerialization
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
		public string ValCodagent { get; set; }
		/// <summary>
		/// Title: "Club's Name" | Type: "CE"
		/// </summary>
		public string ValCodclub { get; set; }
		/// <summary>
		/// Title: "Name of the player" | Type: "CE"
		/// </summary>
		public string ValCodplayr { get; set; }

		#endregion
		/// <summary>
		/// Title: "Name of the player" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Playr> TablePlayrName { get; set; }
		/// <summary>
		/// Title: "Club's Name" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Club> TableClubName { get; set; }
		/// <summary>
		/// Title: "Agent's Email" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string AgentValEmail 
		{
			get
			{
				return funcAgentValEmail != null ? funcAgentValEmail() : _auxAgentValEmail;
			}
			set { funcAgentValEmail = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcAgentValEmail { get; set; }

		private string _auxAgentValEmail { get; set; }
		/// <summary>
		/// Title: "Starting Date" | Type: "D"
		/// </summary>
		public DateTime? ValStartdat { get; set; }
		/// <summary>
		/// Title: "Finish Date" | Type: "D"
		/// </summary>
		public DateTime? ValFindate { get; set; }
		/// <summary>
		/// Title: "Contract duration" | Type: "N"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValCtrdurat { get; set; }
		/// <summary>
		/// Title: "Salary of the player" | Type: "$"
		/// </summary>
		public decimal? ValSalary { get; set; }
		/// <summary>
		/// Title: "Yearly Salary" | Type: "$"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValSlryyr { get; set; }
		/// <summary>
		/// Title: "Transfer Value" | Type: "N"
		/// </summary>
		public decimal? ValTransval { get; set; }
		/// <summary>
		/// Title: "Monetary Value comissions through each transfer" | Type: "$"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValComiseur { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas

		// Field for formula
		/// <summary>Used only for lazy loading of the AgentValPerc_com field</summary>
		[JsonIgnore]
		[ValidateSetAccess]
		public Func<decimal?> funcAgentValPerc_com { get; set; }
		private decimal? _auxAgentValPerc_com { get; set; }
		/// <summary>Field: "Percentage of the Comission" Tipo: "N"</summary>
		[ValidateSetAccess]
		public decimal? AgentValPerc_com { get { return funcAgentValPerc_com != null ? funcAgentValPerc_com() : _auxAgentValPerc_com; } private set { funcAgentValPerc_com = () => value; } }

		#endregion

		public string ValCodcontr { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public F_cntrct_ViewModel() : base(null!) { }

		public F_cntrct_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FF_CNTRCT", nestedForm) { }

		public F_cntrct_ViewModel(UserContext userContext, Models.Contr row, bool nestedForm = false) : base(userContext, "FF_CNTRCT", row, nestedForm) { }

		public F_cntrct_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("contr", id);
			Model = Models.Contr.Find(id, userContext, "FF_CNTRCT", fieldsToQuery: fieldsToLoad);
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
			Models.Contr model = new Models.Contr(userContext) { Identifier = "FF_CNTRCT" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FF_CNTRCT");
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
		public override void MapFromModel(Models.Contr m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Contr) to ViewModel (F_cntrct) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodagent = ViewModelConversion.ToString(m.ValCodagent);
				ValCodclub = ViewModelConversion.ToString(m.ValCodclub);
				ValCodplayr = ViewModelConversion.ToString(m.ValCodplayr);
				funcAgentValEmail = () => ViewModelConversion.ToString(m.Agent.ValEmail);
				ValStartdat = ViewModelConversion.ToDateTime(m.ValStartdat);
				ValFindate = ViewModelConversion.ToDateTime(m.ValFindate);
				ValCtrdurat = ViewModelConversion.ToNumeric(m.ValCtrdurat);
				ValSalary = ViewModelConversion.ToNumeric(m.ValSalary);
				ValSlryyr = ViewModelConversion.ToNumeric(m.ValSlryyr);
				ValTransval = ViewModelConversion.ToNumeric(m.ValTransval);
				ValComiseur = ViewModelConversion.ToNumeric(m.ValComiseur);
				funcAgentValPerc_com = () => ViewModelConversion.ToNumeric(m.Agent.ValPerc_com);
				ValCodcontr = ViewModelConversion.ToString(m.ValCodcontr);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Contr) to ViewModel (F_cntrct) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Contr m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (F_cntrct) to Model (Contr) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodagent = ViewModelConversion.ToString(ValCodagent);
				m.ValCodclub = ViewModelConversion.ToString(ValCodclub);
				m.ValCodplayr = ViewModelConversion.ToString(ValCodplayr);
				m.ValStartdat = ViewModelConversion.ToDateTime(ValStartdat);
				m.ValFindate = ViewModelConversion.ToDateTime(ValFindate);
				m.ValSalary = ViewModelConversion.ToNumeric(ValSalary);
				m.ValTransval = ViewModelConversion.ToNumeric(ValTransval);
				m.ValCodcontr = ViewModelConversion.ToString(ValCodcontr);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValCtrdurat = ViewModelConversion.ToNumeric(ValCtrdurat);
				m.ValSlryyr = ViewModelConversion.ToNumeric(ValSlryyr);
				m.ValComiseur = ViewModelConversion.ToNumeric(ValComiseur);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (F_cntrct) to Model (Contr) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "contr.codagent":
						this.ValCodagent = ViewModelConversion.ToString(_value);
						break;
					case "contr.codclub":
						this.ValCodclub = ViewModelConversion.ToString(_value);
						break;
					case "contr.codplayr":
						this.ValCodplayr = ViewModelConversion.ToString(_value);
						break;
					case "contr.startdat":
						this.ValStartdat = ViewModelConversion.ToDateTime(_value);
						break;
					case "contr.findate":
						this.ValFindate = ViewModelConversion.ToDateTime(_value);
						break;
					case "contr.salary":
						this.ValSalary = ViewModelConversion.ToNumeric(_value);
						break;
					case "contr.transval":
						this.ValTransval = ViewModelConversion.ToNumeric(_value);
						break;
					case "contr.codcontr":
						this.ValCodcontr = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (F_cntrct) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (F_cntrct)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Contr.Find(id ?? Navigation.GetStrValue("contr"), m_userContext, "FF_CNTRCT"); }
			finally { Model ??= new Models.Contr(m_userContext) { Identifier = "FF_CNTRCT" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Contr.Find(Navigation.GetStrValue("contr"), m_userContext, "FF_CNTRCT");
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

			Model.Identifier = "FF_CNTRCT";
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

		protected override void LoadDocumentsProperties(Models.Contr row)
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
				Model = Models.Contr.Find(Navigation.GetStrValue("contr"), m_userContext, "FF_CNTRCT");
				if (Model == null)
				{
					Model = new Models.Contr(m_userContext) { Identifier = "FF_CNTRCT" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("contr");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_F_cntrctplayrname____(qs, lazyLoad);
			Load_F_cntrctclub_name____(qs, lazyLoad);
// USE /[MANUAL AJF VIEWMODEL_LOADPARTIAL F_CNTRCT]/
		}

// USE /[MANUAL AJF VIEWMODEL_NEW F_CNTRCT]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("AgentValEmail", Resources.Resources.AGENT_S_EMAIL56414, AgentValEmail, 50);

			validator.Required("ValStartdat", Resources.Resources.STARTING_DATE47975, ViewModelConversion.ToDateTime(ValStartdat), FieldType.DATE.GetFormatting());

			validator.Required("ValFindate", Resources.Resources.FINISH_DATE41863, ViewModelConversion.ToDateTime(ValFindate), FieldType.DATE.GetFormatting());

			validator.Required("ValSalary", Resources.Resources.SALARY_OF_THE_PLAYER18170, ViewModelConversion.ToNumeric(ValSalary), FieldType.CURRENCY.GetFormatting());

			validator.Required("ValTransval", Resources.Resources.TRANSFER_VALUE12168, ViewModelConversion.ToNumeric(ValTransval), FieldType.NUMERIC.GetFormatting());


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL AJF VIEWMODEL_SAVE F_CNTRCT]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL AJF VIEWMODEL_APPLY F_CNTRCT]/

// USE /[MANUAL AJF VIEWMODEL_DUPLICATE F_CNTRCT]/

// USE /[MANUAL AJF VIEWMODEL_DESTROY F_CNTRCT]/
		public override void Destroy(string id)
		{
			Model = Models.Contr.Find(id, m_userContext, "FF_CNTRCT");
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
		/// TablePlayrName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_F_cntrctplayrname____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool f_cntrctplayrname____DoLoad = true;
			CriteriaSet f_cntrctplayrname____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("playr", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					f_cntrctplayrname____Conds.Equal(CSGenioAplayr.FldCodplayr, hValue);
					this.ValCodplayr = DBConversion.ToString(hValue);
				}
			}

			TablePlayrName = new TableDBEdit<Models.Playr>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_playr") != null)
				{
					this.ValCodplayr = Navigation.GetStrValue("RETURN_playr");
					Navigation.CurrentLevel.SetEntry("RETURN_playr", null);
				}
				FillDependant_F_cntrctTablePlayrName(lazyLoad);
				return;
			}

			if (f_cntrctplayrname____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TablePlayrName, "sTablePlayrName", "dTablePlayrName", qs, "playr");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAplayr.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TablePlayrName_tableFilters"]))
					TablePlayrName.TableFilters = bool.Parse(qs["TablePlayrName_tableFilters"]);
				else
					TablePlayrName.TableFilters = false;

				query = qs["qTablePlayrName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAplayr.FldName, query + "%");
				}
				f_cntrctplayrname____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTablePlayrName"] != null ? qs["pTablePlayrName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAplayr.FldCodplayr, CSGenioAplayr.FldName, CSGenioAplayr.FldBirthdat, CSGenioAplayr.FldZzstate };

// USE /[MANUAL AJF OVERRQ F_CNTRCT_PLAYRNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("playr", FormMode.New) || Navigation.checkFormMode("playr", FormMode.Duplicate))
					f_cntrctplayrname____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAplayr.FldZzstate, 0)
						.Equal(CSGenioAplayr.FldCodplayr, Navigation.GetStrValue("playr")));
				else
					f_cntrctplayrname____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAplayr.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("playr", "name");
				ListingMVC<CSGenioAplayr> listing = Models.ModelBase.Where<CSGenioAplayr>(m_userContext, false, f_cntrctplayrname____Conds, fields, offset, numberItems, sorts, "LED_F_CNTRCTPLAYRNAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TablePlayrName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TablePlayrName.Query = query;
				TablePlayrName.Elements = listing.RowsForViewModel<GenioMVC.Models.Playr>((r) => new GenioMVC.Models.Playr(m_userContext, r, true, _fieldsToSerialize_F_CNTRCTPLAYRNAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_playr") != null)
				{
					this.ValCodplayr = Navigation.GetStrValue("RETURN_playr");
					Navigation.CurrentLevel.SetEntry("RETURN_playr", null);
				}

				TablePlayrName.List = new SelectList(TablePlayrName.Elements.ToSelectList(x => x.ValName, x => x.ValCodplayr,  x => x.ValCodplayr == this.ValCodplayr), "Value", "Text", this.ValCodplayr);
				FillDependant_F_cntrctTablePlayrName();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TablePlayrName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Playr</param>
		public ConcurrentDictionary<string, object> GetDependant_F_cntrctTablePlayrName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAplayr.FldCodplayr, CSGenioAplayr.FldName, CSGenioAagent.FldCodagent, CSGenioAagent.FldEmail];

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

			CSGenioAplayr tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAplayr.FldCodplayr, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TablePlayrName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_F_cntrctTablePlayrName(bool lazyLoad = false)
		{
			var row = GetDependant_F_cntrctTablePlayrName(this.ValCodplayr);
			try
			{
				this.ValCodagent = (string)row["agent.codagent"];
				this.funcAgentValEmail = () => (string)row["agent.email"];

				// Fill List fields
				this.ValCodplayr = ViewModelConversion.ToString(row["playr.codplayr"]);
				TablePlayrName.Value = (string)row["playr.name"];
				if (GenFunctions.emptyG(this.ValCodplayr) == 1)
				{
					this.ValCodplayr = "";
					TablePlayrName.Value = "";
					Navigation.ClearValue("playr");
				}
				else if (lazyLoad)
				{
					TablePlayrName.SetPagination(1, 0, false, false, 1);
					TablePlayrName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodplayr),
							Text = Convert.ToString(TablePlayrName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodplayr);
				}

				TablePlayrName.Selected = this.ValCodplayr;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TablePlayrName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_F_CNTRCTPLAYRNAME____ = ["Playr", "Playr.ValCodplayr", "Playr.ValZzstate", "Playr.ValName", "Playr.ValBirthdat"];

		/// <summary>
		/// TableClubName -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_F_cntrctclub_name____(NameValueCollection qs, bool lazyLoad = false)
		{
			bool f_cntrctclub_name____DoLoad = true;
			CriteriaSet f_cntrctclub_name____Conds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("club", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					f_cntrctclub_name____Conds.Equal(CSGenioAclub.FldCodclub, hValue);
					this.ValCodclub = DBConversion.ToString(hValue);
				}
			}

			TableClubName = new TableDBEdit<Models.Club>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_club") != null)
				{
					this.ValCodclub = Navigation.GetStrValue("RETURN_club");
					Navigation.CurrentLevel.SetEntry("RETURN_club", null);
				}
				FillDependant_F_cntrctTableClubName(lazyLoad);
				return;
			}

			if (f_cntrctclub_name____DoLoad)
			{
				List<ColumnSort> sorts = new List<ColumnSort>();
				ColumnSort requestedSort = GetRequestSort(TableClubName, "sTableClubName", "dTableClubName", qs, "club");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAclub.FldName), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableClubName_tableFilters"]))
					TableClubName.TableFilters = bool.Parse(qs["TableClubName_tableFilters"]);
				else
					TableClubName.TableFilters = false;

				query = qs["qTableClubName"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAclub.FldName, query + "%");
				}
				f_cntrctclub_name____Conds.SubSet(search_filters);

				string tryParsePage = qs["pTableClubName"] != null ? qs["pTableClubName"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = new FieldRef[] { CSGenioAclub.FldCodclub, CSGenioAclub.FldName, CSGenioAclub.FldZzstate };

// USE /[MANUAL AJF OVERRQ F_CNTRCT_CLUBNAME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("club", FormMode.New) || Navigation.checkFormMode("club", FormMode.Duplicate))
					f_cntrctclub_name____Conds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAclub.FldZzstate, 0)
						.Equal(CSGenioAclub.FldCodclub, Navigation.GetStrValue("club")));
				else
					f_cntrctclub_name____Conds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAclub.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("club", "name");
				ListingMVC<CSGenioAclub> listing = Models.ModelBase.Where<CSGenioAclub>(m_userContext, false, f_cntrctclub_name____Conds, fields, offset, numberItems, sorts, "LED_F_CNTRCTCLUB_NAME____", true, false, firstVisibleColumn: firstVisibleColumn);

				TableClubName.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableClubName.Query = query;
				TableClubName.Elements = listing.RowsForViewModel<GenioMVC.Models.Club>((r) => new GenioMVC.Models.Club(m_userContext, r, true, _fieldsToSerialize_F_CNTRCTCLUB_NAME____));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_club") != null)
				{
					this.ValCodclub = Navigation.GetStrValue("RETURN_club");
					Navigation.CurrentLevel.SetEntry("RETURN_club", null);
				}

				TableClubName.List = new SelectList(TableClubName.Elements.ToSelectList(x => x.ValName, x => x.ValCodclub,  x => x.ValCodclub == this.ValCodclub), "Value", "Text", this.ValCodclub);
				FillDependant_F_cntrctTableClubName();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableClubName (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Club</param>
		public ConcurrentDictionary<string, object> GetDependant_F_cntrctTableClubName(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAclub.FldCodclub, CSGenioAclub.FldName];

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

			CSGenioAclub tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAclub.FldCodclub, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableClubName (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_F_cntrctTableClubName(bool lazyLoad = false)
		{
			var row = GetDependant_F_cntrctTableClubName(this.ValCodclub);
			try
			{

				// Fill List fields
				this.ValCodclub = ViewModelConversion.ToString(row["club.codclub"]);
				TableClubName.Value = (string)row["club.name"];
				if (GenFunctions.emptyG(this.ValCodclub) == 1)
				{
					this.ValCodclub = "";
					TableClubName.Value = "";
					Navigation.ClearValue("club");
				}
				else if (lazyLoad)
				{
					TableClubName.SetPagination(1, 0, false, false, 1);
					TableClubName.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodclub),
							Text = Convert.ToString(TableClubName.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodclub);
				}

				TableClubName.Selected = this.ValCodclub;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableClubName): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_F_CNTRCTCLUB_NAME____ = ["Club", "Club.ValCodclub", "Club.ValZzstate", "Club.ValName"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"contr.codagent" => ViewModelConversion.ToString(modelValue),
				"contr.codclub" => ViewModelConversion.ToString(modelValue),
				"contr.codplayr" => ViewModelConversion.ToString(modelValue),
				"agent.email" => ViewModelConversion.ToString(modelValue),
				"contr.startdat" => ViewModelConversion.ToDateTime(modelValue),
				"contr.findate" => ViewModelConversion.ToDateTime(modelValue),
				"contr.ctrdurat" => ViewModelConversion.ToNumeric(modelValue),
				"contr.salary" => ViewModelConversion.ToNumeric(modelValue),
				"contr.slryyr" => ViewModelConversion.ToNumeric(modelValue),
				"contr.transval" => ViewModelConversion.ToNumeric(modelValue),
				"contr.comiseur" => ViewModelConversion.ToNumeric(modelValue),
				"agent.perc_com" => ViewModelConversion.ToNumeric(modelValue),
				"contr.codcontr" => ViewModelConversion.ToString(modelValue),
				"playr.codplayr" => ViewModelConversion.ToString(modelValue),
				"playr.name" => ViewModelConversion.ToString(modelValue),
				"agent.codagent" => ViewModelConversion.ToString(modelValue),
				"club.codclub" => ViewModelConversion.ToString(modelValue),
				"club.name" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL AJF VIEWMODEL_CUSTOM F_CNTRCT]/

		#endregion
	}
}
