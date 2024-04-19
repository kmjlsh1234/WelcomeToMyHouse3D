using Assets.Scripts.Common;
using Assets.Scripts.Manager;
using Assets.Scripts.Object;
using Assets.Scripts.Object.Base;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Player
{
    public class InteractionController : MonoBehaviour
    {
        private PlayerController _playerController = null;
        private Camera _camera = null;

        [SerializeField] private const float interactionDist = 2f;

        private void Awake()
        {
            _playerController = GetComponent<PlayerController>();
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                    CastRay();
            }
        }

        private void CastRay()
        {
            
            Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionDist))
            {
                var hitObj = hit.collider.gameObject;
                if (hit.collider.CompareTag("Item"))
                {
                    var objectBase = hitObj.GetComponent<ObjectBase>();
                    var objectData = ResourceManager.Instance.ObjectDataList.FirstOrDefault(x => x.name == hitObj.name);

                    if (objectData != null)
                    {
                        objectBase.TouchEvent();
                        PlayerViewModel.Instance.CurrentObjectData = objectData;
                    }

                    if(objectBase != null) PlayerViewModel.Instance.CurrentObjectBase = objectBase;
                    UIManager.Instance.Show(PopupStyle.Dialog);
                }

                else if(hit.collider.CompareTag("Cat"))
                {
                    var cat = hitObj.GetComponent<Cat>();
                    if (cat != null) cat.SaveData();
                }
            }
        }
    }
}

