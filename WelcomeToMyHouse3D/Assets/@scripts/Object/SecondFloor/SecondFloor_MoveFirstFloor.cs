using Assets.Scripts.Common;
using Assets.Scripts.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Object
{
    public class SecondFloor_MoveFirstFloor : Door
    {
        
        public override void DoorActive()
        {
            base.DoorActive();

            MapManager.Instance.GenerateMap(MapType.FirstMap);
        }
    }
}

