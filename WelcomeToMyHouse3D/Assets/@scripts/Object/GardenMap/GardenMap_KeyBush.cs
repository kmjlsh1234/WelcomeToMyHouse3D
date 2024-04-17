using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Object.Base;
namespace Assets.Scripts.Object
{
    public class GardenMap_KeyBush : ObjectBase
    {
        private GameObject _keyPrefab;
        private GameObject _key;

        protected override void Start()
        {
            base.Start();
            _keyPrefab = Resources.Load<GameObject>("Pref/GardenMap_Key");
            InstantiateKey();
        }

        public override void ChoiceAEvent()
        {
            base.ChoiceAEvent();
            _key.SetActive(true);
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

