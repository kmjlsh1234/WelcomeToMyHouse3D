using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.Manager.Base;
using Assets.Scripts.Common;
using DG.Tweening;
using UniRx;
using System.Linq;

namespace Assets.Scripts.Manager
{
    public class UIManager : SingletonBase<UIManager>
    {
        public GameObject[] PopupList;
        private const string UIPATH = "UI";
        protected CompositeDisposable CancelerObject;

        protected override void Awake()
        {
            base.Awake();
            PopupList = Resources.LoadAll<GameObject>(UIPATH);
        }

        public void Show(PopupStyle style)
        {
            var uiObj = PopupList.FirstOrDefault(x => x.name.Contains(style.ToString()));
            if (uiObj == null) return;

            GameObject popup = null;
            popup = Instantiate(uiObj);
            popup.transform.position = Vector3.zero;
            popup.transform.rotation = Quaternion.identity;
            popup.transform.localScale = Vector3.one;
            popup.name = uiObj.name;
            popup.transform.SetParent(this.transform);
        }

        public void Hide(PopupStyle style)
        {
            foreach(Transform child in this.transform)
            {
                if (child.name.Contains(style.ToString()))
                    child.gameObject.SetActive(false);
            }
        }

    }
}

