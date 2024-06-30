using Assets.Scripts.Common;
using Assets.Scripts.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Object
{
    public enum DoorState
    {
        DoorOpen,
        DoorClose,
    }
    public class Door : MonoBehaviour
    {
        public DoorState DoorState {get { return _doorState; } }
        protected DoorState _doorState = DoorState.DoorClose;
        private Animator _anim;
        private AudioSource _audioSource;
        private void Awake()
        {
            _anim = GetComponentInParent<Animator>();
            _audioSource = GetComponent<AudioSource>();
        }

        public void ForceCloseDoor()
        {
            if (_doorState == DoorState.DoorClose) return;
            DoorActive();
        }

        public virtual void  DoorActive()
        {
            _doorState = _doorState == DoorState.DoorOpen ? DoorState.DoorClose : DoorState.DoorOpen;
            _anim.SetTrigger(_doorState.ToString());
            _audioSource.Play();
        }
    }
}

