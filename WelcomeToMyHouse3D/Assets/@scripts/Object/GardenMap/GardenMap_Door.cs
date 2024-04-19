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
                SoundManager.Instance.PlaySound(SFXName.SFX_DoorOpen);
                
                //fade���
                MapManager.Instance.GenerateMap(MapType.FirstFloor);
                PlayerViewModel.Instance.MovePlayerPos(MapType.FirstFloor, DoorCount.FirstDoor);
            }
                

            else
            {
                SoundManager.Instance.PlaySound(SFXName.SFX_DoorClose);
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
