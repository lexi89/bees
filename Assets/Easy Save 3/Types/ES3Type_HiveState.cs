using System;
using UnityEngine;

namespace ES3Types
{
	[ES3PropertiesAttribute("LevelIndex", "BeeCount")]
	public class ES3Type_HiveState : ES3ObjectType
	{
		public static ES3Type Instance = null;

		public ES3Type_HiveState() : base(typeof(HiveState)){ Instance = this; }

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			var instance = (HiveState)obj;
			
			writer.WriteProperty("LevelIndex", instance.LevelIndex, ES3Type_int.Instance);
			writer.WriteProperty("BeeCount", instance.BeeCount, ES3Type_float.Instance);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			var instance = (HiveState)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "LevelIndex":
						instance.LevelIndex = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "BeeCount":
						instance.BeeCount = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			var instance = new HiveState();
			ReadObject<T>(reader, instance);
			return instance;
		}
	}

	public class ES3Type_HiveStateArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_HiveStateArray() : base(typeof(HiveState[]), ES3Type_HiveState.Instance)
		{
			Instance = this;
		}
	}
}