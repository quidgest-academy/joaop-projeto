using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array UnderContract (Under Contract?)
	/// </summary>
	public class ArrayUndercontract : Array<int>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayUndercontract _instance = new ArrayUndercontract();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayUndercontract Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.LOGICAL; } }

		/// <summary>
		/// Yes
		/// </summary>
		public const int E_Y_1 = Y;
		/// <summary>
		/// No
		/// </summary>
		public const int E_N_2 = N;

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayUndercontract"/> class from being created.
		/// </summary>
		private ArrayUndercontract() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<int, ArrayElement> LoadDictionary()
		{
			return new Dictionary<int, ArrayElement>()
			{
				{ E_Y_1, new ArrayElement() { ResourceId = "YES34196", HelpId = "", Group = "" } },
				{ E_N_2, new ArrayElement() { ResourceId = "NO57340", HelpId = "", Group = "" } },
			};
		}

		/// <summary>
		/// Gets the element's description.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static string CodToDescricao(int cod)
		{
			return Instance.CodToDescricaoImpl(cod);
		}

		/// <summary>
		/// Gets the elements.
		/// </summary>
		/// <returns></returns>
		public static List<int> GetElements()
		{
			return Instance.GetElementsImpl();
		}

		/// <summary>
		/// Gets the element.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static ArrayElement GetElement(string cod)
		{
            return Instance.GetElementImpl(int.Parse(cod));
        }

		/// <summary>
		/// Gets the dictionary.
		/// </summary>
		/// <returns></returns>
		public static IDictionary<int, string> GetDictionary()
		{
			return Instance.GetDictionaryImpl();
		}

		/// <summary>
		/// Gets the help identifier.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static string GetHelpId(string cod)
		{
			return Instance.GetHelpIdImpl(int.Parse(cod));
		}
	}
}
