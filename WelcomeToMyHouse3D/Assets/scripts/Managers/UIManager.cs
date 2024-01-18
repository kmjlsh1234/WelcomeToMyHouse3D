using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.Manager.Base;
using DG.Tweening;
using UniRx;

namespace Assets.Scripts.Manager
{
    public class UIManager : SingletonBase<UIManager>
    {
        [Header("DialogSystem")]
        [SerializeField] private GameObject _dialogUI;
        [SerializeField] private TMP_Text _dialogText;
        [SerializeField] private GameObject _choiceSystem;
        [SerializeField] private Button _choiceAButton;
        [SerializeField] private Button _choiceBButton;
        [SerializeField] private TMP_Text _choiceAText;
        [SerializeField] private TMP_Text _choiceBText;
        private ItemData _currentItemData = null;

        protected override void Awake()
        {
            base.Awake();
            AddEvent();
        }

        private void AddEvent()
        {
            _choiceAButton.OnClickAsObservable().Subscribe(_ => OnClickAButton());
            _choiceBButton.OnClickAsObservable().Subscribe(_ => OnClickBButton());
        }

        public void OnOffDialog(bool isOn)
        {
            if (isOn) _currentItemData = PlayerViewModel.Instance.CurrentItemData;
            _dialogUI.SetActive(isOn);
            
        }

        public void OnOffChoiceSystem(bool isOn)
        {
            _choiceSystem.SetActive(isOn);
        }

        public void DialogSystem(string narationScript)
        {
            _dialogText.text = string.Empty;
            Tweener tweener = DOTween.To(() => _dialogText.text, x => _dialogText.text = x, narationScript, narationScript.Length * 0.05f)
            .SetEase(Ease.Linear)
            .OnComplete(() => CheckFinishScript(narationScript));
        }

        private void CheckFinishScript(string narationScript)
        {
            if (_currentItemData.ItemType == Common.ItemType.NotChoiceItem) return;

            string A = _currentItemData.InteractionScript[_currentItemData.InteractionScript.Length - 1];
            string B = narationScript;
            if (string.Equals(A,B))
            {
                _choiceAText.text = _currentItemData.ChoiceA;
                _choiceBText.text = _currentItemData.ChoiceB;
                OnOffChoiceSystem(true);
            }
        }

        private void OnClickAButton()
        {
            PlayerViewModel.Instance.CurrentItemBase.ChoiceAButtonClick();
            OnOffChoiceSystem(false);
        }

        private void OnClickBButton()
        {
            PlayerViewModel.Instance.CurrentItemBase.ChoiceBButtonClick();
            OnOffChoiceSystem(false);
        }
    }
}

