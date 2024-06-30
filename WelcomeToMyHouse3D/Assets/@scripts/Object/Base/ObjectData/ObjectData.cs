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
    
    [Header("인터랙션 문구")]
    public string[] InteractionScript;
    
}
