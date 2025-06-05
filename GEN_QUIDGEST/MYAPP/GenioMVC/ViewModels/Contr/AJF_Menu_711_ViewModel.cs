using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;
using JsonPropertyName = System.Text.Json.Serialization.JsonPropertyNameAttribute;
using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;

using CSGenio.business;
using CSGenio.core.di;
using CSGenio.framework;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Contr
{
	public class AJF_Menu_711_ViewModel : MenuListViewModel<Models.Contr>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<AJF_Menu_711_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "contr";

		/// <inheritdoc/>
		public override string Uuid => "3bff32b0-21bc-40b0-8fe8-9f2b625160fc";

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize => _fieldsToSerialize;

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns => _searchableColumns;

		/// <summary>
		/// The context of the parent.
		/// </summary>
		[JsonIgnore]
		public Models.ModelBase ParentCtx { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override CriteriaSet StaticLimits
		{
			get
			{
				CriteriaSet conditions = CriteriaSet.And();
				// Limitations
				// Limit "SC"
				conditions.Equal(CSGenioAplayr.FldUndctc, "1");

				return conditions;
			}
		}

		/// <inheritdoc/>
		[JsonIgnore]
		public override CriteriaSet baseConditions
		{
			get
			{
				CriteriaSet conds = CriteriaSet.And();
				if (Navigation.CheckKey("playr.undctc"))
					conds.Equal(CSGenioAplayr.FldUndctc, Navigation.GetValue("playr.undctc"));

				return conds;
			}
		}

		/// <inheritdoc/>
		[JsonIgnore]
		public override List<Relation> relations
		{
			get
			{
				List<Relation> relations = null;
				return relations;
			}
		}

		public override CriteriaSet GetCustomizedStaticLimits(CriteriaSet crs)
		{
// USE /[MANUAL AJF LIST_LIMITS 711]/

			return crs;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("contr", user, "AJF");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML711");
			conditions.Equal(CSGenioAcontr.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAcontr.FldCodcontr, CSGenioAcontr.FldZzstate, CSGenioAcontr.FldStartdat, CSGenioAcontr.FldComiseur, CSGenioAcontr.FldSalary, CSGenioAcontr.FldFindate, CSGenioAcontr.FldCtrdurat, CSGenioAcontr.FldCodplayr, CSGenioAplayr.FldCodplayr, CSGenioAplayr.FldName, CSGenioAcontr.FldTransval, CSGenioAcontr.FldCodclub, CSGenioAclub.FldCodclub, CSGenioAclub.FldName, CSGenioAcontr.FldCodagent, CSGenioAagent.FldCodagent, CSGenioAagent.FldEmail };

			ListingMVC<CSGenioAcontr> listing = new(fields, null, 1, 1, false, user, true, string.Empty, false);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

			// Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);




			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// </summary>
		[Obsolete("For deserialization only")]
		public AJF_Menu_711_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="AJF_Menu_711_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public AJF_Menu_711_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.AUTHORIZED;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="AJF_Menu_711_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public AJF_Menu_711_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAcontr.FldStartdat, FieldType.DATE, Resources.Resources.STARTING_DATE47975, 8, 0, true),
				new Exports.QColumn(CSGenioAcontr.FldComiseur, FieldType.CURRENCY, Resources.Resources.MONETARY_VALUE_COMIS27197, 10, 0, true),
				new Exports.QColumn(CSGenioAcontr.FldSalary, FieldType.CURRENCY, Resources.Resources.SALARY_OF_THE_PLAYER18170, 10, 0, true),
				new Exports.QColumn(CSGenioAcontr.FldFindate, FieldType.DATE, Resources.Resources.FINISH_DATE41863, 8, 0, true),
				new Exports.QColumn(CSGenioAcontr.FldCtrdurat, FieldType.NUMERIC, Resources.Resources.CONTRACT_DURATION31225, 2, 0, true),
				new Exports.QColumn(CSGenioAplayr.FldName, FieldType.TEXT, Resources.Resources.NAME_OF_THE_PLAYER61428, 30, 0, true),
				new Exports.QColumn(CSGenioAcontr.FldTransval, FieldType.NUMERIC, Resources.Resources.TRANSFER_VALUE12168, 10, 0, true),
				new Exports.QColumn(CSGenioAclub.FldName, FieldType.TEXT, Resources.Resources.CLUB_S_NAME65517, 30, 0, true),
				new Exports.QColumn(CSGenioAagent.FldEmail, FieldType.TEXT, Resources.Resources.AGENT_S_EMAIL56414, 30, 0, true),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioAcontr> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAcontr> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			listing = null;
			conditions = null;
			columns = this.GetExportColumns(tableConfig.ColumnConfiguration);

			// Store number of records to reset it after loading
			int rowsPerPage = tableConfig.RowsPerPage;
			tableConfig.RowsPerPage = -1;

			Load(tableConfig, requestValues, ajaxRequest, true, ref listing, ref conditions);

			// Reset number of records to original value
			tableConfig.RowsPerPage = rowsPerPage;
		}

		/// <inheritdoc/>
		public override CriteriaSet BuildCriteriaSet(NameValueCollection requestValues, out bool tableReload, CriteriaSet crs = null, bool isToExport = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new();
			return BuildCriteriaSet(tableConfig, requestValues, out tableReload, crs, isToExport);
		}

		/// <inheritdoc/>
		public override CriteriaSet BuildCriteriaSet(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, out bool tableReload, CriteriaSet crs = null, bool isToExport = false)
		{
			User u = m_userContext.User;
			tableReload = true;

			if (crs == null)
				crs = CriteriaSet.And();


			if (Menu == null)
				Menu = new TablePartial<AJF_Menu_711_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, false);


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfiguration), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();


			crs.SubSets.Add(subfilters);


			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Limitations
			if (isToExport)
			{
				// EPH
				crs = Models.Contr.AddEPH<CSGenioAcontr>(ref u, crs, "ML711");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAcontr.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("CONTR", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAcontr.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_contr");
				Navigation.DestroyEntry("QMVC_POS_RECORD_contr");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Contr.AddEPH<CSGenioAcontr>(ref u, null, "ML711"));
			}

			return crs;
		}

		/// <summary>
		/// Loads the list with the specified number of rows.
		/// </summary>
		/// <param name="numberListItems">The number of rows to load.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		public void Load(int numberListItems, bool ajaxRequest = false)
		{
			Load(numberListItems, new NameValueCollection(), ajaxRequest);
		}

		/// <summary>
		/// Loads the list with the specified number of rows.
		/// </summary>
		/// <param name="numberListItems">The number of rows to load.</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest = false, CriteriaSet conditions = null)
		{
			ListingMVC<CSGenioAcontr> listing = null;

			Load(numberListItems, requestValues, ajaxRequest, false, ref listing, ref conditions);
		}

		/// <summary>
		/// Loads the list with the specified number of rows.
		/// </summary>
		/// <param name="numberListItems">The number of rows to load.</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="isToExport">Whether the list is being loaded to be exported</param>
		/// <param name="Qlisting">The rows.</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAcontr> Qlisting, ref CriteriaSet conditions)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			tableConfig.RowsPerPage = numberListItems;

			Load(tableConfig, requestValues, ajaxRequest, isToExport, ref Qlisting, ref conditions);
		}

		/// <summary>
		/// Loads the table with the specified configuration.
		/// </summary>
		/// <param name="tableConfig">The table configuration object</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="isToExport">Whether the list is being loaded to be exported</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport = false, CriteriaSet conditions = null)
		{
			ListingMVC<CSGenioAcontr> listing = null;

			Load(tableConfig, requestValues, ajaxRequest, isToExport, ref listing, ref conditions);
		}

		/// <summary>
		/// Loads the table with the specified configuration.
		/// </summary>
		/// <param name="tableConfig">The table configuration object</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="isToExport">Whether the list is being loaded to be exported</param>
		/// <param name="Qlisting">The rows.</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAcontr> Qlisting, ref CriteriaSet conditions)
		{
			using (GenioDI.MetricsOtlp.RecordTime("menu_load_time", new List<KeyValuePair<string, object>>()
			{
				new("Menu", "711"),
				new("Module", "AJF")
			}, "ms", "Time to load the menu."))
			{
				User u = m_userContext.User;
				Menu = new TablePartial<AJF_Menu_711_RowViewModel>();

				CriteriaSet ajf_menu_711Conds = CriteriaSet.And();
				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("CONTR.STARTDAT", new OrderedDictionary());
				allSortOrders["CONTR.STARTDAT"].Add("CONTR.STARTDAT", "A");



				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "contr", allSortOrders);

				if (sorts == null || sorts.Count == 0)
				{
					sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAcontr.FldStartdat), SortOrder.Ascending));

				}

				FieldRef[] fields = new FieldRef[] { CSGenioAcontr.FldCodcontr, CSGenioAcontr.FldZzstate, CSGenioAcontr.FldStartdat, CSGenioAcontr.FldComiseur, CSGenioAcontr.FldSalary, CSGenioAcontr.FldFindate, CSGenioAcontr.FldCtrdurat, CSGenioAcontr.FldCodplayr, CSGenioAplayr.FldCodplayr, CSGenioAplayr.FldName, CSGenioAcontr.FldTransval, CSGenioAcontr.FldCodclub, CSGenioAclub.FldCodclub, CSGenioAclub.FldName, CSGenioAcontr.FldCodagent, CSGenioAagent.FldCodagent, CSGenioAagent.FldEmail };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					firstVisibleColumn ??= new FieldRef("contr", "startdat");
				}


				// Limitations
				this.tableLimits ??= [];
				// Comparer to check if limit is already present in tableLimits
				LimitComparer limitComparer = new();

				//Tooltip for EPHs affecting this viewmodel list
				{
					Limit limit = new Limit();
					limit.TipoLimite = LimitType.EPH;
					CSGenioAcontr model_limit_area = new CSGenioAcontr(m_userContext.User);
					List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML711");
					if (area_EPH_limits.Count > 0)
						this.tableLimits.AddRange(area_EPH_limits);
				}

				// Tooltips: Making a tooltip for each valid limitation: 1 Limit(s) detected.
				// Limit origin: menu 

				//Limit type: "SC"
				//Current Area = "CONTR"
				//1st Area Limit: "PLAYR"
				//1st Area Field: "UNDCTC"
				//1st Area Value: "1"
				{
					Limit limit = new Limit();
					limit.TipoLimite = LimitType.SC;
					limit.NaoAplicaSeNulo = false;
					CSGenioAplayr model_limit_area = new CSGenioAplayr(m_userContext.User);
					string limit_field = "undctc", limit_field_value = "1";
					object this_limit_field = Navigation.GetStrValue(limit_field_value);
					Limit_Filler(ref limit, model_limit_area, limit_field, limit_field_value, this_limit_field, LimitAreaType.AreaLimita);
					if (!this.tableLimits.Contains(limit, limitComparer)) //to avoid repetitions (i.e: DB and EPH applying same limit)
						this.tableLimits.Add(limit);
				}

				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(ajf_menu_711Conds);
				ajf_menu_711Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL AJF OVERRQ 711]/

				bool distinct = false;

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioAcontr>(m_userContext, false, ajf_menu_711Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML711", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL AJF OVERRQLSTEXP 711]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL AJF OVERRQLIST 711]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_contr");
					Navigation.DestroyEntry("QMVC_POS_RECORD_contr");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAcontr.GetInformation(), QMVC_POS_RECORD, sorts, ajf_menu_711Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioAcontr> listing = Models.ModelBase.Where<CSGenioAcontr>(m_userContext, distinct, ajf_menu_711Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML711", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;

					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapAJF_Menu_711(listing);

					Menu.Identifier = "ML711";
					Menu.Slots = new Dictionary<string, List<object>>();

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "ML711";

					Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);

					// Set table totalizers
					if (listing.Totalizers != null && listing.Totalizers.Count > 0)
						Menu.SetTotalizers(listing.Totalizers);
				}

				// Set table limits display property
				FillTableLimitsDisplayData();

				// Store table configuration so it gets sent to the client-side to be processed
				CurrentTableConfig = tableConfig;

				// Load the user table configuration names and default name
				LoadUserTableConfigNameProperties();
			}
		}

		private List<AJF_Menu_711_RowViewModel> MapAJF_Menu_711(ListingMVC<CSGenioAcontr> Qlisting)
		{
			List<AJF_Menu_711_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapAJF_Menu_711(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAcontr row
		/// to a AJF_Menu_711_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private AJF_Menu_711_RowViewModel MapAJF_Menu_711(CSGenioAcontr row)
		{
			var model = new AJF_Menu_711_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "contr":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "playr":
						model.Playr.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "club":
						model.Club.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "agent":
						model.Agent.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					default:
						break;
				}
			}

			model.InitRowData();

			return model;
		}

		/// <summary>
		/// Checks the loaded model for pending rows (zzsttate not 0).
		/// </summary>
		public bool CheckForZzstate()
		{
			if (Menu?.Elements == null)
				return false;

			return Menu.Elements.Any(row => row.ValZzstate != 0);
		}

		/// <summary>
		/// Sets the document field values to objects.
		/// </summary>
		/// <param name="listing">The rows</param>
		private void SetDocumentFields(ListingMVC<CSGenioAcontr> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Contr m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Contr m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL AJF VIEWMODEL_CUSTOM AJF_MENU_711]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Contr", "Contr.ValCodcontr", "Contr.ValZzstate", "Contr.ValStartdat", "Contr.ValComiseur", "Contr.ValSalary", "Contr.ValFindate", "Contr.ValCtrdurat", "Playr", "Playr.ValName", "Contr.ValTransval", "Club", "Club.ValName", "Agent", "Agent.ValEmail", "Contr.ValCodagent", "Contr.ValCodclub", "Contr.ValCodplayr"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValStartdat", CSGenioAcontr.FldStartdat, typeof(DateTime?)),
			new TableSearchColumn("ValComiseur", CSGenioAcontr.FldComiseur, typeof(decimal?)),
			new TableSearchColumn("ValSalary", CSGenioAcontr.FldSalary, typeof(decimal?)),
			new TableSearchColumn("ValFindate", CSGenioAcontr.FldFindate, typeof(DateTime?)),
			new TableSearchColumn("ValCtrdurat", CSGenioAcontr.FldCtrdurat, typeof(decimal?)),
			new TableSearchColumn("Playr_ValName", CSGenioAplayr.FldName, typeof(string)),
			new TableSearchColumn("ValTransval", CSGenioAcontr.FldTransval, typeof(decimal?)),
			new TableSearchColumn("Club_ValName", CSGenioAclub.FldName, typeof(string)),
			new TableSearchColumn("Agent_ValEmail", CSGenioAagent.FldEmail, typeof(string)),
		];
	}
}
