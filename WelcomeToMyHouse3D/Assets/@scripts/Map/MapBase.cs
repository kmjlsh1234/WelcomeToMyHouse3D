using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Map
{
    public class MapBase : MonoBehaviour
    {
        private FloorBase[] _floorBases;

        public Vector3 FirstDoor { get { return _firstDoor.position; } }
        public Vector3 SecondDoor { get { return _secondDoor.position; } }

        [SerializeField] protected Transform _firstDoor;
        [SerializeField] protected Transform _secondDoor;

        protected void Awake()
        {
            _floorBases = GetComponentsInChildren<FloorBase>();
        }
        public virtual void MapEnterEvent() { }
    }
}

