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
            //�������� 1�� ���谡 �ִ� ���
            if (CheckItem())
            {

                if (PlayerViewModel.Instance.PlayerData.ItemList.Contains(ItemName.FirstFloor_Key))
                {

                }
                //�� �� ���

            }
            //�������� 1�� ���谡 ���� ���
            else
            {
                //�ֻ�Ⱑ �ִ� ���
                if (PlayerViewModel.Instance.PlayerData.ItemList.Contains(ItemName.FirstFloor_Injector) && !isKeyDrop)
                {
                    _collider.enabled = false;
                    PlayerViewModel.Instance.Player._canMove = false;
                    StartCoroutine(KeyDropEvent());
                }
                //�ֻ�Ⱑ ���� ���
                else
                {
                    //�������� �����ٴ� �ܼ� �����̼� ���
                }
            }
        }

        IEnumerator KeyDropEvent()
        {
            PlayerViewModel.Instance.InformationText = "���������� ���ɽ����� �ֻ���� �๰�� �����Ѵ�...";
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

