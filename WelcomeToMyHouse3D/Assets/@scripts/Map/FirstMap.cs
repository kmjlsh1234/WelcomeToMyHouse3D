using Assets.Scripts.Common;
using Assets.Scripts.Manager;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
using Assets.Scripts.Object;

namespace Assets.Scripts.Map
{
    public class FirstMap : MapBase
    {

        private void OnEnable()
        {
            SoundManager.Instance.PlayBGM(BGMName.BGM_FirstFloor);
        }

        private void Start()
        {
            MapEnterEvent();
        }
    }
}

