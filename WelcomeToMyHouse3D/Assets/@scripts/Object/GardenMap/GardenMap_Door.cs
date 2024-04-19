using Assets.Scripts.Object.Base;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Assets.Scripts.Common;
using Assets.Scripts.Manager;

namespace Assets.Scripts.Object
{
    public class GardenMap_Door : ObjectBase
    {
        public override void ChoiceAEvent()
        {
            base.ChoiceAEvent();
            if (CheckItem())
            {
                //���� �ֱ�
                PlayerViewModel.Instance.PlayerData.CurMapType = MapType.FirstFloor;
                //fade���
                MapManager.Instance.GenerateMap(MapType.FirstFloor);
                PlayerViewModel.Instance.MovePlayerPos(MapType.FirstFloor, DoorCount.FirstDoor);
            }
                

            else
            {
                //���� ����� �� �����̼� ���
                Debug.LogError("");
            }

        }

        public override void ChoiceBEvent()
        {
            base.ChoiceBEvent();
        }
    }
}

