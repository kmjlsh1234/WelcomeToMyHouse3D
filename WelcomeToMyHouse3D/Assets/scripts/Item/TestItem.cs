using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Item.Base;

namespace Assets.Scripts.Item
{
    public class TestItem : ItemBase
    {
        public override void Interaction()
        {
            base.Interaction();
            Debug.Log("Interact ¼º°ø!!");
        }
    }
}

