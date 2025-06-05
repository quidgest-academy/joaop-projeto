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
	public class Contr : ModelBase
	{
		[JsonIgnore]
		public CSGenioAcontr klass { get { return baseklass as CSGenioAcontr; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Contr.ValCodcontr")]
		public string ValCodcontr { get { return klass.ValCodcontr; } set { klass.ValCodcontr = value; } }

		[DisplayName("Starting Date")]
		/// <summary>Field : "Starting Date" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Contr.ValStartdat")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValStartdat { get { return klass.ValStartdat; } set { klass.ValStartdat = value ?? DateTime.MinValue; } }

		[DisplayName("Finish Date")]
		/// <summary>Field : "Finish Date" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Contr.ValFindate")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValFindate { get { return klass.ValFindate; } set { klass.ValFindate = value ?? DateTime.MinValue; } }

		[DisplayName("Salary of the player per month")]
		/// <summary>Field : "Salary of the player per month" Tipo: "$" Formula:  ""</summary>
		[ShouldSerialize("Contr.ValSalary")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValSalary { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValSalary, 2)); } set { klass.ValSalary = Convert.ToDecimal(value); } }

		[DisplayName("FK_Player")]
		/// <summary>Field : "FK_Player" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Contr.ValCodplayr")]
		public string ValCodplayr { get { return klass.ValCodplayr; } set { klass.ValCodplayr = value; } }

		private Playr _playr;
		[DisplayName("Playr")]
		[ShouldSerialize("Playr")]
		public virtual Playr Playr
		{
			get
			{
				if (!isEmptyModel && (_playr == null || (!string.IsNullOrEmpty(ValCodplayr) && (_playr.isEmptyModel || _playr.klass.QPrimaryKey != ValCodplayr))))
					_playr = Models.Playr.Find(ValCodplayr, m_userContext, Identifier, _fieldsToSerialize);
				_playr ??= new Models.Playr(m_userContext, true, _fieldsToSerialize);
				return _playr;
			}
			set { _playr = value; }
		}

		[DisplayName("FK_Club")]
		/// <summary>Field : "FK_Club" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Contr.ValCodclub")]
		public string ValCodclub { get { return klass.ValCodclub; } set { klass.ValCodclub = value; } }

		private Club _club;
		[DisplayName("Club")]
		[ShouldSerialize("Club")]
		public virtual Club Club
		{
			get
			{
				if (!isEmptyModel && (_club == null || (!string.IsNullOrEmpty(ValCodclub) && (_club.isEmptyModel || _club.klass.QPrimaryKey != ValCodclub))))
					_club = Models.Club.Find(ValCodclub, m_userContext, Identifier, _fieldsToSerialize);
				_club ??= new Models.Club(m_userContext, true, _fieldsToSerialize);
				return _club;
			}
			set { _club = value; }
		}

		[DisplayName("FK_Agent")]
		/// <summary>Field : "FK_Agent" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Contr.ValCodagent")]
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

		[DisplayName("Transfer Value")]
		/// <summary>Field : "Transfer Value" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Contr.ValTransval")]
		[NumericAttribute(0)]
		public decimal? ValTransval { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValTransval, 0)); } set { klass.ValTransval = Convert.ToDecimal(value); } }

		[DisplayName("Monetary Value comissions through each transfer")]
		/// <summary>Field : "Monetary Value comissions through each transfer" Tipo: "$" Formula: + "[CONTR->TRANSVAL]*[AGENT->PERC_COM]"</summary>
		[ShouldSerialize("Contr.ValComiseur")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValComiseur { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValComiseur, 2)); } set { klass.ValComiseur = Convert.ToDecimal(value); } }

		[DisplayName("Contract duration")]
		/// <summary>Field : "Contract duration" Tipo: "N" Formula: + "Year([CONTR->FINDATE]) - Year([CONTR->STARTDAT])"</summary>
		[ShouldSerialize("Contr.ValCtrdurat")]
		[NumericAttribute(0)]
		public decimal? ValCtrdurat { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValCtrdurat, 0)); } set { klass.ValCtrdurat = Convert.ToDecimal(value); } }

		[DisplayName("Yearly Salary")]
		/// <summary>Field : "Yearly Salary" Tipo: "$" Formula: + "[CONTR->SALARY]*12"</summary>
		[ShouldSerialize("Contr.ValSlryyr")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValSlryyr { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValSlryyr, 2)); } set { klass.ValSlryyr = Convert.ToDecimal(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Contr.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Contr(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAcontr(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Contr(UserContext userContext, CSGenioAcontr val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAcontr csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "playr":
						_playr ??= new Playr(m_userContext, true, _fieldsToSerialize);
						_playr.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "club":
						_club ??= new Club(m_userContext, true, _fieldsToSerialize);
						_club.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					case "agent":
						_agent ??= new Agent(m_userContext, true, _fieldsToSerialize);
						_agent.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Contr Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAcontr>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Contr(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Contr> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAcontr>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Contr>((r) => new Contr(userCtx, r));
		}

// USE /[MANUAL AJF MODEL CONTR]/
	}
}
