using Assets.Scripts.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Object
{
    public class FirstFloor_SafeButton : MonoBehaviour
    {
        [SerializeField] private FirstFloor_Safe _parent;
        private string _keyCode = string.Empty;
        
        private void Start()
        {
            foreach (Transform child in transform)
                child.name.Replace("(Clone)", "");
        }

        public void ResetData()
        {
            _keyCode = string.Empty;

            
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                    CastRay();
            }
        }

        private void KeyCodeAdd(string code)
        {
            SoundManager.Instance.PlaySound(Common.SFXName.SFX_Click);
            _keyCode += code;
        }

        private void CastRay()
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                var hitObj = hit.collider.gameObject;
                switch(hitObj.name)
                {
                    case "Button_1":
                        KeyCodeAdd("1");
                        break;
                    case "Button_2":
                        KeyCodeAdd("2");
                        break;
                    case "Button_3":
                        KeyCodeAdd("3");
                        break;
                    case "Button_4":
                        KeyCodeAdd("4");
                        break;
                    case "Button_5":
                        KeyCodeAdd("5");
                        break;
                    case "Button_6":
                        KeyCodeAdd("6");
                        break;
                    case "Button_7":
                        KeyCodeAdd("7");
                        break;
                    case "Button_8":
                        KeyCodeAdd("8");
                        break;
                    case "Button_9":
                        KeyCodeAdd("9");
                        break;
                    case "Button_0":
                        KeyCodeAdd("0");
                        break;
                    case "Button_Finish":
                        _parent.FinishButtonClick(_keyCode);
                        break;
                    case "Button_Back":
                        _parent.BackButtonClick();
                        break;
                }
            }
        }
    }
}

