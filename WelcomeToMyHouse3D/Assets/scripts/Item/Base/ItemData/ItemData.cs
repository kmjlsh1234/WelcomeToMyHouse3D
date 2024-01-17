using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Common;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Object/ItemData", order = int.MaxValue)]
public class ItemData : ScriptableObject
{
    [Header("������ �̸� ��Ģ : ���� ��_������ �̸�")]
    public string ItemName;
    [Space(10f)]
    [Header("������ Ÿ��")]
    public ItemType ItemType;
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
}
