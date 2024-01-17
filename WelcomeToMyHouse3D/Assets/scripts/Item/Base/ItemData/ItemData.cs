using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Common;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Object/ItemData", order = int.MaxValue)]
public class ItemData : ScriptableObject
{
    [Header("아이템 이름 규칙 : 현재 맵_아이템 이름")]
    public string ItemName;
    [Space(10f)]
    [Header("아이템 타입")]
    public ItemType ItemType;
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
}
