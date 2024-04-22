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
        [SerializeField] protected ObjectType _objectType = ObjectType.NotChoiceObject;
        [SerializeField] protected ItemName _needItemName = ItemName.None;
        [SerializeField] private SFXName _sfxName = SFXName.None;

        public virtual void TouchEvent()
        {
            if (_sfxName != SFXName.None)
                SoundManager.Instance.PlaySound(_sfxName);
        }
        public virtual void ChoiceAEvent() { }
        public virtual void ChoiceBEvent() { }

        public bool CheckItem()
        {
            var isRegist = PlayerViewModel.Instance.PlayerData.ItemList.Contains(_needItemName);
            return isRegist;
        }
    }
}

