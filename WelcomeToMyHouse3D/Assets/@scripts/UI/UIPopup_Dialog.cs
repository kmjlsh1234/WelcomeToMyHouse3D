using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Assets.Scripts.Util;
using Assets.Scripts.Manager;
using Assets.Scripts.Common;

namespace Assets.Scripts.UI
{
    public class UIPopup_Dialog : PopupBase
    {
        [SerializeField] private TMP_Text _infoText;
        [SerializeField] private TMP_Text _choiceAText;
        [SerializeField] private TMP_Text _choiceBText;

        [SerializeField] private Button _choiceAButton;
        [SerializeField] private Button _choiceBButton;
        [SerializeField] private Button _dialogButton;
        private PopupStyle _popupStyle;

        private const float TYPING_SPEED = 0.05f;
        private int _scriptNum = 0;
        private ObjectData _data = null;

        private Coroutine _typingCoroutine = null;

        private void Start()
        {
            AddEvent();
        }

        #region ::::InitSetting
        private void AddEvent()
        {
            _choiceAButton.OnSoundClickAsObservable().Subscribe(_ => OnClickChoiceA()).AddTo(gameObject);
            _choiceBButton.OnSoundClickAsObservable().Subscribe(_ => OnClickChoiceB()).AddTo(gameObject);
            _dialogButton.OnSoundClickAsObservable().Subscribe(_ => Dialog()).AddTo(gameObject);
        }

        public override void SetData()
        {
            _data = PlayerViewModel.Instance.CurrentObjectData;
            _choiceAText.text = _data.ChoiceA;
            _choiceBText.text = _data.ChoiceB;
            _scriptNum = 0;

            _infoText.text = string.Empty;

            _choiceAButton.gameObject.SetActive(false);
            _choiceBButton.gameObject.SetActive(false);

            Dialog();
        }
        #endregion



        #region ::::ButtonMethod
        public void Dialog()
        {
            if (_scriptNum == _data.InteractionScript.Length)
            {
                switch (_data.ObjectType)
                {
                    case ObjectType.NotChoiceObject:
                        UIManager.Instance.Hide(PopupStyle.Dialog);
                        break;
                    case ObjectType.ChoiceObject:
                        ButtonShow();
                        break;
                }
            }
            else
            {
                if (_typingCoroutine != null) StopCoroutine(_typingCoroutine);
                _typingCoroutine = StartCoroutine(TypingText(_data.InteractionScript[_scriptNum]));

                _scriptNum++;
            }

        }

        private void OnClickChoiceA()
        {
            PlayerViewModel.Instance.CurrentObjectBase.ChoiceAEvent();
            UIManager.Instance.Hide(PopupStyle.Dialog);
        }

        private void OnClickChoiceB()
        {
            PlayerViewModel.Instance.CurrentObjectBase.ChoiceBEvent();
            UIManager.Instance.Hide(PopupStyle.Dialog);
        }
        #endregion

        private void ButtonShow()
        {
            _choiceAButton.gameObject.SetActive(true);
            _choiceBButton.gameObject.SetActive(true);
        }

        IEnumerator TypingText(string targetText)
        {
            _infoText.text = string.Empty;
            var charLength = targetText.Length;
            for (int i = 0; i < charLength; i++)
            {
                _infoText.text += targetText[i];
                yield return new WaitForSeconds(TYPING_SPEED);
            }
        }
    }
}

