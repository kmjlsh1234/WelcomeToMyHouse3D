using Assets.Scripts.Common;
using Assets.Scripts.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Object
{
    public enum PatrolState
    {
        Move = 0,
        Hold = 1,
    }

    
    public class FirstFloor_Spider : MonoBehaviour
    {
        private MeshCollider _meshCollider;
        private Animation _animation;
        private AudioSource _audioSource;
        private BoxCollider _moveGround;
        private Coroutine _patrolCoroutine;
        private Vector3 _targetPos;
        private bool isMove = false;
        private float speed = 0.2f;
        
        public SpiderState SpiderState { set { PlayAnimation(value); } }
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _meshCollider = GetComponentInChildren<MeshCollider>();
            _animation = GetComponent<Animation>();
        }

        private void Start()
        {
            _moveGround = PlayerViewModel.Instance.CurrentMap.GetComponent<FirstFloor>().Collider;
            //UpdatePatrolState();
        }

        private void PlayAnimation(SpiderState state)
        {
            _animation.Play(state.ToString());
        }

        public void StopPatrol()
        {
            isMove = false;
            if (_patrolCoroutine != null) StopCoroutine(_patrolCoroutine);
        }

        private void Update()
        {
            if(isMove)
            {
                if (CheckArrive())
                {
                    isMove = false;
                    UpdatePatrolState();
                }
                else
                {
                    transform.Translate((_targetPos - transform.position) * speed * Time.deltaTime, Space.World);
                }
            }
        }

        private bool CheckArrive()
        {
            var distance = Vector3.Distance(transform.position, _targetPos);
            if (distance < 3f) return true;
            else return false;
        }

        public void UpdatePatrolState()
        {
            if (_patrolCoroutine != null) StopCoroutine(_patrolCoroutine);

            var randInt = Random.Range(0, 2);
            var state = (PatrolState)randInt;
            switch(state)
            {
                case PatrolState.Hold:
                    _patrolCoroutine = StartCoroutine(Move());
                    break;
                case PatrolState.Move:
                    _patrolCoroutine = StartCoroutine(Hold());
                    break;
            }
        }

        private Vector3 SelectTargetPos()
        {
            var center = new Vector3(_moveGround.center.x, transform.position.y, _moveGround.center.z);
            var randX = Random.Range(center.x - _moveGround.size.x / 2, center.x + _moveGround.size.x / 2);
            var randZ = Random.Range(center.z - _moveGround.size.z / 2, center.z + _moveGround.size.z / 2);

            var targetPos = new Vector3(randX, center.y, randZ);

            return targetPos;
        }

        IEnumerator Move()
        {
            _targetPos = SelectTargetPos();
            _audioSource.enabled = true;
            isMove = true;
            yield return null;
        }

        IEnumerator Hold()
        {
            var timer = Random.Range(1, 3);
            _audioSource.enabled = false;
            yield return new WaitForSeconds(timer);
            UpdatePatrolState();
        }
    }
}

