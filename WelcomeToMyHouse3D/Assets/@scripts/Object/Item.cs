using Assets.Scripts.Common;
using Assets.Scripts.Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Object
{
    public class Item : MonoBehaviour
    {
        private CapsuleCollider _collider;
        [SerializeField] private ItemName _itemName;
        private void Awake()
        {
            _collider = GetComponent<CapsuleCollider>();
            this.gameObject.name.Replace("(Clone)", "");
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                _collider.enabled = false;
                PlayerViewModel.Instance.AddItem(_itemName);
                UIManager.Instance.Show(PopupStyle.ItemShow);
                gameObject.SetActive(false);
            }
        }
    }
}

