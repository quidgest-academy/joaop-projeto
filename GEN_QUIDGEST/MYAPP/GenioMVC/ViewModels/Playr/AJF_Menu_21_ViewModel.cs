﻿using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;
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

namespace GenioMVC.ViewModels.Playr
{
	public class AJF_Menu_21_ViewModel : MenuListViewModel<Models.Playr>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("Table")]
		public TablePartial<AJF_Menu_21_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "playr";

		/// <inheritdoc/>
		public override string Uuid => "2d3723f4-da2d-4f44-8217-12f42ba20e02";

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
// USE /[MANUAL AJF LIST_LIMITS 21]/

			return crs;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("playr", user, "AJF");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML21");
			conditions.Equal(CSGenioAplayr.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAplayr.FldCodplayr, CSGenioAplayr.FldZzstate, CSGenioAplayr.FldAge, CSGenioAplayr.FldPosic, CSGenioAplayr.FldBirthdat, CSGenioAplayr.FldGender, CSGenioAplayr.FldCountry, CSGenioAplayr.FldName, CSGenioAplayr.FldCodagent, CSGenioAagent.FldCodagent, CSGenioAagent.FldEmail };

			ListingMVC<CSGenioAplayr> listing = new(fields, null, 1, 1, false, user, true, string.Empty, true);
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
		public AJF_Menu_21_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="AJF_Menu_21_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public AJF_Menu_21_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_50;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="AJF_Menu_21_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public AJF_Menu_21_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport(bool ajaxRequest = false)
		{
			var columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAplayr.FldAge, FieldType.NUMERIC, Resources.Resources.PLAYER_S_AGE12664, 3, 0, true),
				new Exports.QColumn(CSGenioAplayr.FldPosic, FieldType.TEXT, Resources.Resources.POSITION54869, 30, 0, true),
				new Exports.QColumn(CSGenioAplayr.FldBirthdat, FieldType.DATE, Resources.Resources.BIRTHDATE22743, 8, 0, true),
				new Exports.QColumn(CSGenioAplayr.FldGender, FieldType.ARRAY_TEXT, Resources.Resources.GENDER44172, 1, 0, true, "Gender"),
				new Exports.QColumn(CSGenioAplayr.FldCountry, FieldType.TEXT, Resources.Resources.COUNTRY64133, 30, 0, true),
				new Exports.QColumn(CSGenioAplayr.FldName, FieldType.TEXT, Resources.Resources.NAME_OF_THE_PLAYER61428, 30, 0, true),
				new Exports.QColumn(CSGenioAagent.FldEmail, FieldType.TEXT, Resources.Resources.AGENT_S_EMAIL56414, 30, 0, true),
			};

			columns.RemoveAll(item => item == null);
			return columns;
		}

		public void LoadToExport(out ListingMVC<CSGenioAplayr> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.framework.TableConfiguration.TableConfiguration tableConfig = new CSGenio.framework.TableConfiguration.TableConfiguration();

			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAplayr> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
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

		/// <summary>
		/// Loads the viewmodel to export a template.
		/// </summary>
		/// <param name="columns">The columns.</param>
		public void LoadToExportTemplate(out List<Exports.QColumn> columns)
		{
			columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAplayr.FldName, FieldType.TEXT, Resources.Resources.NAME_OF_THE_PLAYER61428, 85, 0, true),
				new Exports.QColumn(CSGenioAplayr.FldBirthdat, FieldType.DATE, Resources.Resources.BIRTHDATE22743, 8, 0, true),
				new Exports.QColumn(CSGenioAplayr.FldCountry, FieldType.TEXT, Resources.Resources.COUNTRY64133, 50, 0, true),
				new Exports.QColumn(CSGenioAplayr.FldPosic, FieldType.TEXT, Resources.Resources.POSITION54869, 50, 0, true),
				new Exports.QColumn(CSGenioAplayr.FldGender, FieldType.ARRAY_TEXT, Resources.Resources.GENDER44172, 1, 0, true),
				new Exports.QColumn(CSGenioAplayr.FldUndctc, FieldType.ARRAY_LOGIC, Resources.Resources.UNDER_CONTRACT_12632, 1, 0, true),
				new Exports.QColumn(CSGenioAagent.FldEmail, FieldType.TEXT, Resources.Resources.AGENT_S_EMAIL56414, 30, 0, true),
			};
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
				Menu = new TablePartial<AJF_Menu_21_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, true);


			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfiguration), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			if (!tableConfig.StaticFilters.ContainsKey("filter_AJF_Menu_21_GENDER"))
				tableConfig.StaticFilters.Add("filter_AJF_Menu_21_GENDER", null);

			{
				var groupFilters = CriteriaSet.Or();
				bool filter_AJF_Menu_21_GENDER_1 = false;
				if (tableConfig.StaticFilters["filter_AJF_Menu_21_GENDER"] != null)
					filter_AJF_Menu_21_GENDER_1 = tableConfig.StaticFilters["filter_AJF_Menu_21_GENDER"].Contains("1");
				if (filter_AJF_Menu_21_GENDER_1)
				{
					groupFilters.Equal(CSGenioAplayr.FldGender, "M");

				}

				bool filter_AJF_Menu_21_GENDER_2 = false;
				if (tableConfig.StaticFilters["filter_AJF_Menu_21_GENDER"] != null)
					filter_AJF_Menu_21_GENDER_2 = tableConfig.StaticFilters["filter_AJF_Menu_21_GENDER"].Contains("2");
				if (filter_AJF_Menu_21_GENDER_2)
				{
					groupFilters.Equal(CSGenioAplayr.FldGender, "F");

				}

				bool filter_AJF_Menu_21_GENDER_3 = false;
				if (tableConfig.StaticFilters["filter_AJF_Menu_21_GENDER"] != null)
					filter_AJF_Menu_21_GENDER_3 = tableConfig.StaticFilters["filter_AJF_Menu_21_GENDER"].Contains("3");
				if (filter_AJF_Menu_21_GENDER_3)
				{
					groupFilters.Equal(CSGenioAplayr.FldGender, "O");

				}

				subfilters.SubSets.Add(groupFilters);
			}

			crs.SubSets.Add(subfilters);


			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			if (isToExport)
			{
				// EPH
				crs = Models.Playr.AddEPH<CSGenioAplayr>(ref u, crs, "ML21");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAplayr.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("PLAYR", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAplayr.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_playr");
				Navigation.DestroyEntry("QMVC_POS_RECORD_playr");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Playr.AddEPH<CSGenioAplayr>(ref u, null, "ML21"));
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
			ListingMVC<CSGenioAplayr> listing = null;

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
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAplayr> Qlisting, ref CriteriaSet conditions)
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
			ListingMVC<CSGenioAplayr> listing = null;

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
		public void Load(CSGenio.framework.TableConfiguration.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAplayr> Qlisting, ref CriteriaSet conditions)
		{
			using (GenioDI.MetricsOtlp.RecordTime("menu_load_time", new List<KeyValuePair<string, object>>()
			{
				new("Menu", "21"),
				new("Module", "AJF")
			}, "ms", "Time to load the menu."))
			{
				User u = m_userContext.User;
				Menu = new TablePartial<AJF_Menu_21_RowViewModel>();

				CriteriaSet ajf_menu_21Conds = CriteriaSet.And();
				bool tableReload = true;

				//FOR: MENU LIST SORTING
				Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
				allSortOrders.Add("PLAYR.POSIC", new OrderedDictionary());
				allSortOrders["PLAYR.POSIC"].Add("PLAYR.POSIC", "A");



				int numberListItems = tableConfig.RowsPerPage;
				var pageNumber = ajaxRequest ? tableConfig.Page : 1;

				// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig.ColumnOrderBy, "playr", allSortOrders);

				if (sorts == null || sorts.Count == 0)
				{
					sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAplayr.FldPosic), SortOrder.Ascending));

				}

				FieldRef[] fields = new FieldRef[] { CSGenioAplayr.FldCodplayr, CSGenioAplayr.FldZzstate, CSGenioAplayr.FldAge, CSGenioAplayr.FldPosic, CSGenioAplayr.FldBirthdat, CSGenioAplayr.FldGender, CSGenioAplayr.FldCountry, CSGenioAplayr.FldName, CSGenioAplayr.FldCodagent, CSGenioAagent.FldCodagent, CSGenioAagent.FldEmail };


				// Totalizers
				List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

				FieldRef firstVisibleColumn = null;

				if (sorts == null)
				{
					firstVisibleColumn = tableConfig?.getFirstVisibleColumn(TableAlias);

					firstVisibleColumn ??= new FieldRef("playr", "age");
				}


				// Limitations
				this.tableLimits ??= [];
				// Comparer to check if limit is already present in tableLimits
				LimitComparer limitComparer = new();

				//Tooltip for EPHs affecting this viewmodel list
				{
					Limit limit = new Limit();
					limit.TipoLimite = LimitType.EPH;
					CSGenioAplayr model_limit_area = new CSGenioAplayr(m_userContext.User);
					List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML21");
					if (area_EPH_limits.Count > 0)
						this.tableLimits.AddRange(area_EPH_limits);
				}


				if (conditions == null)
					conditions = CriteriaSet.And();

				conditions.SubSets.Add(ajf_menu_21Conds);
				ajf_menu_21Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
				tableReload &= hasAllRequiredLimits;

