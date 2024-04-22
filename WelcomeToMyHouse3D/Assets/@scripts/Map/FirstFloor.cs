using Assets.Scripts.Common;
using Assets.Scripts.Manager;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
using Assets.Scripts.Object;

namespace Assets.Scripts.Map
{
    public class FirstFloor : MapBase
    {
        public CinemachineVirtualCamera VirtualCamera { get { return _virtualCamera; } }
        public FirstFloor_Spider Spider { get { return _spider; } }
        public Transform DeadEventSpiderPos { get { return _deadEventSpiderPos; } }
        private BoxCollider _spiderGround;

        public BoxCollider Collider { get { return _spiderGround; } }
        [SerializeField] private FirstFloor_Spider _spider;
        [SerializeField] private Transform _cinemachineSecondPos;
        [SerializeField] private Transform _firstSpiderPos;
        [SerializeField] private Transform _secondSpiderPos;
        [SerializeField] private Transform _deadEventSpiderPos;
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;


        private void Awake()
        {
            _spiderGround = GetComponent<BoxCollider>();
        }
        private void Start()
        {
            SoundManager.Instance.PlayBGM(BGMName.BGM_FirstFloor);
            MapEnterEvent();
        }

        public override void MapEnterEvent()
        {
            base.MapEnterEvent();
            var isEventShow = PlayerViewModel.Instance.PlayerData.MapEventList.Contains(this.gameObject.name);

            if (isEventShow)
            {
                _spider.UpdatePatrolState();
                return;
            }

            _spider.transform.SetParent(_firstSpiderPos);
            _spider.transform.localPosition = Vector3.zero;
            _spider.transform.localRotation = Quaternion.identity;
            _spider.SpiderState = SpiderState.run;
            StartCoroutine(FirstFloorEvent());
        }

        IEnumerator FirstFloorEvent()
        {
            
            PlayerViewModel.Instance.Player._canMove = false;
            PlayerViewModel.Instance.Player._canRotate = false;
            _virtualCamera.gameObject.SetActive(true);

            var InitPos = new Vector3(FirstDoor.x, 2f, FirstDoor.z);
            var SecondPos = new Vector3(_cinemachineSecondPos.position.x, 2f, _cinemachineSecondPos.position.z);
            var FinalPos = new Vector3(SecondDoor.x, 2f, SecondDoor.z);
            _virtualCamera.transform.position = InitPos;

            yield return new WaitForSeconds(2f);
            _virtualCamera.transform.DOMove(SecondPos, 5f).SetEase(Ease.Linear);
            yield return new WaitForSeconds(4f);
            _virtualCamera.LookAt = _spider.transform;
            _spider.transform.DOMove(_secondSpiderPos.position, 3f);
            yield return new WaitForSeconds(3f);
            _virtualCamera.LookAt = null;
            _virtualCamera.transform.DOLocalRotate(Vector3.zero, 2f);
            _virtualCamera.transform.DOMove(FinalPos, 5f).SetEase(Ease.Linear);
            yield return new WaitForSeconds(5f);
            UIManager.Instance.Show(PopupStyle.Fade);
            
            _virtualCamera.gameObject.SetActive(false);

            _spider.transform.SetParent(this.transform);
            _spider.transform.localRotation = Quaternion.identity;
            _spider.UpdatePatrolState();

            Camera.main.transform.localPosition = Vector3.up * 1.6f;
            Camera.main.transform.localRotation = Quaternion.identity;
            PlayerViewModel.Instance.Player._canMove = true;
            PlayerViewModel.Instance.Player._canRotate = true;
        }
    }
}

