using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Object.Base;
using UniRx;
using Assets.Scripts.Common;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        public Light Light { get { return _light; } }
        [Header("PlayerMove&Rotate")]
        [SerializeField] private float _speed;
        private float _normalSpeed = 4f;
        private float _runSpeed = 6f;

        [SerializeField] private float lookSensitivity;
        [SerializeField] private float cameraRotationLimit;
        private float currentCameraRotationX;
        Rigidbody rigid; // Rigidbody를 가져올 변수
        [SerializeField] private bool isGround;
        [Header("Interaction")]
        [SerializeField] private float MaxDistance;
        private RaycastHit hit;
        
        public bool _canMove { get; set; } = true;
        public bool _canRotate { get; set; } = true;
        private bool isMove;
        [SerializeField] private Transform _camera;
        [SerializeField] private Light _light;
        [SerializeField] private AudioSource _walkSource;
        [SerializeField] private AudioSource _runSource;


        private void Awake()
        {
            rigid = GetComponent<Rigidbody>();           // Rigidbody를 가져온다.
            transform.rotation = Quaternion.identity;   // 회전 상태를 정면으로 초기화
        }

        private void Start()
        {
            this.ObserveEveryValueChanged(x => x.isMove).Subscribe(x => SoundController()).AddTo(gameObject);
            PlayerViewModel.Instance.ObserveEveryValueChanged(x => x.PlayerData.ItemList.Contains(ItemName.GardenMap_FlashLight))
                .Subscribe(x => _light.gameObject.SetActive(x))
                .AddTo(gameObject);
        }

        void Update()
        {
            if (_canMove) Move();
            if (_canRotate) Rotate();
        }

        private void SoundController()
        {
            if(!isMove)
            {
                _walkSource.enabled = false;
                _runSource.enabled = false;
            }
            else
            {
                if (_speed == _runSpeed) _runSource.enabled = true;
                else _walkSource.enabled = true;
            }
        }

        
        #region :::: PlayerMove

        void Move()
        {
            _speed = Input.GetKey(KeyCode.LeftShift) ? _runSpeed : _normalSpeed;
            float _moveDirX = Input.GetAxisRaw("Horizontal");
            float _moveDirZ = Input.GetAxisRaw("Vertical");

            Vector3 _moveHorizontal = transform.right * _moveDirX;
            Vector3 _moveVertical = transform.forward * _moveDirZ;

            Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * _speed;

            isMove = _velocity == Vector3.zero ? false : true;
            rigid.MovePosition(transform.position + _velocity * Time.deltaTime);
        }

        void Rotate()
        {
            CameraRotation();
            CharacterRotation();
        }

        private void CameraRotation()
        {
            float _xRotation = Input.GetAxisRaw("Mouse Y");
            float _cameraRotationX = _xRotation * lookSensitivity;

            currentCameraRotationX -= _cameraRotationX;
            currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

            _camera.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
        }

        private void CharacterRotation()  // 좌우 캐릭터 회전
        {

            float _yRotation = Input.GetAxisRaw("Mouse X");
            Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
            rigid.MoveRotation(rigid.rotation * Quaternion.Euler(_characterRotationY)); // 쿼터니언 * 쿼터니언
        }
        #endregion

        
    }
}
