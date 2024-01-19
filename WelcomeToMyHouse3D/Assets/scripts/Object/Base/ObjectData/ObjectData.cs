using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Scripts.Common;

[CreateAssetMenu(fileName = "ObjectData", menuName = "Scriptable Object/ObjectData", order = int.MaxValue)]
public class ObjectData : ScriptableObject
{
    [Header("오브젝트 이름 규칙 : 현재 맵_아이템 이름")]
    public string ObjectName;
    
    [Space(10f)]
    
    [Header("아이템 타입")]
    public ObjectType ObjectType;
    
    [Space(10f)]
    
    [Header("선택지 선택 전 문구")]
    public string[] InteractionScript;
    
    [Space(20f)]
    
    [Header("선택지 A 문구")]
    public string ChoiceA;
    
    [Header("선택지 B 문구")]
    public string ChoiceB;
    
    [Space(20f)]

    [Header("선택지 선택 완료 문구")]
    public string ChoiceFinishScript;

    [Space(20f)]
    [Header("ItemDropObject")]
    public ItemDropObjectData ItemDropObjectData;
}

[Serializable]
public class ItemDropObjectData
{
    [Header("트리거 활성 여부")]
    public bool IsTrigger;
    
    [Space(20f)]

    [Header("아이템 드롭 후 문구")]
    public string AfterItemDropScript;
}
