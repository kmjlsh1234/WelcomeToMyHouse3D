using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Common;

namespace Assets.Scripts.Object
{
    public class FirstFloor_FirstFloorKey : Item
    {
        protected override void OnTriggerEnter(Collider other)
        {
            PlayerViewModel.Instance.PlayerData.QuestName = QuestName.SecondFloor_GetSaw;
            base.OnTriggerEnter(other);
        }
    }
}

