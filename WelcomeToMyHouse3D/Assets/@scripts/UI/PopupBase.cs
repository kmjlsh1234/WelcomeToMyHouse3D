using Assets.Scripts.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class PopupBase : MonoBehaviour, IDisposable
    {
        public PopupStyle _style;

        public virtual void SetData() { }

        protected void OnDestroy()
        {
            Dispose();
        }

        public virtual void Dispose()
        {
            
        }
    }
}

