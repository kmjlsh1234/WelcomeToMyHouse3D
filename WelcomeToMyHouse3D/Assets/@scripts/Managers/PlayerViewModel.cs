using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Manager.Base;
using Assets.Scripts.Player;
using Assets.Scripts.Object.Base;
using Assets.Scripts.Common;

public class PlayerViewModel : SingletonBase<PlayerViewModel>
{
    public PlayerController Player;
    
    public ObjectData CurrentObjectData { get; set; }
    public ObjectBase CurrentObjectBase { get; set; }

    public List<ItemName> Inventory = new List<ItemName>();

    public QuestName CurrentQuestName { get; set; }
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
}
