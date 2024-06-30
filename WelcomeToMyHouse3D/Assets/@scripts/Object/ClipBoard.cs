using Assets.Scripts.Object.Base;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Object
{
    public class ClipBoard : ObjectBase
    {
        private Transform _originParent;

        private Vector3 _originPos;
        private Vector3 _targetPos;
        private Vector3 _originRotation;
        private Vector3 _targetRotation;

        private bool isTouch = false;
        private void Start()
        {
            _originPos = transform.localPosition;
            _originRotation = transform.localEulerAngles;
            _originParent = transform.parent.transform;
            _targetPos = new Vector3(0f, 0.2f, 1.5f);
            _targetRotation = new Vector3(90f, 180f, 0f);
        }

        public override void TouchEvent()
        {
            base.TouchEvent();
            PlayerViewModel.Instance.Player._canMove = false;
            PlayerViewModel.Instance.Player._canRotate = false;

            isTouch = !isTouch;
            transform.SetParent(isTouch ? Camera.main.transform : _originParent);
            transform.DOLocalMove(isTouch ? _targetPos : _originPos, 1f);
            transform.DOLocalRotate(isTouch ? _targetRotation : _originRotation, 1f).OnComplete(() => {
                if(!isTouch)
                {
                    PlayerViewModel.Instance.Player._canMove = true;
                    PlayerViewModel.Instance.Player._canRotate = true;
                }
                
            });
        }
    }
}

