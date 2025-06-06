using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace GenioMVC.Models
{
	public class Club : ModelBase
	{
		[JsonIgnore]
		public CSGenioAclub klass { get { return baseklass as CSGenioAclub; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Club.ValCodclub")]
		public string ValCodclub { get { return klass.ValCodclub; } set { klass.ValCodclub = value; } }

		[DisplayName("Club's Name")]
		/// <summary>Field : "Club's Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Club.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Fk_country")]
		/// <summary>Field : "Fk_country" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Club.ValCodcntry")]
		public string ValCodcntry { get { return klass.ValCodcntry; } set { klass.ValCodcntry = value; } }

		private Cntry _cntry;
		[DisplayName("Cntry")]
		[ShouldSerialize("Cntry")]
		public virtual Cntry Cntry
		{
			get
			{
				if (!isEmptyModel && (_cntry == null || (!string.IsNullOrEmpty(ValCodcntry) && (_cntry.isEmptyModel || _cntry.klass.QPrimaryKey != ValCodcntry))))
					_cntry = Models.Cntry.Find(ValCodcntry, m_userContext, Identifier, _fieldsToSerialize);
				_cntry ??= new Models.Cntry(m_userContext, true, _fieldsToSerialize);
				return _cntry;
			}
			set { _cntry = value; }
		}

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Club.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Club(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAclub(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Club(UserContext userContext, CSGenioAclub val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAclub csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "cntry":
						_cntry ??= new Cntry(m_userContext, true, _fieldsToSerialize);
						_cntry.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					default:
						break;
				}
			}
		}

		/// <summary>
		/// Search the row by key.
		/// </summary>
		/// <param name="id">The primary key.</param>
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Club Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAclub>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Club(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Club> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAclub>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Club>((r) => new Club(userCtx, r));
		}

// USE /[MANUAL AJF MODEL CLUB]/
	}
}
