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
        private DoorState _doorState = DoorState.DoorClose;
        private Animator _anim;

        private void Awake()
        {
            _anim = GetComponentInChildren<Animator>();
        }

        public void  DoorActive()
        {
            _doorState = _doorState == DoorState.DoorOpen ? DoorState.DoorClose : DoorState.DoorOpen;
            _anim.SetTrigger(_doorState.ToString());
        }
    }
}

