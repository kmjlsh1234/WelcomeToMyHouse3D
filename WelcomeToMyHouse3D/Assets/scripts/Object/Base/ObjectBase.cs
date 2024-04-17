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
        protected ObjectType _objectType;

        protected virtual void Start()
        {
            
        }

        public virtual void ChoiceAEvent() { }
        public virtual void ChoiceBEvent() { }
    }
}

