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
        }

        private void NotChoiceItemInteraction()
        {
            ///<summary>첫 인터랙션 시작</summary>
            if (_interactNum == 0)
            {
                PlayerViewModel.Instance.CurrentItemData = _data;
                PlayerViewModel.Instance.CurrentItemBase = this;
                UIManager.Instance.OnOffDialog(true);
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

        private void ChoiceItemInteraction()
        {
            if(_interactNum == 0)
            {
                PlayerViewModel.Instance.CurrentItemData = _data;
                PlayerViewModel.Instance.CurrentItemBase = this;
                UIManager.Instance.OnOffDialog(true);
                PlayerViewModel.Instance.Player.OnOffCharacterMove(false);
            }

            else if(_interactNum == _interactionScript.Length)
            {
                return;
            }
            else if(_interactNum > _interactionScript.Length)
            {
                PlayerViewModel.Instance.CurrentItemData = null;
                PlayerViewModel.Instance.CurrentItemBase = null;
                UIManager.Instance.OnOffDialog(false);
                UIManager.Instance.OnOffChoiceSystem(false);
                PlayerViewModel.Instance.Player.OnOffCharacterMove(true);
                _interactNum = 0;
                return;
            }
            _interactNum++;
            UIManager.Instance.DialogSystem(_interactionScript[_interactNum - 1]);
        }

        public virtual void InteractionFinish()
        {
            
            UIManager.Instance.OnOffDialog(false);
            PlayerViewModel.Instance.CurrentItemData = null;
            PlayerViewModel.Instance.Player.OnOffCharacterMove(true);
            _interactNum = 0;
        }

        public virtual void ChoiceAButtonClick()
        {
            if(_data.ChoiceFinishScript != string.Empty)
            {
                UIManager.Instance.DialogSystem(_data.ChoiceFinishScript);
                _interactNum++;
            }
        }

        public virtual void ChoiceBButtonClick()
        {
            _interactNum++;
            Interaction();

        }


    }
}

