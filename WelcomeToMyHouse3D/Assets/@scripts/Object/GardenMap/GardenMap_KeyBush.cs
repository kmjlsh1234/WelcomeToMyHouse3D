using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Object.Base;
using DG.Tweening;
using Assets.Scripts.Manager;
using Assets.Scripts.Common;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Assets.Scripts.Object
{
    public class GardenMap_KeyBush : ObjectBase
    {
        [SerializeField] private AssetReference _keyPrefab;
        private bool isKeyOn = false;
        //private GameObject _keyPrefab;
        //private GameObject _key;

        private void Start()
        {
            //_keyPrefab = Resources.Load<GameObject>("Pref/GardenMap_BushKey");
            //InstantiateKey();
        }

        public override void TouchEvent()
        {
            //터치 효과음 재생
            base.TouchEvent();

            //이미 열쇠가 인벤토리에 있다면 return
            if (CheckItem() | isKeyOn) return;


            _keyPrefab.InstantiateAsync().Completed += KeySetting;

        }

        private void KeySetting(AsyncOperationHandle<GameObject> handle)
        {
            var _key = handle.Result;
            _key.transform.SetParent(transform);
            _key.transform.localPosition = Vector3.zero;
            _key.transform.localEulerAngles = Vector3.zero;
            _key.transform.localScale = Vector3.one;
            _key.SetActive(true);
            var targetPos = new Vector3(-0.6f, 0.15f, 0f);
            _key.transform.DOLocalJump(targetPos, 1f, 1, 1f);
            SoundManager.Instance.PlaySound(SFXName.SFX_ItemDrop);

            isKeyOn = true;
        }
    }
}