// USE /[MANUAL AJF OVERRQ 21]/

				bool distinct = false;

				if (isToExport)
				{
					if (!tableReload)
						return;

					Qlisting = Models.ModelBase.Where<CSGenioAplayr>(m_userContext, false, ajf_menu_21Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML21", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL AJF OVERRQLSTEXP 21]/

					return;
				}

				if (tableReload)
				{
// USE /[MANUAL AJF OVERRQLIST 21]/

					string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_playr");
					Navigation.DestroyEntry("QMVC_POS_RECORD_playr");
					CriteriaSet m_PagingPosEPHs = null;

					if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					{
						var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAplayr.GetInformation(), QMVC_POS_RECORD, sorts, ajf_menu_21Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
						if (m_iCurPag != -1)
							pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
					}

					ListingMVC<CSGenioAplayr> listing = Models.ModelBase.Where<CSGenioAplayr>(m_userContext, distinct, ajf_menu_21Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML21", true, true, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

					if (listing.CurrentPage > 0)
						pageNumber = listing.CurrentPage;

					//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
					if (pageNumber < 1)
						pageNumber = 1;

					//Set document field values to objects
					SetDocumentFields(listing);

					Menu.Elements = MapAJF_Menu_21(listing);

					Menu.Identifier = "ML21";
					Menu.Slots = new Dictionary<string, List<object>>();

					// Last updated by [CJP] at [2015.02.03]
					// Adds the identifier to each element
					foreach (var element in Menu.Elements)
						element.Identifier = "ML21";

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

		private List<AJF_Menu_21_RowViewModel> MapAJF_Menu_21(ListingMVC<CSGenioAplayr> Qlisting)
		{
			List<AJF_Menu_21_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapAJF_Menu_21(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAplayr row
		/// to a AJF_Menu_21_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private AJF_Menu_21_RowViewModel MapAJF_Menu_21(CSGenioAplayr row)
		{
			var model = new AJF_Menu_21_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "playr":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
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
		private void SetDocumentFields(ListingMVC<CSGenioAplayr> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Playr m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Playr m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL AJF VIEWMODEL_CUSTOM AJF_MENU_21]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Playr", "Playr.ValCodplayr", "Playr.ValZzstate", "Playr.ValAge", "Playr.ValPosic", "Playr.ValBirthdat", "Playr.ValGender", "Playr.ValCountry", "Playr.ValName", "Agent", "Agent.ValEmail", "Playr.ValCodagent", "Playr.ValCodcntry"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValAge", CSGenioAplayr.FldAge, typeof(decimal?)),
			new TableSearchColumn("ValPosic", CSGenioAplayr.FldPosic, typeof(string)),
			new TableSearchColumn("ValBirthdat", CSGenioAplayr.FldBirthdat, typeof(DateTime?)),
			new TableSearchColumn("ValGender", CSGenioAplayr.FldGender, typeof(string), array : "Gender"),
			new TableSearchColumn("ValCountry", CSGenioAplayr.FldCountry, typeof(string)),
			new TableSearchColumn("ValName", CSGenioAplayr.FldName, typeof(string), defaultSearch : true),
			new TableSearchColumn("Agent_ValEmail", CSGenioAagent.FldEmail, typeof(string)),
		];
	}
}
