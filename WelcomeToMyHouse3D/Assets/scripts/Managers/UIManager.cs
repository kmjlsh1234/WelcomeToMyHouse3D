using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Scripts.Manager.Base;
using DG.Tweening;

namespace Assets.Scripts.Manager
{
    public class UIManager : SingletonBase<UIManager>
    {
        [SerializeField] private GameObject _dialogUI;
        [SerializeField] private TMP_Text _dialogText;

        protected override void Awake()
        {
            base.Awake();
            AddEvent();
        }

        private void AddEvent()
        {

        }

        public void OnOffDialog(bool isOn)
        {
            _dialogUI.SetActive(isOn);
        }

        public void DialogSystem(string narationScript)
        {
            _dialogText.text = string.Empty;
            DOTween.To(() => _dialogText.text, x => _dialogText.text = x, narationScript, narationScript.Length * 0.05f).SetEase(Ease.Linear);
            
        }
    }
}

