using Assets.Scripts.Object.Base;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Object
{
    public class FirstFloor_Cabinet : ObjectBase
    {
        [SerializeField] private Transform _moveDoor;
        
        private BoxCollider _collider;
        private bool isOpen = false;

        private void Awake()
        {
            _collider = GetComponent<BoxCollider>();
            _moveDoor.transform.localPosition = new Vector3(0.295f, 0.244f, 0.137f);
        }

        public override void TouchEvent()
        {
            base.TouchEvent();
            _collider.enabled = false;
            isOpen = !isOpen;

            var targetPosX = isOpen ? -0.295f : 0.295f;
            _moveDoor.DOLocalMoveX(targetPosX, 0.5f).OnComplete(() => _collider.enabled = true);
        }



    }
}

