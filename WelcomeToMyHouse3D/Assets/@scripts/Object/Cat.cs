using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Object.Base;
using Assets.Scripts.Manager;
using DG.Tweening;
using Assets.Scripts.Common;


namespace Assets.Scripts.Object
{
    public class Cat : MonoBehaviour
    {
        private CapsuleCollider _collider;
        private Animator _anim;
        private Vector3 _originRotate;
        private Coroutine _coroutine;

        private void Awake()
        {
            _anim = GetComponent<Animator>();
            _collider = GetComponent<CapsuleCollider>();
        }

        private void Start()
        {
            _anim.SetTrigger("Sitting");
            _originRotate = this.transform.localEulerAngles;
        }

        public void SaveData()
        {
            DataManager.Instance.SaveData();
            //ÀúÀå¿Ï·á ÆË¾÷ ¶ç¿ì±â
            _collider.enabled = false;
            if (_coroutine != null) StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(CatRotate());
            

        }

        IEnumerator CatRotate()
        {
            SoundManager.Instance.PlaySound(SFXName.SFX_CatSound);
            transform.DOLookAt(PlayerViewModel.Instance.Player.transform.position, 1f);
            yield return new WaitForSeconds(2f);
            transform.DOLocalRotate(_originRotate, 1f);
            yield return new WaitForSeconds(1f);
            _collider.enabled = true;
            _coroutine = null;
        }

    }
}

