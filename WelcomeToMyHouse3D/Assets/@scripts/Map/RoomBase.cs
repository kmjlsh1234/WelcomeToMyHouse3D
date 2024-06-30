using Assets.Scripts.Object;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Assets.Scripts.Map
{
    public class RoomBase : MonoBehaviour
    {
        [SerializeField] private GameObject _builing;
        [SerializeField] private GameObject _props;
        [SerializeField] private Door _door;

        private void Awake()
        {
            if(_door != null) _props.SetActive(false);
            AddEvent();
        }

        private void AddEvent()
        {
            _door.ObserveEveryValueChanged(x => x.DoorState == DoorState.DoorOpen).Subscribe(x => {
                if (x) _props.SetActive(true);
                else _props.SetActive(false);
             }).AddTo(gameObject);
        }

        public void PropActive(bool isOn)
        {
            _props.SetActive(isOn);
        }

        public virtual void RoomSetting() { }
    }
}

