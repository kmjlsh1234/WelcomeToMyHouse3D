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
    
    [Header("���ͷ��� ����")]
    public string[] InteractionScript;
    
}
