using Assets.Scripts.Object.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace Assets.Scripts.Object
{
    public class FirstFloor_Window : ObjectBase
    {
        [SerializeField] private Transform _leftCurtain;
        [SerializeField] private Transform _rightCurtain;
        private Sequence seq;
        private BoxCollider _collider;
        private bool isOpen = false;
        private void Start()
        {
            _leftCurtain.localScale = Vector3.one * 1.3f;
            _rightCurtain.localScale = Vector3.one * 1.3f;
            _collider = GetComponent<BoxCollider>();
            isOpen = false;
        }

        public override void TouchEvent()
        {
            base.TouchEvent();
            _collider.enabled = false;
            isOpen = !isOpen;

            if (seq != null) seq.Kill();
            seq = DOTween.Sequence();

            if (isOpen)
            {
                seq.Append(_leftCurtain.DOScaleX(0.5f, 1f));
                seq.Join(_rightCurtain.DOScaleX(0.5f, 1f));
                seq.Join(_leftCurtain.DOLocalMoveX(-0.293f, 1f));
                seq.Join(_rightCurtain.DOLocalMoveX(-3.41f, 1f));
                seq.Play().OnComplete(() => _collider.enabled = true);
            }
            else
            {
                seq.Append(_leftCurtain.DOLocalMoveX(-0.8f, 1f));
                seq.Join(_rightCurtain.DOLocalMoveX(-2.8f, 1f));
                seq.Join(_leftCurtain.DOScaleX(1.3f, 1f));
                seq.Join(_rightCurtain.DOScaleX(1.3f, 1f));
               
                seq.Play().OnComplete(() => _collider.enabled = true);
            }
        }


    }
}

