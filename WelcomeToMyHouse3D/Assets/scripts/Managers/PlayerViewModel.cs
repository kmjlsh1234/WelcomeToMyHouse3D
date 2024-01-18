using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Manager.Base;
using Assets.Scripts.Item.Base;
using Assets.Scripts.Player;

public class PlayerViewModel : SingletonBase<PlayerViewModel>
{
    public PlayerController Player;
    
    public ItemData CurrentItemData = null;
    public ItemBase CurrentItemBase = null;
    protected override void Awake()
    {
        base.Awake();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
}
