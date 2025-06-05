using System;
using CSGenio.framework;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using CSGenio.persistence;
using System.Text;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace CSGenio.business
{
	/// <summary>
	/// Summary description for CSArea.
	/// </summary>
	public class CSGenioAprmfrm : DbArea
	{
	    /// <summary>
		/// Meta-informa��o sobre esta �rea
		/// </summary>
		protected static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAprmfrm(User user,string module)
		{
            this.user = user;
            this.module = module;
		}
	
		public CSGenioAprmfrm(User user) : this(user, user.CurrentModule)
		{
		}
	
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();
			
			/*Information das areas*/
			info.TableName = "ajfprmfrm";
			info.ShadowTabName = "";
			info.PrimaryKeyName = "codprmfrm";
            info.HumanKeyName = "codprmfrm";
			info.ShadowTabKeyName = "";
			info.Alias = "prmfrm";
			info.IsDomain =  true;
			info.AreaDesignation = "Permiss�o por form";
			info.AreaPluralDesignation = "Permiss�es por form";
			info.DescriptionCav = "Permiss�o por form";
			
			//sincroniza��o
			info.SyncIncrementalDateStart = TimeSpan.FromHours(9.0);
			info.SyncIncrementalDateEnd = TimeSpan.FromHours(23.0);
			info.SyncCompleteHour = TimeSpan.FromHours(1.0);
			info.SyncIncrementalPeriod = TimeSpan.FromHours(1);
			info.BatchSync = 100;
			info.SyncType = SyncType.Central;
					
			info.RegisterFieldDB(new Field(info.Alias, "codprmfrm", FieldType.KEY_INT));
			info.RegisterFieldDB(new Field(info.Alias, "autoriza", FieldType.TEXT));
			info.RegisterFieldDB(new Field(info.Alias, "comprova", FieldType.TEXT));
			info.RegisterFieldDB(new Field(info.Alias, "mensag1", FieldType.TEXT));
			info.RegisterFieldDB(new Field(info.Alias, "mensag2", FieldType.TEXT));
			info.RegisterFieldDB(new Field(info.Alias, "mensag3", FieldType.TEXT));
			info.RegisterFieldDB(new Field(info.Alias, "mensag4", FieldType.TEXT));
			info.RegisterFieldDB(new Field(info.Alias, "prazodia", FieldType.NUMERIC));
			info.RegisterFieldDB(new Field(info.Alias, "prazohor", FieldType.NUMERIC));
			info.RegisterFieldDB(new Field(info.Alias, "prfvalid", FieldType.TEXT));
			info.RegisterFieldDB(new Field(info.Alias, "secompro", FieldType.LOGIC));
			info.RegisterFieldDB(new Field(info.Alias, "sevalida", FieldType.LOGIC));

			// Rela��es Filhas
			//------------------------------

			// Rela��es M�e
			//------------------------------

			// Pathways
			//------------------------------

			// Levels de acesso
			//------------------------------
			info.QLevel = new QLevel();
			info.QLevel.Query = Role.UNAUTHORIZED;
			info.QLevel.Create = Role.UNAUTHORIZED;
			info.QLevel.AlterAlways = Role.UNAUTHORIZED;
			info.QLevel.RemoveAlways = Role.UNAUTHORIZED;

			// Automatic audit stamps in BD
            //------------------------------


			return info;
		}
		
		/// <summary>
		/// Meta-informa��o sobre esta �rea
		/// </summary>
		public override AreaInfo Information
		{
			get { return informacao; }
		}
		/// <summary>
		/// Meta-informa��o sobre esta �rea
		/// </summary>		
		public static AreaInfo GetInformation()
		{
			return informacao;
		}

		// USE /[MANUAL AJF TABAUX PRMFRM]/

		
	}
}
