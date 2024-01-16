using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Assets.Scripts.Common;

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

        private void InitSetting()
        {
            _interactNum = 0;
            _itemType = _data.ItemType;
            _interactionScript = _data.InteractionScript;
        }

        public virtual void InteractionStart()
        {
            if (_interactNum == 0) Interaction();    
        }

        public virtual void Interaction() 
        {
            _interactNum++;
            if (_interactNum > _interactionScript.Length) InteractionFinish();
        }

        public virtual void InteractionFinish()
        {
            _interactNum = 0;
        }


    }
}

