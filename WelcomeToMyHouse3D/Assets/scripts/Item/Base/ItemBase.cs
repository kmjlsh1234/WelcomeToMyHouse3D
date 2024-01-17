using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets.Scripts.Common;
using Assets.Scripts.Manager;

namespace Assets.Scripts.Item.Base
{
    public class ItemBase : MonoBehaviour
    {
        private ItemData _data;
        private int _interactNum = 0;
        private ItemType _itemType;
        private string[] _interactionScript;

        private void Start()
        {
            _data = ResourceManager.Instance.ItemDataList.FirstOrDefault(x => x.name == this.gameObject.name);
            if (_data != null) InitSetting();
        }

        protected virtual void InitSetting()
        {
            _interactNum = 0;
            _itemType = _data.ItemType;
            _interactionScript = _data.InteractionScript;
        }

        public virtual void Interaction() 
        {
            switch(_itemType)
            {
                case ItemType.ChoiceItem:
                    ChoiceItemInteraction();
                    break;
                case ItemType.NotChoiceItem:
                    NotChoiceItemInteraction();
                    break;
            }
            ///<summary>첫 인터랙션 시작</summary>
            if (_interactNum == 0)
            {
                PlayerViewModel.Instance.CurrentItem = _data;
                var isChoiceSystemActive = (_itemType == ItemType.ChoiceItem) ? true : false;
                UIManager.Instance.OnOffDialog(true, isChoiceSystemActive);
                PlayerViewModel.Instance.Player.OnOffCharacterMove(false);
            }
            
            _interactNum++;
            if (_interactNum > _interactionScript.Length)
            {
                InteractionFinish();
                return;
            }

            UIManager.Instance.DialogSystem(_interactionScript[_interactNum - 1]);
        }

        private void NotChoiceItemInteraction()
        {

        }

        private void ChoiceItemInteraction()
        {

        }

        public virtual void InteractionFinish()
        {
            
            UIManager.Instance.OnOffDialog(false, false);
            PlayerViewModel.Instance.CurrentItem = null;
            PlayerViewModel.Instance.Player.OnOffCharacterMove(true);
            _interactNum = 0;
        }

        public void InteractFinishEvent()
        {

        }


    }
}

