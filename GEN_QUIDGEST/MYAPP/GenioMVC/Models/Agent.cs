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
	public class Agent : ModelBase
	{
		[JsonIgnore]
		public CSGenioAagent klass { get { return baseklass as CSGenioAagent; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Agent.ValCodagent")]
		public string ValCodagent { get { return klass.ValCodagent; } set { klass.ValCodagent = value; } }

		[DisplayName("Agent´s Name")]
		/// <summary>Field : "Agent´s Name" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Agent.ValName")]
		public string ValName { get { return klass.ValName; } set { klass.ValName = value; } }

		[DisplayName("Photo's Agent")]
		/// <summary>Field : "Photo's Agent" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Agent.ValPhoto")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValPhoto { get { return new ImageModel(klass.ValPhoto) { Ticket = ValPhotoQTicket }; } set { klass.ValPhoto = value; } }
		[JsonIgnore]
		public string ValPhotoQTicket = null;

		[DisplayName("Agent's Email")]
		/// <summary>Field : "Agent's Email" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Agent.ValEmail")]
		public string ValEmail { get { return klass.ValEmail; } set { klass.ValEmail = value; } }

		[DisplayName("Agent's Phone")]
		/// <summary>Field : "Agent's Phone" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Agent.ValPhone")]
		public string ValPhone { get { return klass.ValPhone; } set { klass.ValPhone = value; } }

		[DisplayName("Percentage of the Comission")]
		/// <summary>Field : "Percentage of the Comission" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Agent.ValPerc_com")]
		[NumericAttribute(2)]
		public decimal? ValPerc_com { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValPerc_com, 2)); } set { klass.ValPerc_com = Convert.ToDecimal(value); } }

		[DisplayName("Total earn through comission")]
		/// <summary>Field : "Total earn through comission" Tipo: "$" Formula: SR "[CONTR->COMISEUR]"</summary>
		[ShouldSerialize("Agent.ValTotcomis")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValTotcomis { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValTotcomis, 2)); } set { klass.ValTotcomis = Convert.ToDecimal(value); } }

		[DisplayName("Gender")]
		/// <summary>Field : "Gender" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Agent.ValGender")]
		[DataArray("Gender", GenioMVC.Helpers.ArrayType.Character)]
		public string ValGender { get { return klass.ValGender; } set { klass.ValGender = value; } }
		[JsonIgnore]
		public SelectList ArrayValgender { get { return new SelectList(CSGenio.business.ArrayGender.GetDictionary(), "Key", "Value", ValGender); } set { ValGender = value.SelectedValue as string; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Agent.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Agent(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAagent(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Agent(UserContext userContext, CSGenioAagent val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAagent csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
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
		public static Agent Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAagent>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Agent(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Agent> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAagent>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Agent>((r) => new Agent(userCtx, r));
		}

// USE /[MANUAL AJF MODEL AGENT]/
	}
}
