using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Item.Base;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("PlayerMove&Rotate")]
        [SerializeField] float turnSpeed = 4.0f; // ���콺 ȸ�� �ӵ�
        [SerializeField] float _speed;
        [SerializeField] float _normalSpeed = 5f;
        [SerializeField] float _runSpeed = 10f;
        [SerializeField] private float lookSensitivity;
        [SerializeField] private float cameraRotationLimit;
        private float currentCameraRotationX;

        Rigidbody body; // Rigidbody�� ������ ����

        [Header("Interaction")]
        [SerializeField] private float MaxDistance;
        private RaycastHit hit;

        [HideInInspector] public bool _canMove = true;
        [HideInInspector] public bool _canRotate = true;


        [SerializeField] private Transform _camera;

        private void Awake()
        {
            body = GetComponent<Rigidbody>();           // Rigidbody�� �����´�.
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
#if UNITY_EDITOR
            //  Ű���忡 ���� �̵��� ����
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            Vector3 mov = new Vector3(h, 0, v);

            // �̵����� ��ǥ�� �ݿ�
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

        private void CharacterRotation()  // �¿� ĳ���� ȸ��
        {
            float _yRotation = Input.GetAxisRaw("Mouse X");
            Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
            body.MoveRotation(body.rotation * Quaternion.Euler(_characterRotationY)); // ���ʹϾ� * ���ʹϾ�
        }
        #endregion

        #region :::: Interaction
        private void Interaction()
        {
            Vector3 cameraPosition = _camera.position;
            Vector3 cameraForward = _camera.forward;

            // �������� ã�� ��ġ ���
            Vector3 checkPosition = cameraPosition + cameraForward * MaxDistance;

            // ����ĳ��Ʈ�� �̿��Ͽ� ������ �˻�
            RaycastHit hit;
            if (Physics.Raycast(checkPosition, cameraForward, out hit, Mathf.Infinity))
            {
                // �������� ã���� ���
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
