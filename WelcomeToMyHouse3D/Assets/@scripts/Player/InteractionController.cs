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

        [SerializeField] private const float interactionDist = 5f;

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

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionDist))
            {
                var hitObj = hit.collider.gameObject;
                if (hit.collider.CompareTag("Object"))
                {
                    var objectBase = hitObj.GetComponent<ObjectBase>();
                    if (objectBase != null)
                    {
                        PlayerViewModel.Instance.CurrentObjectBase = objectBase;
                        objectBase.TouchEvent();
                    } 
                }

                else if(hit.collider.CompareTag("Cat"))
                {
                    var cat = hitObj.GetComponent<Cat>();
                    if (cat != null) cat.SaveData();
                }

                else if(hit.collider.CompareTag("Door"))
                {
                    var door = hitObj.GetComponent<Door>();
                    if (door != null) door.DoorActive();
                }
            }
        }
    }
}

