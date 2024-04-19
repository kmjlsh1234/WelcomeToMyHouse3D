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
                //사운드 넣기
                PlayerViewModel.Instance.PlayerData.CurMapType = MapType.FirstFloor;
                //fade재생
                MapManager.Instance.GenerateMap(MapType.FirstFloor);
                PlayerViewModel.Instance.MovePlayerPos(MapType.FirstFloor, DoorCount.FirstDoor);
            }
                

            else
            {
                //문을 열어야 해 나레이션 재생
                Debug.LogError("");
            }

        }

        public override void ChoiceBEvent()
        {
            base.ChoiceBEvent();
        }
    }
}

