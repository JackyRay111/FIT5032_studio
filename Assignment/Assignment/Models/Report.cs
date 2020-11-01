using System;
using System.Runtime.Serialization;

namespace Assignment.Models
{
	//DataContract for Serializing Data - required to serve in JSON format
	[DataContract]
	public class DataPoint
	{
		public DataPoint(double y, string name, string color)
		{
			this.Y = y;
			this.Name = name;
			this.Color = color;
		}
		public DataPoint(string label, double y)
		{
			this.label = label;
			this.Y = y;
		}

		

		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "label")]
		public string label = "";

		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "y")]
		public Nullable<double> Y = null;

		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "name")]
		public string Name = "";

		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "color")]
		public string Color = null;
	}
}