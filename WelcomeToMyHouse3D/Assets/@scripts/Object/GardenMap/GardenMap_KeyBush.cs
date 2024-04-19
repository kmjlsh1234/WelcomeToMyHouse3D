using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Object.Base;
using DG.Tweening;
using Assets.Scripts.Manager;
using Assets.Scripts.Common;

namespace Assets.Scripts.Object
{
    public class GardenMap_KeyBush : ObjectBase
    {
        private GameObject _keyPrefab;
        private GameObject _key;

        private void Start()
        {
            if (CheckItem()) return;

            _keyPrefab = Resources.Load<GameObject>("Pref/GardenMap_BushKey");
            InstantiateKey();
        }

        public override void TouchEvent()
        {
            base.TouchEvent();
        }

        public override void ChoiceAEvent()
        {
            if (CheckItem()) return;
            
            base.ChoiceAEvent();
            _key.SetActive(true);
            var targetPos = new Vector3(-0.6f, 0.15f, 0f);
            _key.transform.DOLocalJump(targetPos, 1f, 1, 1f);
        }

        public override void ChoiceBEvent()
        {
            base.ChoiceBEvent();
        }

        private void InstantiateKey()
        {
            _key = Instantiate(_keyPrefab, transform);
            _key.transform.localPosition = Vector3.zero;
            _key.transform.localEulerAngles = Vector3.zero;
            _key.SetActive(false);
        }
    }
}

