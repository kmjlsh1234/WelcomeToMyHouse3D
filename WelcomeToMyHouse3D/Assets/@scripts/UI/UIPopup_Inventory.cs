using Assets.Scripts.Common;
using Assets.Scripts.UI.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class UIPopup_Inventory : PopupBase
    {
        [SerializeField] private GameObject _inventoryBlock;

        [SerializeField] private Transform _parent;

        private void OnEnable()
        {
            var items = PlayerViewModel.Instance.PlayerData.ItemList;

            foreach (ItemName item in items)
            {
                CheckButtonGenerate(item);
            }
        }

        private void CheckButtonGenerate(ItemName itemName)
        {
            foreach(Transform _child in _parent)
            {
                if (_child.gameObject.name == itemName.ToString())
                    return;
            }
            GameObject go = Instantiate(_inventoryBlock, _parent);
            go.GetComponent<InvenBlock>().SetData(itemName);
        }
    }
}

