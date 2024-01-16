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
            if(_interactNum == 0) UIManager.Instance.OnOffDialog(true);
            _interactNum++;
            if (_interactNum > _interactionScript.Length)
            {
                InteractionFinish();
                return;
            }

            UIManager.Instance.DialogSystem(_interactionScript[_interactNum - 1]);
        }

        public virtual void InteractionFinish()
        {
            
            UIManager.Instance.OnOffDialog(false);
            _interactNum = 0;
        }


    }
}

