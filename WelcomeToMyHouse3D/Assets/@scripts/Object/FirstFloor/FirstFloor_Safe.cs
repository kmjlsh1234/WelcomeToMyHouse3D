using Assets.Scripts.Manager;
using Assets.Scripts.Object.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts.Object
{
    public class FirstFloor_Safe : ObjectBase
    {
        private AudioSource _audioSource;
        private const string KEYCODE = "1002";
        private FirstFloor_SafeButton _buttons;
        private BoxCollider _collider;
        private Animator _anim;
        
        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _anim = GetComponent<Animator>();
            _collider = GetComponent<BoxCollider>();
            _buttons = GetComponentInChildren<FirstFloor_SafeButton>();
            if (CheckItem()) _anim.SetTrigger("Opened");
            else _anim.SetTrigger("Closed");
            
        }

        public override void TouchEvent()
        {
            base.TouchEvent();
            if(!CheckItem())
            {
                PlayerViewModel.Instance.Player._canMove = false;
                PlayerViewModel.Instance.Player._canRotate = false;
                Camera.main.transform.SetParent(transform);
                Camera.main.transform.DOLocalMove(new Vector3(-0.28f,0.15f,0.01f),1f);
                Camera.main.transform.DOLocalRotate(new Vector3(0f, 90f, 0f), 1f);
                _collider.enabled = false;
                _buttons.gameObject.SetActive(true);
                _buttons.ResetData();
            }
        }

        public void FinishButtonClick(string keyCode)
        {
            SoundManager.Instance.PlaySound(Common.SFXName.SFX_Click);
            _collider.enabled = true;
            _buttons.gameObject.SetActive(false);
            _buttons.ResetData();
            if (KEYCODE.Equals(keyCode)) ValidCode();
            else UnValidCode();
        }

        public void BackButtonClick()
        {
            SoundManager.Instance.PlaySound(Common.SFXName.SFX_Click);
            _collider.enabled = true;
            _buttons.gameObject.SetActive(false);
            CameraReset();
        }

        private void ValidCode()
        {
            _collider.enabled = true;
            _buttons.gameObject.SetActive(false);
            CameraReset();
            _anim.SetTrigger("Open");
        }

        private void UnValidCode()
        {
            _audioSource.Play();
            _buttons.gameObject.SetActive(false);
            CameraReset();
        }

        private void CameraReset()
        {
            Camera.main.transform.SetParent(PlayerViewModel.Instance.Player.transform);
            Camera.main.transform.DOLocalMove(Vector3.up * 1.6f, 1f);
            Camera.main.transform.DOLocalRotate(Vector3.zero, 1f).OnComplete(() => {
                PlayerViewModel.Instance.Player._canMove = true;
                PlayerViewModel.Instance.Player._canRotate = true;
            });
        }

    }
}

