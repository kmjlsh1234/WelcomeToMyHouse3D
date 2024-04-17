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
        /*
        protected override void NotChoiceObjectInteraction()
        {
            ///<summary>첫 인터랙션 시작</summary>
            if (_interactNum == 0)
            {
                PlayerViewModel.Instance.CurrentObjectData = _data;
                DataManager.Instance.SaveData();
            }

            _interactNum++;
            if (_interactNum > _interactionScript.Length)
            {
                InteractionFinish();
                return;
            }
        }
        */
    }
}

