using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Item.Base;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("PlayerMove&Rotate")]
        [SerializeField] private float turnSpeed = 4.0f; // ���콺 ȸ�� �ӵ�
        [SerializeField] private float _speed;
        [SerializeField] private float _normalSpeed = 5f;
        [SerializeField] private float _runSpeed = 10f;
        [SerializeField] private float gravity = 10f;
        [SerializeField] private float lookSensitivity;
        [SerializeField] private float cameraRotationLimit;
        private float currentCameraRotationX;

        Rigidbody rigid; // Rigidbody�� ������ ����

        [Header("Interaction")]
        [SerializeField] private float MaxDistance;
        private RaycastHit hit;

        [HideInInspector] public bool _canMove = true;
        [HideInInspector] public bool _canRotate = true;
        private bool isGround = true;

        [SerializeField] private Transform _camera;

        private void Awake()
        {
            rigid = GetComponent<Rigidbody>();           // Rigidbody�� �����´�.
            transform.rotation = Quaternion.identity;   // ȸ�� ���¸� �������� �ʱ�ȭ
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

        private void CharacterRotation()  // �¿� ĳ���� ȸ��
        {
            float _yRotation = Input.GetAxisRaw("Mouse X");
            Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
            rigid.MoveRotation(rigid.rotation * Quaternion.Euler(_characterRotationY)); // ���ʹϾ� * ���ʹϾ�
        }
        #endregion

        #region :::: Interaction
        private void Interaction()
        {
            Ray ray = new Ray(_camera.position, _camera.forward);

            // Ray�� ���� ������ ������ ����
            RaycastHit hit;

            // Ray�� �߻��ϰ� ���� ������ hit ������ ����
            if (Physics.Raycast(ray, out hit, 2f))
            {
                if (hit.collider.CompareTag("Item"))
                {
                    Debug.Log("������ �߰�: " + hit.collider.gameObject.name);
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
