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
        [Header("DialogSystem")]
        [SerializeField] private GameObject _dialogUI;
        [SerializeField] private TMP_Text _dialogText;
        [SerializeField] private GameObject _choiceSystem;
        [SerializeField] private TMP_Text _choiceAText;
        [SerializeField] private TMP_Text _choiceBText;

        public void OnOffDialog(bool isOn, bool isChoiceSystemOn)
        {
            _dialogUI.SetActive(isOn);
            _choiceSystem.SetActive(isChoiceSystemOn);
        }

        

        public void DialogSystem(string narationScript)
        {
            _dialogText.text = string.Empty;
            DOTween.To(() => _dialogText.text, x => _dialogText.text = x, narationScript, narationScript.Length * 0.05f).SetEase(Ease.Linear).OnComplete(CheckNaractionFinish);
        }

        private void CheckNaractionFinish()
        {

        }
    }
}

