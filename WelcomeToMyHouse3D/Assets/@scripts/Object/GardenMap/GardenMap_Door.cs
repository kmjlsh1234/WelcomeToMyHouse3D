using Assets.Scripts.Object.Base;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Assets.Scripts.Common;
namespace Assets.Scripts.Object
{
    public class GardenMap_Door : ObjectBase
    {
        public override void ChoiceAEvent()
        {
            base.ChoiceAEvent();
            if (CheckItem(ItemName.GardenMap_BushKey))
                Debug.LogError("문 열기");

            else
            {
                //문을 열어야 해 나레이션 재생
                //문 덜컹덜컹
                Debug.LogError("");
            }

        }

        public override void ChoiceBEvent()
        {
            base.ChoiceBEvent();
        }
    }
}

