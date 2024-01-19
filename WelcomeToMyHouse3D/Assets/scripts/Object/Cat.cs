using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Object.Base;
using Assets.Scripts.Manager;

namespace Assets.Scripts.Object
{
    public class Cat : ObjectBase
    {
        Animator _anim;
        private void Awake()
        {
            _anim = GetComponent<Animator>();
            _anim.SetTrigger("Sitting");
        }
        protected override void NotChoiceObjectInteraction()
        {
            ///<summary>ù ���ͷ��� ����</summary>
            if (_interactNum == 0)
            {
                PlayerViewModel.Instance.CurrentObjectData = _data;
                PlayerViewModel.Instance.CurrentObjectBase = this;
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
