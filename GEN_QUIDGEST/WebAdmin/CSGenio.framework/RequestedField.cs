using System;

namespace CSGenio.framework
{
	/// <summary>
	/// A requested field represents the intention to read or write the value of a field
	/// </summary>
	public class RequestedField
	{

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="other">The other RequestedField</param>
        public RequestedField(RequestedField other)
        {
            Name = other.Name;
            FullName = other.FullName;
            Area = other.Area;
            BelongsArea = other.BelongsArea;
            WithoutArea = other.WithoutArea;
            Value = other.Value;
            FieldType = other.FieldType;
        }

		/// <summary>
        /// Naming constructor
		/// </summary>
		/// <param name="name">Name of the field. Can be a fully qualified name or a single alias.</param>
		/// <param name="basearea">Area from where the field is being requested</param>
		public RequestedField(string name, string basearea)
		{
			string[] split = name.Split('.');
			FullName = name;
            if(split.Length == 2)
			{
				Area = split[0];
				Name = split[1];
				WithoutArea = false;
				if (Area.Equals(basearea))
					BelongsArea = true;
				else
					BelongsArea = false;
			}
			else
			{
				Area = "";
				Name = name;
				FullName = name;
				WithoutArea = true;
				BelongsArea = false;
			}
		}

        /// <summary>
        /// Field name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Fully qualified name
        /// </summary>
        public string FullName { get; }

        /// <summary>
        /// Value of the field
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Type of field
        /// </summary>
        public FieldType FieldType { get; set; }

        /// <summary>
        /// Target area of the field
        /// </summary>
        public string Area { get; }

        /// <summary>
        /// True is the field belongs to the base area, false otherwise
        /// </summary>
        public bool BelongsArea { get; }

        /// <summary>
        /// True if this is a non-field reference, false otherwise
        /// </summary>
        public bool WithoutArea { get; }
    }

}
