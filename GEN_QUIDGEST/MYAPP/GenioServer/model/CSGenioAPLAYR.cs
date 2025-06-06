

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
	/// Player
	/// </summary>
	public class CSGenioAplayr : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAplayr(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL AJF CONSTRUTOR PLAYR]/
		}

		public CSGenioAplayr(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codplayr", FieldType.KEY_INT);
			Qfield.FieldDescription = "PK Player";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "PK_PLAYER25733";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "name", FieldType.TEXT);
			Qfield.FieldDescription = "Name of the player";
			Qfield.FieldSize =  85;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "NAME_OF_THE_PLAYER61428";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "birthdat", FieldType.DATE);
			Qfield.FieldDescription = "Birthdate";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "BIRTHDATE22743";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "country", FieldType.TEXT);
			Qfield.FieldDescription = "Country";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "COUNTRY64133";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "posic", FieldType.TEXT);
			Qfield.FieldDescription = "Position";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "POSICAO07486";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "age", FieldType.NUMERIC);
			Qfield.FieldDescription = "Player's Age";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 3;
			Qfield.CavDesignation = "PLAYER_S_AGE12664";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"birthdat"}, new int[] {0}, "playr", "codplayr"));
			Qfield.Formula = new InternalOperationFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return GenFunctions.Year(DateTime.Today)-GenFunctions.Year(((DateTime)args[0]));
			});
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "gender", FieldType.ARRAY_TEXT);
			Qfield.FieldDescription = "Gender";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "GENDER44172";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCgender";
            Qfield.ArrayClassName = "Gender";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "undctc", FieldType.ARRAY_LOGIC);
			Qfield.FieldDescription = "Under Contract?";
			Qfield.FieldSize =  1;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "UNDER_CONTRACT_12632";

			Qfield.Dupmsg = "";
			Qfield.ArrayName = "dbo.GetValArrayLundercontract";
            Qfield.ArrayClassName = "Undercontract";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codcntry", FieldType.KEY_INT);
			Qfield.FieldDescription = "Fk_country";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "FK_COUNTRY04348";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codagent", FieldType.KEY_INT);
			Qfield.FieldDescription = "fk_agente";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "FK_AGENTE28643";

			Qfield.Dupmsg = "";
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
			info.ChildTable = new ChildRelation[1];
			info.ChildTable[0]= new ChildRelation("contr", new String[] {"codplayr"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("agent", new Relation("AJF", "ajfplayer", "playr", "codplayr", "codagent", "AJF", "ajfagente", "agent", "codagent", "codagent"));
			info.ParentTables.Add("cntry", new Relation("AJF", "ajfplayer", "playr", "codplayr", "codcntry", "AJF", "ajfcountry", "cntry", "codcntry", "codcntry"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(2);
			info.Pathways.Add("agent","agent");
			info.Pathways.Add("cntry","cntry");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			info.InternalOperationFields = new string[] {
			 "age"
			};






			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAplayr()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="AJF";
			info.TableName="ajfplayer";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codplayr";
			info.HumanKeyName="name,birthdat,".TrimEnd(',');
			info.Alias="playr";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Player";
			info.AreaPluralDesignation="Players";
			info.DescriptionCav="PLAYER57424";

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

		/// <summary>Field : "PK Player" Tipo: "+" Formula:  ""</summary>
		public static FieldRef FldCodplayr { get { return m_fldCodplayr; } }
		private static FieldRef m_fldCodplayr = new FieldRef("playr", "codplayr");

		/// <summary>Field : "PK Player" Tipo: "+" Formula:  ""</summary>
		public string ValCodplayr
		{
			get { return (string)returnValueField(FldCodplayr); }
			set { insertNameValueField(FldCodplayr, value); }
		}

		/// <summary>Field : "Name of the player" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldName { get { return m_fldName; } }
		private static FieldRef m_fldName = new FieldRef("playr", "name");

		/// <summary>Field : "Name of the player" Tipo: "C" Formula:  ""</summary>
		public string ValName
		{
			get { return (string)returnValueField(FldName); }
			set { insertNameValueField(FldName, value); }
		}

		/// <summary>Field : "Birthdate" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldBirthdat { get { return m_fldBirthdat; } }
		private static FieldRef m_fldBirthdat = new FieldRef("playr", "birthdat");

		/// <summary>Field : "Birthdate" Tipo: "D" Formula:  ""</summary>
		public DateTime ValBirthdat
		{
			get { return (DateTime)returnValueField(FldBirthdat); }
			set { insertNameValueField(FldBirthdat, value); }
		}

		/// <summary>Field : "Country" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldCountry { get { return m_fldCountry; } }
		private static FieldRef m_fldCountry = new FieldRef("playr", "country");

		/// <summary>Field : "Country" Tipo: "C" Formula:  ""</summary>
		public string ValCountry
		{
			get { return (string)returnValueField(FldCountry); }
			set { insertNameValueField(FldCountry, value); }
		}

		/// <summary>Field : "Position" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldPosic { get { return m_fldPosic; } }
		private static FieldRef m_fldPosic = new FieldRef("playr", "posic");

		/// <summary>Field : "Position" Tipo: "C" Formula:  ""</summary>
		public string ValPosic
		{
			get { return (string)returnValueField(FldPosic); }
			set { insertNameValueField(FldPosic, value); }
		}

		/// <summary>Field : "Player's Age" Tipo: "N" Formula: + "Year([Today])- Year([PLAYR->BIRTHDAT])"</summary>
		public static FieldRef FldAge { get { return m_fldAge; } }
		private static FieldRef m_fldAge = new FieldRef("playr", "age");

		/// <summary>Field : "Player's Age" Tipo: "N" Formula: + "Year([Today])- Year([PLAYR->BIRTHDAT])"</summary>
		public decimal ValAge
		{
			get { return (decimal)returnValueField(FldAge); }
			set { insertNameValueField(FldAge, value); }
		}

		/// <summary>Field : "Gender" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldGender { get { return m_fldGender; } }
		private static FieldRef m_fldGender = new FieldRef("playr", "gender");

		/// <summary>Field : "Gender" Tipo: "AC" Formula:  ""</summary>
		public string ValGender
		{
			get { return (string)returnValueField(FldGender); }
			set { insertNameValueField(FldGender, value); }
		}

		/// <summary>Field : "Under Contract?" Tipo: "AL" Formula:  ""</summary>
		public static FieldRef FldUndctc { get { return m_fldUndctc; } }
		private static FieldRef m_fldUndctc = new FieldRef("playr", "undctc");

		/// <summary>Field : "Under Contract?" Tipo: "AL" Formula:  ""</summary>
		public int ValUndctc
		{
			get { return (int)returnValueField(FldUndctc); }
			set { insertNameValueField(FldUndctc, value); }
		}

		/// <summary>Field : "Fk_country" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodcntry { get { return m_fldCodcntry; } }
		private static FieldRef m_fldCodcntry = new FieldRef("playr", "codcntry");

		/// <summary>Field : "Fk_country" Tipo: "CE" Formula:  ""</summary>
		public string ValCodcntry
		{
			get { return (string)returnValueField(FldCodcntry); }
			set { insertNameValueField(FldCodcntry, value); }
		}

		/// <summary>Field : "fk_agente" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodagent { get { return m_fldCodagent; } }
		private static FieldRef m_fldCodagent = new FieldRef("playr", "codagent");

		/// <summary>Field : "fk_agente" Tipo: "CE" Formula:  ""</summary>
		public string ValCodagent
		{
			get { return (string)returnValueField(FldCodagent); }
			set { insertNameValueField(FldCodagent, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("playr", "zzstate");



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
        public static CSGenioAplayr search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAplayr area = new CSGenioAplayr(user, user.CurrentModule);

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
        public static List<CSGenioAplayr> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAplayr>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAplayr> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAplayr>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL AJF TABAUX PLAYR]/

 

           

	}
}
