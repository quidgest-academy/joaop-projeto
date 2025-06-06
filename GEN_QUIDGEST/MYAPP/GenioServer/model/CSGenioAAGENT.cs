

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
	/// Agente
	/// </summary>
	public class CSGenioAagent : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAagent(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL AJF CONSTRUTOR AGENT]/
		}

		public CSGenioAagent(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codagent", FieldType.KEY_INT);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "name", FieldType.TEXT);
			Qfield.FieldDescription = "Agent´s Name";
			Qfield.FieldSize =  85;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "AGENTE_ID43487";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "photo", FieldType.IMAGE);
			Qfield.FieldDescription = "Photo's Agent";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "PHOTO_S_AGENT28065";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "email", FieldType.TEXT);
			Qfield.FieldDescription = "Agent's Email";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "AGENT_S_EMAIL56414";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "This email address is already register. Please select another one";
            Qfield.NotDup = true;
			Qfield.FillingRule = (rule) =>
			{
				return Validation.validateEM(rule);
			};
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "phone", FieldType.TEXT);
			Qfield.FieldDescription = "Agent's Phone";
			Qfield.FieldSize =  14;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "AGENT_S_PHONE23147";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
            Qfield.NotDup = true;
			Qfield.FillingRule = (rule) =>
			{
				string mask = "+000 000000000";
				string validation = "+000 000000000";
				return Validation.validateMP(rule, mask, validation);
			};
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "perc_com", FieldType.NUMERIC);
			Qfield.FieldDescription = "Percentage of the Comission";
			Qfield.FieldSize =  4;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 1;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "PERCENTAGE_OF_THE_CO01872";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "totcomis", FieldType.NUMERIC);
			Qfield.FieldDescription = "Total earn through comission";
			Qfield.FieldSize =  10;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 10;
			Qfield.CavDesignation = "TOTAL_GANHO_EM_COMIS04690";

			Qfield.Dupmsg = "";
			argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"perc_com"}, new int[] {0}, "agent", "codagent"));
			Qfield.BlockWhen = new ConditionFormula(argumentsListByArea, 1, delegate(object[] args, User user, string module, PersistentSupport sp) {
				return (((decimal)args[0]) == 0)==1;
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
			info.ChildTable = new ChildRelation[2];
			info.ChildTable[0]= new ChildRelation("playr", new String[] {"codagent"}, DeleteProc.NA);
			info.ChildTable[1]= new ChildRelation("contr", new String[] {"codagent"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(0);
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------




			info.RelatedSumFields = new string[] {
			 "totcomis"
			};





			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();

			// [AGENT->PERC_COM] > 0 && [AGENT->PERC_COM]< 1
			{
			List<ByAreaArguments> argumentsListByArea = new List<ByAreaArguments>();
			argumentsListByArea= new List<ByAreaArguments>();
			argumentsListByArea.Add(new ByAreaArguments(new string[] {"perc_com","perc_com"},new int[] {0,1},"agent","codagent"));
			ConditionFormula writeCondition = new ConditionFormula(argumentsListByArea, 2, delegate(object []args,User user,string module,PersistentSupport sp) {
				return ((decimal)args[0])>0&&((decimal)args[1])<1;
			});
			writeCondition.ErrorWarning = "Percentage must be between 0 and 1";
            writeCondition.Type =  ConditionType.ERROR;
            writeCondition.Validate = true;
			writeCondition.Field = info.DBFields["perc_com"];
			conditions.Add(writeCondition);
			}
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAagent()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="AJF";
			info.TableName="ajfagente";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codagent";
			info.HumanKeyName="email,phone,".TrimEnd(',');
			info.Alias="agent";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Agente";
			info.AreaPluralDesignation="Agentes";
			info.DescriptionCav="AGENTE44214";

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
		public static FieldRef FldCodagent { get { return m_fldCodagent; } }
		private static FieldRef m_fldCodagent = new FieldRef("agent", "codagent");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodagent
		{
			get { return (string)returnValueField(FldCodagent); }
			set { insertNameValueField(FldCodagent, value); }
		}

		/// <summary>Field : "Agent´s Name" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldName { get { return m_fldName; } }
		private static FieldRef m_fldName = new FieldRef("agent", "name");

		/// <summary>Field : "Agent´s Name" Tipo: "C" Formula:  ""</summary>
		public string ValName
		{
			get { return (string)returnValueField(FldName); }
			set { insertNameValueField(FldName, value); }
		}

		/// <summary>Field : "Photo's Agent" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldPhoto { get { return m_fldPhoto; } }
		private static FieldRef m_fldPhoto = new FieldRef("agent", "photo");

		/// <summary>Field : "Photo's Agent" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValPhoto
		{
			get { return (byte[])returnValueField(FldPhoto); }
			set { insertNameValueField(FldPhoto, value); }
		}

		/// <summary>Field : "Agent's Email" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldEmail { get { return m_fldEmail; } }
		private static FieldRef m_fldEmail = new FieldRef("agent", "email");

		/// <summary>Field : "Agent's Email" Tipo: "C" Formula:  ""</summary>
		public string ValEmail
		{
			get { return (string)returnValueField(FldEmail); }
			set { insertNameValueField(FldEmail, value); }
		}

		/// <summary>Field : "Agent's Phone" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldPhone { get { return m_fldPhone; } }
		private static FieldRef m_fldPhone = new FieldRef("agent", "phone");

		/// <summary>Field : "Agent's Phone" Tipo: "C" Formula:  ""</summary>
		public string ValPhone
		{
			get { return (string)returnValueField(FldPhone); }
			set { insertNameValueField(FldPhone, value); }
		}

		/// <summary>Field : "Percentage of the Comission" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldPerc_com { get { return m_fldPerc_com; } }
		private static FieldRef m_fldPerc_com = new FieldRef("agent", "perc_com");

		/// <summary>Field : "Percentage of the Comission" Tipo: "N" Formula:  ""</summary>
		public decimal ValPerc_com
		{
			get { return (decimal)returnValueField(FldPerc_com); }
			set { insertNameValueField(FldPerc_com, value); }
		}

		/// <summary>Field : "Total earn through comission" Tipo: "N" Formula: SR "[CONTR->COMISEUR]"</summary>
		public static FieldRef FldTotcomis { get { return m_fldTotcomis; } }
		private static FieldRef m_fldTotcomis = new FieldRef("agent", "totcomis");

		/// <summary>Field : "Total earn through comission" Tipo: "N" Formula: SR "[CONTR->COMISEUR]"</summary>
		public decimal ValTotcomis
		{
			get { return (decimal)returnValueField(FldTotcomis); }
			set { insertNameValueField(FldTotcomis, value); }
		}

		/// <summary>Field : "Gender" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldGender { get { return m_fldGender; } }
		private static FieldRef m_fldGender = new FieldRef("agent", "gender");

		/// <summary>Field : "Gender" Tipo: "AC" Formula:  ""</summary>
		public string ValGender
		{
			get { return (string)returnValueField(FldGender); }
			set { insertNameValueField(FldGender, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("agent", "zzstate");



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
        public static CSGenioAagent search(PersistentSupport sp, string key, User user, string[] fields = null)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAagent area = new CSGenioAagent(user, user.CurrentModule);

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
        public static List<CSGenioAagent> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAagent>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAagent> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAagent>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);




 


		// USE /[MANUAL AJF TABAUX AGENT]/

 

         

	}
}
