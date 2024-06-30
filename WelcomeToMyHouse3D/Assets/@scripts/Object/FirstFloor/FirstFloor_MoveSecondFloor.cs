using Assets.Scripts.Map;
using Assets.Scripts.Object.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Assets.Scripts.Manager;
using Assets.Scripts.Common;

namespace Assets.Scripts.Object
{
    public class FirstFloor_MoveSecondFloor : Door
    {
        [SerializeField] protected ItemName _needItemName = ItemName.None;
        [SerializeField] private FloorBase _firstFloorBase;
        [SerializeField] private FloorBase _secondFloorBase;
        [SerializeField] private SecondFloor_Door _secondFloorDoor;

        public override void DoorActive()
        {
            if (CheckItem())
            {
                base.DoorActive();
                if (_doorState == DoorState.DoorOpen)
                {
                    _secondFloorDoor.ForceCloseDoor();
                    _firstFloorBase.PropActive(true);
                    _secondFloorBase.PropActive(false);
                }
            }
            else
            {
                SoundManager.Instance.PlaySound(SFXName.SFX_DoorClose);
                transform.DOShakePosition(0.5f);
            }
        }
        
        public bool CheckItem()
        {
            var isRegist = PlayerViewModel.Instance.PlayerData.ItemList.Contains(_needItemName);
            return isRegist;
        }
    }
}

