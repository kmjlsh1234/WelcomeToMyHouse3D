using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Map
{
    public class FloorBase : MonoBehaviour
    {
        [SerializeField] private RoomBase[] _rooms;
        protected virtual void Awake()
        {
            _rooms = GetComponentsInChildren<RoomBase>();
        }

        public void PropActive(bool isOn)
        {
            foreach (RoomBase room in _rooms)
                room.PropActive(isOn);
        }
    }
}

