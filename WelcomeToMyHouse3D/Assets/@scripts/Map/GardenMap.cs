using Assets.Scripts.Common;
using Assets.Scripts.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Map
{
    public class GardenMap : MapBase
    {
        private void OnEnable()
        {
            SoundManager.Instance.PlayBGM(BGMName.BGM_GardenMap);
        }

    }
}

