using Assets.Scripts.Common;
using Assets.Scripts.Manager;
using Assets.Scripts.Object.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Object
{
    public class FirstFloor_Frog : ObjectBase
    {
        private Animator _anim;
        private bool isKeyDrop = false;
        private BoxCollider _collider;
        [SerializeField] private GameObject _key;

        private void Start()
        {
            _anim = GetComponent<Animator>();
            _collider = GetComponent<BoxCollider>();
            _key.SetActive(false);
        }

        public override void TouchEvent()
        {
            //유저에게 1층 열쇠가 있는 경우
            if (CheckItem())
            {

                if (PlayerViewModel.Instance.PlayerData.ItemList.Contains(ItemName.FirstFloor_Key))
                {

                }
                //안 준 경우

            }
            //유저에게 1층 열쇠가 없는 경우
            else
            {
                //주사기가 있는 경우
                if (PlayerViewModel.Instance.PlayerData.ItemList.Contains(ItemName.FirstFloor_Injector) && !isKeyDrop)
                {
                    _collider.enabled = false;
                    PlayerViewModel.Instance.Player._canMove = false;
                    StartCoroutine(KeyDropEvent());
                }
                //주사기가 없는 경우
                else
                {
                    //개구리가 아프다는 단서 나레이션 재생
                }
            }
        }

        IEnumerator KeyDropEvent()
        {
            PlayerViewModel.Instance.InformationText = "개구리에게 조심스럽게 주사기의 약물을 투여한다...";
            UIManager.Instance.Show(PopupStyle.Fade);
            UIManager.Instance.Show(PopupStyle.ItemShow);
            SoundManager.Instance.PlaySound(SFXName.SFX_Injector);
            yield return new WaitForSeconds(5f);
            _anim.SetTrigger("KeyDrop");
            SoundManager.Instance.PlaySound(SFXName.SFX_Gag);
            isKeyDrop = true;
            _collider.enabled = true;
            PlayerViewModel.Instance.Player._canMove = true;
        }

        public void KeyActive()
        {
            _key.SetActive(true);
            SoundManager.Instance.PlaySound(SFXName.SFX_ItemDrop);
        }
    }
}

