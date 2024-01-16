using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChoiceItemData", menuName = "Scriptable Object/ChoiceItemData", order = int.MaxValue)]
public class ChoiceItemData : ItemData
{
    [Header("������ A ����")]
    public string ChoiceA;
    [Header("������ B ����")]
    public string ChoiceB;
    [Header("������ ���� �Ϸ� ����")]
    public string ChoiceFinishScript;
}
