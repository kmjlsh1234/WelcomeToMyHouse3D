using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Item.Base;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("PlayerMove&Rotate")]
        [SerializeField] float turnSpeed = 4.0f; // 마우스 회전 속도
        [SerializeField] float _speed;
        [SerializeField] float _normalSpeed = 5f;
        [SerializeField] float _runSpeed = 10f;
        [SerializeField] private float lookSensitivity;
        [SerializeField] private float cameraRotationLimit;
        private float currentCameraRotationX;

        Rigidbody body; // Rigidbody를 가져올 변수

        [Header("Interaction")]
        [SerializeField] private float MaxDistance;
        private RaycastHit hit;

        [HideInInspector] public bool _canMove = true;
        [HideInInspector] public bool _canRotate = true;


        [SerializeField] private Transform _camera;

        private void Awake()
        {
            body = GetComponent<Rigidbody>();           // Rigidbody를 가져온다.
            transform.rotation = Quaternion.identity;   // 회전 상태를 정면으로 초기화
        }

        void Update()
        {
            if(_canMove) Move();
            if (_canRotate) Rotate();
            if (Input.GetKeyDown(KeyCode.Space)) Interaction();
        }

        #region :::: PlayerMove
        void Move()
        {
#if UNITY_EDITOR
            //  키보드에 따른 이동량 측정
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            Vector3 mov = new Vector3(h, 0, v);

            // 이동량을 좌표에 반영
            if (Input.GetKey(KeyCode.LeftShift))
                _speed = _runSpeed;
            else
                _speed = _normalSpeed;

            this.transform.Translate(mov * Time.deltaTime * _speed);           
#endif
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
            body.MoveRotation(body.rotation * Quaternion.Euler(_characterRotationY)); // 쿼터니언 * 쿼터니언
        }
        #endregion

        #region :::: Interaction
        private void Interaction()
        {
            Vector3 cameraPosition = _camera.position;
            Vector3 cameraForward = _camera.forward;

            // 아이템을 찾을 위치 계산
            Vector3 checkPosition = cameraPosition + cameraForward * MaxDistance;

            // 레이캐스트를 이용하여 아이템 검사
            RaycastHit hit;
            if (Physics.Raycast(checkPosition, cameraForward, out hit, Mathf.Infinity))
            {
                // 아이템을 찾았을 경우
                if (hit.collider.CompareTag("Item"))
                {
                    Debug.Log("아이템 발견: " + hit.collider.gameObject.name);
                    ItemBase _targetItem = hit.collider.gameObject.transform.GetComponent<ItemBase>();
                    _targetItem.Interaction();
                }
            }
        }

        public void OnOffCharacterMove(bool isOn)
        {
            _canMove = isOn;
            _canRotate = isOn;
        }
        #endregion

        public void StartInteraction()
        {
            _canMove = false;
            _canRotate = false;
        }

        public void FinishInteraction()
        {
            _canMove = true;
            _canRotate = true;
        }
    }
}
