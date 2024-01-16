using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Item.Base
{
    public class ItemBase : MonoBehaviour
    {
        private int _interactNum = 0;
        [SerializeField] private string[] _interactionScript;
        
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

