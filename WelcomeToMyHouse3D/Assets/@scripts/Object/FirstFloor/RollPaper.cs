using Assets.Scripts.Object.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts.Object
{
    public class RollPaper : ObjectBase
    {
        private bool isOpen = false;
        private Material _mat;
        private BoxCollider _collider;

        private void Awake()
        {
            _mat = GetComponent<MeshRenderer>().materials[0];
            _collider = GetComponent<BoxCollider>();
        }

        public override void TouchEvent()
        {
            base.TouchEvent();
            _collider.enabled = false;
            isOpen = !isOpen;
            var value = isOpen ? 1f : 0f;
            _mat.DOFloat(value, "Vector1_98d33b1d219b486e97f4a6d459a007a3", 1f).OnComplete(() => _collider.enabled = true);
        }
    }
}

