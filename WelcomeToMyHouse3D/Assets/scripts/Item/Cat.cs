using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Item.Base;
using Assets.Scripts.Manager;

namespace Assets.Scripts.Item
{
    public class Cat : ItemBase
    {
        protected override void NotChoiceItemInteraction()
        {
            ///<summary>ù ���ͷ��� ����</summary>
            if (_interactNum == 0)
            {
                PlayerViewModel.Instance.CurrentItemData = _data;
                PlayerViewModel.Instance.CurrentItemBase = this;
                UIManager.Instance.OnOffDialog(true);
                PlayerViewModel.Instance.Player.OnOffCharacterMove(false);
                DataManager.Instance.SaveData();
            }

            _interactNum++;
            if (_interactNum > _interactionScript.Length)
            {
                InteractionFinish();
                return;
            }

            UIManager.Instance.DialogSystem(_interactionScript[_interactNum - 1]);
        }
    }
}

