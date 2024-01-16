using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Common;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Object/ItemData", order = int.MaxValue)]
public class ItemData : ScriptableObject
{
    public string ItemName;
    public ItemType ItemType;
    public string[] InteractionScript;
}
