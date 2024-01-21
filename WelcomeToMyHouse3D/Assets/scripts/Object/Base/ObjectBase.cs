using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets.Scripts.Common;
using Assets.Scripts.Manager;

namespace Assets.Scripts.Object.Base
{
    public class ObjectBase : MonoBehaviour
    {
        protected ObjectData _data;
        protected int _interactNum = 0;
        protected ObjectType _objectType;
        protected string[] _interactionScript;

        protected void Start()
        {
            _data = ResourceManager.Instance.ObjectDataList.FirstOrDefault(x => x.name == this.gameObject.name);
            if (_data != null) InitSetting();
        }

        protected virtual void InitSetting()
        {
            _interactNum = 0;
            _objectType = _data.ObjectType;
            _interactionScript = _data.InteractionScript;
        }

        public virtual void Interaction() 
        {
            switch(_objectType)
            {
                case ObjectType.ChoiceObject:
                    ChoiceObjectInteraction();
                    break;
                case ObjectType.NotChoiceObject:
                    NotChoiceObjectInteraction();
                    break;
                case ObjectType.ItemDropObject:
                    ItemDropObjectInteraction();
                    break;
            } 
        }

        protected virtual void NotChoiceObjectInteraction()
        {
            ///<summary>첫 인터랙션 시작</summary>
            if (_interactNum == 0)
            {
                Debug.Log($"{this.gameObject.name}의 _interactionNum == 0");
                PlayerViewModel.Instance.CurrentObjectData = _data;
                PlayerViewModel.Instance.CurrentObjectBase = this;
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

        protected void ChoiceObjectInteraction()
        {
            if(_interactNum == 0)
            {
                PlayerViewModel.Instance.CurrentObjectData = _data;
                PlayerViewModel.Instance.CurrentObjectBase = this;
                UIManager.Instance.OnOffDialog(true);
                PlayerViewModel.Instance.Player.OnOffCharacterMove(false);
            }

            else if(_interactNum == _interactionScript.Length)
            {
                return;
            }
            else if(_interactNum > _interactionScript.Length)
            {
                PlayerViewModel.Instance.CurrentObjectData = null;
                PlayerViewModel.Instance.CurrentObjectBase = null;
                UIManager.Instance.OnOffDialog(false);
                UIManager.Instance.OnOffChoiceSystem(false);
                PlayerViewModel.Instance.Player.OnOffCharacterMove(true);
                _interactNum = 0;
                return;
            }
            _interactNum++;
            UIManager.Instance.DialogSystem(_interactionScript[_interactNum - 1]);
        }

        public virtual void ItemDropObjectInteraction()
        {
            if(!_data.ItemDropObjectData.IsTrigger)
            {
                ///<summary>첫 인터랙션 시작</summary>
                if (_interactNum == 0)
                {
                    Debug.Log($"{this.gameObject.name}의 _interactionNum == 0");
                    PlayerViewModel.Instance.CurrentObjectData = _data;
                    PlayerViewModel.Instance.CurrentObjectBase = this;
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
            else
            {
                ///<summary>첫 인터랙션 시작</summary>
                if (_interactNum == 0)
                {
                    Debug.Log($"{this.gameObject.name}의 _interactionNum == 0");
                    PlayerViewModel.Instance.CurrentObjectData = _data;
                    PlayerViewModel.Instance.CurrentObjectBase = this;
                    UIManager.Instance.OnOffDialog(true);
                    PlayerViewModel.Instance.Player.OnOffCharacterMove(false);
                }

                _interactNum++;
                if (_interactNum > _data.ItemDropObjectData.AfterItemDropScript.Length)
                {
                    InteractionFinish();
                    return;
                }

                UIManager.Instance.DialogSystem(_data.ItemDropObjectData.AfterItemDropScript[_interactNum - 1]);
            }
        }

        public virtual void InteractionFinish()
        {
            
            UIManager.Instance.OnOffDialog(false);
            PlayerViewModel.Instance.CurrentObjectData = null;
            PlayerViewModel.Instance.CurrentObjectBase = null;
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

