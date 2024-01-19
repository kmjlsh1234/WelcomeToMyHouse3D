using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Scripts.Common;

[CreateAssetMenu(fileName = "ObjectData", menuName = "Scriptable Object/ObjectData", order = int.MaxValue)]
public class ObjectData : ScriptableObject
{
    [Header("������Ʈ �̸� ��Ģ : ���� ��_������ �̸�")]
    public string ObjectName;
    
    [Space(10f)]
    
    [Header("������ Ÿ��")]
    public ObjectType ObjectType;
    
    [Space(10f)]
    
    [Header("������ ���� �� ����")]
    public string[] InteractionScript;
    
    [Space(20f)]
    
    [Header("������ A ����")]
    public string ChoiceA;
    
    [Header("������ B ����")]
    public string ChoiceB;
    
    [Space(20f)]

    [Header("������ ���� �Ϸ� ����")]
    public string ChoiceFinishScript;

    [Space(20f)]
    [Header("ItemDropObject")]
    public ItemDropObjectData ItemDropObjectData;
}

[Serializable]
public class ItemDropObjectData
{
    [Header("Ʈ���� Ȱ�� ����")]
    public bool IsTrigger;
    
    [Space(20f)]

    [Header("������ ��� �� ����")]
    public string AfterItemDropScript;
}
