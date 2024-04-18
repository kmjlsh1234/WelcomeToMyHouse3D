using Assets.Scripts.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Object
{
    public class Item : MonoBehaviour
    {
        private CapsuleCollider _collider;
        [SerializeField]private ItemName _itemName;
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
                PlayerViewModel.Instance.Inventory.Add(_itemName);
                gameObject.SetActive(false);

            }
        }
    }
}

