using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Manager.Base;
using Assets.Scripts.Object.Base;
using Assets.Scripts.Player;

public class PlayerViewModel : SingletonBase<PlayerViewModel>
{
    public PlayerController Player;
    
    public ObjectData CurrentObjectData = null;
    public ObjectBase CurrentObjectBase = null;
    protected override void Awake()
    {
        base.Awake();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
}
