using Assets.Scripts.Common;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Assets.Scripts.Manager;
using System.Linq;
using Assets.Scripts.Util;

namespace Assets.Scripts.UI.Common
{
    public class InvenBlock : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _itemName;
        private ItemName _item;
        private void Start()
        {
            _button.OnSoundClickAsObservable().Subscribe(_ => OnClickButton()).AddTo(gameObject);
        }

        public void SetData(ItemName itemName)
        {
            var data = ResourceManager.Instance.ItemDataList.FirstOrDefault(x => x.ItemName == itemName);

            _image.sprite = data.InventorySprite;
            _itemName.text = data.RealItemName;
            _item = itemName;
            this.gameObject.name = itemName.ToString();

        }

        private void OnClickButton()
        {
            PlayerViewModel.Instance.CurrentObjectBase.UseItemEvent(_item);
            
            UIManager.Instance.Hide(PopupStyle.Dialog);
            UIManager.Instance.Hide(PopupStyle.Inventory);
        }
    }
}

