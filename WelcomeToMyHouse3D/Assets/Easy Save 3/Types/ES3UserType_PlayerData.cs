using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("Position", "Rotation", "CurMapType", "CurQuestType", "ItemList")]
	public class ES3UserType_PlayerData : ES3ObjectType
	{
		public static ES3Type Instance = null;

		public ES3UserType_PlayerData() : base(typeof(PlayerData)){ Instance = this; priority = 1; }


		protected override void WriteObject(object obj, ES3Writer writer)
		{
			var instance = (PlayerData)obj;
			
			writer.WriteProperty("Position", instance.Position, ES3Type_Vector3.Instance);
			writer.WriteProperty("Rotation", instance.Rotation, ES3Type_Vector3.Instance);
			writer.WriteProperty("CurMapType", instance.CurMapType, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(Assets.Scripts.Common.MapType)));
			writer.WriteProperty("CurQuestType", instance.CurQuestType, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(Assets.Scripts.Common.QuestType)));
			writer.WriteProperty("ItemList", instance.ItemList, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(System.Collections.Generic.List<System.String>)));
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			var instance = (PlayerData)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "Position":
						instance.Position = reader.Read<UnityEngine.Vector3>(ES3Type_Vector3.Instance);
						break;
					case "Rotation":
						instance.Rotation = reader.Read<UnityEngine.Vector3>(ES3Type_Vector3.Instance);
						break;
					case "CurMapType":
						instance.CurMapType = reader.Read<Assets.Scripts.Common.MapType>();
						break;
					case "CurQuestType":
						instance.CurQuestType = reader.Read<Assets.Scripts.Common.QuestType>();
						break;
					case "ItemList":
						instance.ItemList = reader.Read<System.Collections.Generic.List<System.String>>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			var instance = new PlayerData();
			ReadObject<T>(reader, instance);
			return instance;
		}
	}


	public class ES3UserType_PlayerDataArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_PlayerDataArray() : base(typeof(PlayerData[]), ES3UserType_PlayerData.Instance)
		{
			Instance = this;
		}
	}
}