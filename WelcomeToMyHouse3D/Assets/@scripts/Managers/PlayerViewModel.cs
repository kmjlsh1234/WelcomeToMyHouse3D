using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Manager.Base;
using Assets.Scripts.Player;
using Assets.Scripts.Object.Base;
using Assets.Scripts.Common;
using Assets.Scripts.Manager;
using Assets.Scripts.Map;
using System.Linq;

public class PlayerViewModel : SingletonBase<PlayerViewModel>
{
    public PlayerController Player;

    public ItemName CurrentItemName { get; set; }
    public string CurrentObjectName { get; set; }
    public string InformationText { get; set; }

    public ObjectData CurrentObjectData { get; set; }
    public ObjectBase CurrentObjectBase { get; set; }

    public GameObject CurrentMap { get; set; }

    public PlayerData PlayerData; //{ get; set; }

    protected override void Awake()
    {
        base.Awake();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void ResetData()
    {
        CurrentObjectData = null;
        CurrentObjectBase = null;
    }

    public void AddItem(ItemName itemName)
    {
        PlayerData.ItemList.Add(itemName);
        var data = ResourceManager.Instance.ItemDataList.FirstOrDefault(x => x.name == itemName.ToString());
        if (data != null) InformationText = $"{data.RealItemName} È¹µæ";
    }

    public void MovePlayerPos(MapType type, DoorCount doorCount)
    {
        var targetPos = Vector3.zero;
        
        if (doorCount == DoorCount.FirstDoor) targetPos = CurrentMap.GetComponent<MapBase>().FirstDoor;
      
        else if(doorCount == DoorCount.SecondDoor) targetPos = CurrentMap.GetComponent<MapBase>().SecondDoor;
        
        Player.transform.position = targetPos;
    }

}
