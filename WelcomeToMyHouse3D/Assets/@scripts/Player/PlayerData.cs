using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Common;

[System.Serializable]
public class PlayerData
{
    public Vector3 Position;
    public Vector3 Rotation;
    public MapType CurMapType;
    public List<ItemName> ItemList;
    public List<string> MapEventList;
    public QuestName QuestName;
}
