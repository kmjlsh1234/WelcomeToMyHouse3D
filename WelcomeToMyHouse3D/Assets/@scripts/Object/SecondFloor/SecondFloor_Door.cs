using Assets.Scripts.Map;
using Assets.Scripts.Object.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Object
{
    public class SecondFloor_Door : Door
    {
        [SerializeField] private FloorBase _firstFloorBase;
        [SerializeField] private FloorBase _secondFloorBase;
        [SerializeField] private FirstFloor_MoveSecondFloor _firstFloorDoor;
        public override void DoorActive()
        {
            base.DoorActive();

            if(_doorState == DoorState.DoorOpen)
            {
                _firstFloorDoor.ForceCloseDoor();
                _firstFloorBase.PropActive(false);
                _secondFloorBase.PropActive(true);
            }
        }
    }
}

