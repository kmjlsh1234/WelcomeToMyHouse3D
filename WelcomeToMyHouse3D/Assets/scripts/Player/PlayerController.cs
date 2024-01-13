using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("PlayerMove&Rotate")]
        [SerializeField] float turnSpeed = 4.0f; // ���콺 ȸ�� �ӵ�
        [SerializeField] float _speed;
        [SerializeField] float _normalSpeed = 5f;
        [SerializeField] float _runSpeed = 10f;
        // ���콺 ȸ��
        private float xRotate = 0.0f; // ���� ����� X�� ȸ������ ���� ���� ( ī�޶� �� �Ʒ� ���� )
        Rigidbody body; // Rigidbody�� ������ ����

        [Header("Interaction")]
        [SerializeField] private float MaxDistance;
        private RaycastHit hit;

        [HideInInspector] public bool _canMove = true;
        [HideInInspector] public bool _canRotate = true;

        void Start()
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
            //  Ű���忡 ���� �̵��� ����
            Vector3 move =
                transform.forward * Input.GetAxis("Vertical") +
                transform.right * Input.GetAxis("Horizontal");

            // �̵����� ��ǥ�� �ݿ�
            if (Input.GetKey(KeyCode.LeftShift))
                _speed = _runSpeed;
            else
                _speed = _normalSpeed;

            transform.position += move * _speed * Time.deltaTime;

        }

        void Rotate()
        {
            // �¿�� ������ ���콺�� �̵��� * �ӵ��� ���� ī�޶� �¿�� ȸ���� �� ���
            float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
            // ���� y�� ȸ������ ���� ���ο� ȸ������ ���
            float yRotate = transform.eulerAngles.y + yRotateSize;

            // ���Ʒ��� ������ ���콺�� �̵��� * �ӵ��� ���� ī�޶� ȸ���� �� ���(�ϴ�, �ٴ��� �ٶ󺸴� ����)
            float xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
            // ���Ʒ� ȸ������ ���������� -45�� ~ 80���� ���� (-45:�ϴù���, 80:�ٴڹ���)
            // Clamp �� ���� ������ �����ϴ� �Լ�
            xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

            // ī�޶� ȸ������ ī�޶� �ݿ�(X, Y�ุ ȸ��)
            transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
        }
        #endregion

        #region :::: Interaction
        private void Interaction()
        {
            
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
