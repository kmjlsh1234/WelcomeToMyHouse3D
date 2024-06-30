using Assets.Scripts.Object.Base;
using System.Collections;
using UnityEngine;
using Assets.Scripts.Common;
using Assets.Scripts.Manager;
using DG.Tweening;

namespace Assets.Scripts.Object
{
    public class GardenMap_Door : ObjectBase
    {
        public override void TouchEvent()
        {
            if (CheckItem())
            {
                base.TouchEvent();
                StartCoroutine(DoorOpenEvent());
            }


            else
                StartCoroutine(DoorCloseEvent());
        }

        IEnumerator DoorCloseEvent()
        {
            PlayerViewModel.Instance.Player._canMove = false;
            PlayerViewModel.Instance.Player._canRotate = false;
            PlayerViewModel.Instance.InformationText = "문 손잡이를 돌려보지만 열리지 않는다...";
            UIManager.Instance.Show(PopupStyle.Fade);
            UIManager.Instance.Show(PopupStyle.ItemShow);
            yield return new WaitForSeconds(1f);
            SoundManager.Instance.PlaySound(SFXName.SFX_DoorClose);
            yield return new WaitForSeconds(5f);
            PlayerViewModel.Instance.Player._canMove = true;
            PlayerViewModel.Instance.Player._canRotate = true;
        }

        IEnumerator DoorOpenEvent()
        {
            UIManager.Instance.Show(PopupStyle.Fade);
            yield return new WaitForSeconds(1.5f);
            MapManager.Instance.GenerateMap(MapType.FirstMap);
            PlayerViewModel.Instance.MovePlayerPos(MapType.FirstMap, DoorCount.FirstDoor);
            if (PlayerViewModel.Instance.PlayerData.QuestName == 0)
                PlayerViewModel.Instance.PlayerData.QuestName = QuestName.GardenMap_OpenDoor;
        }
    }
}

