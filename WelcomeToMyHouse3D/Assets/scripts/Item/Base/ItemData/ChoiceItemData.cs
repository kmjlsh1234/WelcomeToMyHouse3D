using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChoiceItemData", menuName = "Scriptable Object/ChoiceItemData", order = int.MaxValue)]
public class ChoiceItemData : ItemData
{
    [Header("선택지 A 문구")]
    public string ChoiceA;
    [Header("선택지 B 문구")]
    public string ChoiceB;
    [Header("선택지 선택 완료 문구")]
    public string ChoiceFinishScript;
}
