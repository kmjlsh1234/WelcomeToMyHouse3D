using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.Object.Base;
using Assets.Scripts.Manager;
using Assets.Scripts.Common;
using DG.Tweening;
using UniRx;

namespace Assets.Scripts.UI
{
    public class DialogUI : MonoBehaviour
    {
        [Header("DialogSystem")]
        [SerializeField] private TMP_Text _dialogText;
        [SerializeField] private GameObject _choiceSystem;
        [SerializeField] private Button _choiceAButton;
        [SerializeField] private Button _choiceBButton;
        [SerializeField] private TMP_Text _choiceAText;
        [SerializeField] private TMP_Text _choiceBText;

        private ObjectData objectData = null;

        private void Awake()
        {
            AddEvent();
        }

        private void AddEvent()
        {
            _choiceAButton.OnClickAsObservable().Subscribe(_ => OnClickAButton());
            _choiceBButton.OnClickAsObservable().Subscribe(_ => OnClickBButton());
        }

        private void OnEnable()
        {
            SetData();
        }

        private void SetData()
        {
            objectData = PlayerViewModel.Instance.CurrentObjectData;
            if (objectData.ObjectType == ObjectType.ChoiceObject)
            {
                _choiceSystem.SetActive(true);
                _choiceAText.text = objectData.ChoiceA;
                _choiceBText.text = objectData.ChoiceB;
            }
        }

        public void DialogSystem(string narationScript)
        {
            _dialogText.text = string.Empty;
            DOTween.To(() => _dialogText.text, x => _dialogText.text = x, narationScript, narationScript.Length * 0.05f).SetEase(Ease.Linear);
        }

        private void OnClickAButton()
        {

        }

        private void OnClickBButton()
        {

        }
    }
}

