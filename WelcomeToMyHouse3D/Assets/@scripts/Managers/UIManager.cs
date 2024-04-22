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
using Assets.Scripts.UI;

namespace Assets.Scripts.Manager
{
    public class UIManager : SingletonBase<UIManager>
    {
        public PopupBase[] PopupList;

        protected override void Awake()
        {
            base.Awake();
            var canvas = GameObject.FindAnyObjectByType<Canvas>().transform;
            PopupList = canvas.GetComponentsInChildren<PopupBase>();

            foreach (PopupBase child in PopupList)
                child.gameObject.SetActive(false);
        }

        public void Show(PopupStyle style)
        {
            var uiObj = PopupList.FirstOrDefault(x => x._style == style);

            uiObj.gameObject.SetActive(true);
            uiObj.SetData();
        }

        public void Hide(PopupStyle style)
        {
            var uiObj = PopupList.FirstOrDefault(x => x._style == style);
            uiObj.gameObject.SetActive(false);
        }

    }
}

