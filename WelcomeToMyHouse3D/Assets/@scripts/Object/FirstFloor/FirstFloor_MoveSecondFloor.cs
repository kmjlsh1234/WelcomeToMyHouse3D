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
    public class FirstFloor_MoveSecondFloor : ObjectBase
    {
        public override void TouchEvent()
        {
            base.TouchEvent();
            if (!CheckItem()) StartCoroutine(DeadEvent());
            else Debug.LogError("2ÃþÀ¸·Î ÀÌµ¿");
                    
        }
        IEnumerator DeadEvent()
        {
            PlayerViewModel.Instance.Player._canMove = false;
            PlayerViewModel.Instance.Player._canRotate = false;
            var map = PlayerViewModel.Instance.CurrentMap.GetComponent<FirstFloor>();
            map.VirtualCamera.transform.position = Camera.main.transform.position;
            

            map.Spider.StopPatrol();
            map.Spider.transform.SetParent(map.DeadEventSpiderPos);
            map.Spider.transform.position = Vector3.zero;
            map.Spider.transform.rotation = Quaternion.identity;
            map.VirtualCamera.gameObject.SetActive(true);
            map.VirtualCamera.transform.DOLookAt(map.Spider.transform.position, 1f, AxisConstraint.Y);
            map.Spider.transform.DOMove(PlayerViewModel.Instance.Player.transform.position + Vector3.back*2f,2f).SetEase(Ease.InExpo);
            SoundManager.Instance.PlaySound(SFXName.SFX_HorrorAppear);
            yield return new WaitForSeconds(2f);
            map.Spider.SpiderState = Common.SpiderState.taunt;
            yield return new WaitForSeconds(2f);
            map.Spider.SpiderState = Common.SpiderState.run;
        }
    }
}

