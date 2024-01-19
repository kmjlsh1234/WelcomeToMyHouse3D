using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Object.Base;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("PlayerMove&Rotate")]
        [SerializeField] private float turnSpeed = 4.0f; // 마우스 회전 속도
        [SerializeField] private float _speed;
        [SerializeField] private float _normalSpeed = 5f;
        [SerializeField] private float _runSpeed = 10f;
        [SerializeField] private float gravity = 10f;
        [SerializeField] private float lookSensitivity;
        [SerializeField] private float cameraRotationLimit;
        private float currentCameraRotationX;
        Rigidbody rigid; // Rigidbody를 가져올 변수
        [SerializeField] private CapsuleCollider capsuleCollider;
        [SerializeField] private bool isGround;
        [Header("Interaction")]
        [SerializeField] private float MaxDistance;
        private RaycastHit hit;

        [HideInInspector] public bool _canMove = true;
        [HideInInspector] public bool _canRotate = true;

        [SerializeField] private Transform _camera;

        private void Awake()
        {
            rigid = GetComponent<Rigidbody>();           // Rigidbody를 가져온다.
            transform.rotation = Quaternion.identity;   // 회전 상태를 정면으로 초기화
        }

        void Update()
        {
            IsGround();
            if (_canMove) Move();
            if (_canRotate) Rotate();
            if (Input.GetKeyDown(KeyCode.Space)) Interaction();
        }

        #region :::: PlayerMove

        private void IsGround()
        {
            isGround = Physics.Raycast(capsuleCollider.center, Vector3.down, (capsuleCollider.height / 2 + 0.1f));
            Debug.DrawRay(capsuleCollider.center, Vector3.down * (capsuleCollider.height/2 + 0.1f), isGround ? Color.green : Color.red);
            if (!isGround) rigid.MovePosition(transform.position + Vector3.down * 10f * Time.deltaTime);
        }

        void Move()
        {
            float _moveDirX = Input.GetAxisRaw("Horizontal");
            float _moveDirZ = Input.GetAxisRaw("Vertical");

            Vector3 _moveHorizontal = transform.right * _moveDirX;
            Vector3 _moveVertical = transform.forward * _moveDirZ;

            Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * _speed;

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

        #region :::: Interaction
        private void Interaction()
        {
            Ray ray = new Ray(_camera.position, _camera.forward);

            // Ray에 맞은 정보를 저장할 변수
            RaycastHit hit;

            // Ray를 발사하고 맞은 정보를 hit 변수에 저장
            if (Physics.Raycast(ray, out hit, 2f))
            {
                if (hit.collider.CompareTag("Item"))
                {
                    Debug.Log("아이템 발견: " + hit.collider.gameObject.name);
                    ObjectBase _targetObject = hit.collider.gameObject.transform.GetComponent<ObjectBase>();
                    _targetObject.Interaction();
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
