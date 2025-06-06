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
	public class Playr : ModelBase
	{
		[JsonIgnore]
		public CSGenioAplayr klass { get { return baseklass as CSGenioAplayr; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "PK Player" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Playr.ValCodplayr")]
		public string ValCodplayr { get { return klass.ValCodplayr; } set { klass.ValCodplayr = value; } }

		[DisplayName("Name of the player")]
		/// <summary>Field : "Name of the player" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Playr.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Birthdate")]
		/// <summary>Field : "Birthdate" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Playr.ValBirthdat")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValBirthdat { get { return klass.ValBirthdat; } set { klass.ValBirthdat = value ?? DateTime.MinValue; } }

		[DisplayName("Country")]
		/// <summary>Field : "Country" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Playr.ValCountry")]
		public string ValCountry { get { return klass.ValCountry; } set { klass.ValCountry = value; } }

		[DisplayName("Position")]
		/// <summary>Field : "Position" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Playr.ValPosic")]
		public string ValPosic { get { return klass.ValPosic; } set { klass.ValPosic = value; } }

		[DisplayName("FK_Agente")]
		/// <summary>Field : "FK_Agente" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Playr.ValCodagent")]
		public string ValCodagent { get { return klass.ValCodagent; } set { klass.ValCodagent = value; } }

		private Agent _agent;
		[DisplayName("Agent")]
		[ShouldSerialize("Agent")]
		public virtual Agent Agent
		{
			get
			{
				if (!isEmptyModel && (_agent == null || (!string.IsNullOrEmpty(ValCodagent) && (_agent.isEmptyModel || _agent.klass.QPrimaryKey != ValCodagent))))
					_agent = Models.Agent.Find(ValCodagent, m_userContext, Identifier, _fieldsToSerialize);
				_agent ??= new Models.Agent(m_userContext, true, _fieldsToSerialize);
				return _agent;
			}
			set { _agent = value; }
		}

		[DisplayName("Player's Age")]
		/// <summary>Field : "Player's Age" Tipo: "N" Formula: + "Year([Today])- Year([PLAYR->BIRTHDAT])"</summary>
		[ShouldSerialize("Playr.ValAge")]
		[NumericAttribute(0)]
		public decimal? ValAge { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValAge, 0)); } set { klass.ValAge = Convert.ToDecimal(value); } }

		[DisplayName("Gender")]
		/// <summary>Field : "Gender" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Playr.ValGender")]
		[DataArray("Gender", GenioMVC.Helpers.ArrayType.Character)]
		public string ValGender { get { return klass.ValGender; } set { klass.ValGender = value; } }
		[JsonIgnore]
		public SelectList ArrayValgender { get { return new SelectList(CSGenio.business.ArrayGender.GetDictionary(), "Key", "Value", ValGender); } set { ValGender = value.SelectedValue as string; } }

		[DisplayName("Under Contract?")]
		/// <summary>Field : "Under Contract?" Tipo: "AL" Formula:  ""</summary>
		[ShouldSerialize("Playr.ValUndctc")]
		[DataArray("Undercontract", GenioMVC.Helpers.ArrayType.Logical)]
		public int ValUndctc { get { return klass.ValUndctc; } set { klass.ValUndctc = value; } }
		[JsonIgnore]
		public SelectList ArrayValundctc { get { return new SelectList(CSGenio.business.ArrayUndercontract.GetDictionary(), "Key", "Value", ValUndctc); } set { ValUndctc = (int)value.SelectedValue; } }

		[DisplayName("Fk_country")]
		/// <summary>Field : "Fk_country" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Playr.ValCodcntry")]
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
		[ShouldSerialize("Playr.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Playr(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAplayr(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Playr(UserContext userContext, CSGenioAplayr val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAplayr csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "agent":
						_agent ??= new Agent(m_userContext, true, _fieldsToSerialize);
						_agent.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
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
		public static Playr Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAplayr>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Playr(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Playr> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAplayr>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Playr>((r) => new Playr(userCtx, r));
		}

// USE /[MANUAL AJF MODEL PLAYR]/
	}
}
