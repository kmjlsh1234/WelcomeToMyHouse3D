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
        [SerializeField] protected ObjectType _objectType;
        [SerializeField] protected ItemName _needItemName;
        protected virtual void Start()
        {
            
        }

        public virtual void TouchEvent() { }
        public virtual void ChoiceAEvent() { }
        public virtual void ChoiceBEvent() { }

        public bool CheckItem()
        {
            var isRegist = PlayerViewModel.Instance.PlayerData.ItemList.Any(item => item == _needItemName);
            return isRegist;
        }
    }
}

