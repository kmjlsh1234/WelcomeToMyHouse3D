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
                Debug.LogError("�� ����");

            else
            {
                //���� ����� �� �����̼� ���
                //�� ���ȴ���
                Debug.LogError("");
            }

        }

        public override void ChoiceBEvent()
        {
            base.ChoiceBEvent();
        }
    }
}

