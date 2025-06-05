

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using CSGenio.framework;
using CSGenio.persistence;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;
using System.Linq;

namespace CSGenio.business
{
	/// <summary>
	/// Contract
	/// </summary>
	public class CSGenioAcontr : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAcontr(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL AJF CONSTRUTOR CONTR]/
		}

		public CSGenioAcontr(User user) : this(user, user.CurrentModule)
		{
		}

		/// <summary>
		/// Initializes the metadata relative to the fields of this area
		/// </summary>
		private static void InicializaCampos(AreaInfo info)
		{
			Field Qfield = null;
#pragma warning disable CS0168, S1481 // Variable is declared but never used
			List<ByAreaArguments> argumentsListByArea;
#pragma warning restore CS0168, S1481 // Variable is declared but never used
			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codcontr", FieldType.KEY_INT);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "startdat", FieldType.DATE);
			Qfield.FieldDescription = "Starting Date";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "STARTING_DATE47975";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "findate", FieldType.DATE);
			Qfield.FieldDescription = "Finish Date";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "FINISH_DATE41863";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "salary", FieldType.CURRENCY);
			Qfield.FieldDescription = "Salary of the player per month";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 5;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "SALARY_OF_THE_PLAYER18170";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codplayr", FieldType.KEY_INT);
			Qfield.FieldDescription = "FK_Player";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "FK_PLAYER18756";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codclub", FieldType.KEY_INT);
			Qfield.FieldDescription = "FK_Club";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "FK_CLUB57683";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codagent", FieldType.KEY_INT);
			Qfield.FieldDescription = "FK_Agent";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "FK_AGENT38232";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "transval", FieldType.NUMERIC);
			Qfield.FieldDescription = "Transfer Value";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "TRANSFER_VALUE12168";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "comiseur", FieldType.CURRENCY);
			Qfield.FieldDescription = "Monetary Value comissions through each transfer";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 7;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "TOTAL_EARN_THROUGH_C21845";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"transval"}, new int[] {0}, "contr", "codcontr"));
			Qfield.ShowWhen = new ConditionFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((decimal)args[0])>1;
			});
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"transval"}, new int[] {0}, "contr", "codcontr"));
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"perc_com"}, new int[] {1}, "agent", "codagent"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 2, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((decimal)args[0])*((decimal)args[1]);
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "ctrdurat", FieldType.NUMERIC);
			Qfield.FieldDescription = "Contract duration";
			Qfield.FieldSize =  2;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 2;
			Qfield.CavDesignation = "CONTRACT_YEARS11444";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"findate","startdat"}, new int[] {0,1}, "contr", "codcontr"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 2, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return GenFunctions.Year(((DateTime)args[0]))-GenFunctions.Year(((DateTime)args[1]));
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "slryyr", FieldType.CURRENCY);
			Qfield.FieldDescription = "Yearly Salary";
			Qfield.FieldSize =  12;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 9;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "YEARLY_SALARY01615";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"salary"}, new int[] {0}, "contr", "codcontr"));
			Qfield.ShowWhen = new ConditionFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((decimal)args[0])>1;
			});
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"salary"}, new int[] {0}, "contr", "codcontr"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return ((decimal)args[0])*12;
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "zzstate", FieldType.INTEGER);
			Qfield.FieldDescription = "Estado da ficha";
			info.RegisterFieldDB(Qfield);

		}

		/// <summary>
		/// Initializes metadata for paths direct to other areas
		/// </summary>
		private static void InicializaRelacoes(AreaInfo info)
		{
			// Daughters Relations
			//------------------------------

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("agent", new Relation("AJF", "ajfcontract", "contr", "codcontr", "codagent", "AJF", "ajfagente", "agent", "codagent", "codagent"));
			info.ParentTables.Add("club", new Relation("AJF", "ajfcontract", "contr", "codcontr", "codclub", "AJF", "ajfclub", "club", "codclub", "codclub"));
			info.ParentTables.Add("playr", new Relation("AJF", "ajfcontract", "contr", "codcontr", "codplayr", "AJF", "ajfplayer", "playr", "codplayr", "codplayr"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(3);
			info.Pathways.Add("club","club");
			info.Pathways.Add("agent","agent");
			info.Pathways.Add("playr","playr");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------
			//Actualiza as seguintes somas relacionadas:
			info.RelatedSumArgs = new List<RelatedSumArgument>();
			info.RelatedSumArgs.Add( new RelatedSumArgument("contr", "agent", "totcomis", "comiseur", '+', true));



			info.InternalOperationFields = new string[] {
			 "comiseur","ctrdurat","slryyr"
			};






			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAcontr()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="AJF";
			info.TableName="ajfcontract";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codcontr";
			info.HumanKeyName="codplayr,codclub,".TrimEnd(',');
			info.Alias="contr";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Contract";
			info.AreaPluralDesignation="Contracts";
			info.DescriptionCav="CONTRACT36364";

			//sincronização
			info.SyncIncrementalDateStart = TimeSpan.FromHours(8);
			info.SyncIncrementalDateEnd = TimeSpan.FromHours(23);
			info.SyncCompleteHour = TimeSpan.FromHours(0.5);
			info.SyncIncrementalPeriod = TimeSpan.FromHours(1);
			info.BatchSync = 100;
			info.SyncType = SyncType.Central;
            info.SolrList = new List<string>();
        	info.QueuesList = new List<GenioServer.business.QueueGenio>();





			//RS 22.03.2011 I separated in submetodos due to performance problems with the JIT in 64bits
			// that in very large projects took 2 minutes on the first call.
			// After a Microsoft analysis of the JIT algortimo it was revealed that it has a
			// complexity O(n*m) where n are the lines of code and m the number of variables of a function.
			// Tests have revealed that splitting into subfunctions cuts the JIT time by more than half by 64-bit.
			//------------------------------
			InicializaCampos(info);

			//------------------------------
			InicializaRelacoes(info);

			//------------------------------
			InicializaCaminhos(info);

			//------------------------------
			InicializaFormulas(info);

			// Automatic audit stamps in BD
            //------------------------------

            // Documents in DB
            //------------------------------

            // Historics
            //------------------------------

			// Duplication
			//------------------------------

			// Ephs
			//------------------------------
			info.Ephs=new Hashtable();

			// Table minimum roles and access levels
			//------------------------------
            info.QLevel = new QLevel();
            info.QLevel.Query = Role.AUTHORIZED;
            info.QLevel.Create = Role.AUTHORIZED;
            info.QLevel.AlterAlways = Role.AUTHORIZED;
            info.QLevel.RemoveAlways = Role.AUTHORIZED;

      		return info;
		}

		/// <summary>
		/// Meta-information about this area
		/// </summary>
		public override AreaInfo Information
		{
			get { return informacao; }
		}
		/// <summary>
		/// Meta-information about this area
		/// </summary>
		public static AreaInfo GetInformation()
		{
			return informacao;
		}

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public static FieldRef FldCodcontr { get { return m_fldCodcontr; } }
		private static FieldRef m_fldCodcontr = new FieldRef("contr", "codcontr");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodcontr
		{
			get { return (string)returnValueField(FldCodcontr); }
			set { insertNameValueField(FldCodcontr, value); }
		}

		/// <summary>Field : "Starting Date" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldStartdat { get { return m_fldStartdat; } }
		private static FieldRef m_fldStartdat = new FieldRef("contr", "startdat");

		/// <summary>Field : "Starting Date" Tipo: "D" Formula:  ""</summary>
		public DateTime ValStartdat
		{
			get { return (DateTime)returnValueField(FldStartdat); }
			set { insertNameValueField(FldStartdat, value); }
		}

		/// <summary>Field : "Finish Date" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldFindate { get { return m_fldFindate; } }
		private static FieldRef m_fldFindate = new FieldRef("contr", "findate");

		/// <summary>Field : "Finish Date" Tipo: "D" Formula:  ""</summary>
		public DateTime ValFindate
		{
			get { return (DateTime)returnValueField(FldFindate); }
			set { insertNameValueField(FldFindate, value); }
		}

		/// <summary>Field : "Salary of the player per month" Tipo: "$" Formula:  ""</summary>
		public static FieldRef FldSalary { get { return m_fldSalary; } }
		private static FieldRef m_fldSalary = new FieldRef("contr", "salary");

		/// <summary>Field : "Salary of the player per month" Tipo: "$" Formula:  ""</summary>
		public decimal ValSalary
		{
			get { return (decimal)returnValueField(FldSalary); }
			set { insertNameValueField(FldSalary, value); }
		}

		/// <summary>Field : "FK_Player" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodplayr { get { return m_fldCodplayr; } }
		private static FieldRef m_fldCodplayr = new FieldRef("contr", "codplayr");

		/// <summary>Field : "FK_Player" Tipo: "CE" Formula:  ""</summary>
		public string ValCodplayr
		{
			get { return (string)returnValueField(FldCodplayr); }
			set { insertNameValueField(FldCodplayr, value); }
		}

		/// <summary>Field : "FK_Club" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodclub { get { return m_fldCodclub; } }
		private static FieldRef m_fldCodclub = new FieldRef("contr", "codclub");

		/// <summary>Field : "FK_Club" Tipo: "CE" Formula:  ""</summary>
		public string ValCodclub
		{
			get { return (string)returnValueField(FldCodclub); }
			set { insertNameValueField(FldCodclub, value); }
		}

		/// <summary>Field : "FK_Agent" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodagent { get { return m_fldCodagent; } }
		private static FieldRef m_fldCodagent = new FieldRef("contr", "codagent");

		/// <summary>Field : "FK_Agent" Tipo: "CE" Formula:  ""</summary>
		public string ValCodagent
		{
			get { return (string)returnValueField(FldCodagent); }
			set { insertNameValueField(FldCodagent, value); }
		}

		/// <summary>Field : "Transfer Value" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldTransval { get { return m_fldTransval; } }
		private static FieldRef m_fldTransval = new FieldRef("contr", "transval");

		/// <summary>Field : "Transfer Value" Tipo: "N" Formula:  ""</summary>
		public decimal ValTransval
		{
			get { return (decimal)returnValueField(FldTransval); }
			set { insertNameValueField(FldTransval, value); }
		}

		/// <summary>Field : "Monetary Value comissions through each transfer" Tipo: "$" Formula: + "[CONTR->TRANSVAL]*[AGENT->PERC_COM]"</summary>
		public static FieldRef FldComiseur { get { return m_fldComiseur; } }
		private static FieldRef m_fldComiseur = new FieldRef("contr", "comiseur");

		/// <summary>Field : "Monetary Value comissions through each transfer" Tipo: "$" Formula: + "[CONTR->TRANSVAL]*[AGENT->PERC_COM]"</summary>
		public decimal ValComiseur
		{
			get { return (decimal)returnValueField(FldComiseur); }
			set { insertNameValueField(FldComiseur, value); }
		}

		/// <summary>Field : "Contract duration" Tipo: "N" Formula: + "Year([CONTR->FINDATE]) - Year([CONTR->STARTDAT])"</summary>
		public static FieldRef FldCtrdurat { get { return m_fldCtrdurat; } }
		private static FieldRef m_fldCtrdurat = new FieldRef("contr", "ctrdurat");

		/// <summary>Field : "Contract duration" Tipo: "N" Formula: + "Year([CONTR->FINDATE]) - Year([CONTR->STARTDAT])"</summary>
		public decimal ValCtrdurat
		{
			get { return (decimal)returnValueField(FldCtrdurat); }
			set { insertNameValueField(FldCtrdurat, value); }
		}

		/// <summary>Field : "Yearly Salary" Tipo: "$" Formula: + "[CONTR->SALARY]*12"</summary>
		public static FieldRef FldSlryyr { get { return m_fldSlryyr; } }
		private static FieldRef m_fldSlryyr = new FieldRef("contr", "slryyr");

		/// <summary>Field : "Yearly Salary" Tipo: "$" Formula: + "[CONTR->SALARY]*12"</summary>
		public decimal ValSlryyr
		{
			get { return (decimal)returnValueField(FldSlryyr); }
			set { insertNameValueField(FldSlryyr, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("contr", "zzstate");



		/// <summary>Field : "ZZSTATE" Type: "INT"</summary>
		public int ValZzstate
		{
			get { return (int)returnValueField(FldZzstate); }
			set { insertNameValueField(FldZzstate, value); }
		}

        /// <summary>
        /// Obtains a partially populated area with the record corresponding to a primary key
        /// </summary>
        /// <param name="sp">Persistent support from where to get the registration</param>
        /// <param name="key">The value of the primary key</param>
        /// <param name="user">The context of the user</param>
        /// <param name="fields">The fields to be filled in the area</param>
        /// <returns>An area with the fields requests of the record read or null if the key does not exist</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static CSGenioAcontr search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAcontr area = new CSGenioAcontr(user, user.CurrentModule);

            if (sp.getRecord(area, key, fields))
                return area;
			return null;
        }


		public static string GetkeyFromControlledRecord(PersistentSupport sp, string ID, User user)
		{
			if (informacao.ControlledRecords != null)
				return informacao.ControlledRecords.GetPrimaryKeyFromControlledRecord(sp, user, ID);
			return String.Empty;
		}


        /// <summary>
        /// Search for all records of this area that comply with a condition
        /// </summary>
        /// <param name="sp">Persistent support from where to get the list</param>
        /// <param name="user">The context of the user</param>
        /// <param name="where">The search condition for the records. Use null to get all records</param>
        /// <param name="fields">The fields to be filled in the area</param>
        /// <param name="distinct">Get distinct from fields</param>
        /// <param name="noLock">NOLOCK</param>
        /// <returns>A list of area records with all fields populated</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static List<CSGenioAcontr> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAcontr>(where, user, fields, distinct, noLock);
        }



       	/// <summary>
        /// Search for all records of this area that comply with a condition
        /// </summary>
        /// <param name="sp">Persistent support from where to get the list</param>
        /// <param name="user">The context of the user</param>
        /// <param name="where">The search condition for the records. Use null to get all records</param>
        /// <param name="listing">List configuration</param>
        /// <returns>A list of area records with all fields populated</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAcontr> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAcontr>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL AJF TABAUX CONTR]/

 

            

	}
}
