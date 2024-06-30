using Assets.Scripts.Common;
using Assets.Scripts.Manager;
using Assets.Scripts.Object.Base;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Object
{
    public class FirstFloor_MoveGardenDoor : ObjectBase
    {
        public override void TouchEvent()
        {
            if (CheckItem())
            {
                base.TouchEvent();
                StartCoroutine(DoorOpen());
            }

            else
            {
                SoundManager.Instance.PlaySound(SFXName.SFX_DoorClose);
                transform.DOShakePosition(0.5f); 
            }
        }
        IEnumerator DoorOpen()
        {
            UIManager.Instance.Show(PopupStyle.Fade);
            yield return new WaitForSeconds(1.5f);
            MapManager.Instance.GenerateMap(MapType.GardenMap);
            PlayerViewModel.Instance.MovePlayerPos(MapType.GardenMap, DoorCount.SecondDoor);
        }
    }
}

