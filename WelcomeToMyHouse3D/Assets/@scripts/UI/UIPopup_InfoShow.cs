using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Assets.Scripts.Manager;
using Assets.Scripts.Common;
using UniRx;
using Assets.Scripts.Util;
using System.Linq;

namespace Assets.Scripts.UI
{
    public class UIPopup_InfoShow : PopupBase
    {
        [SerializeField] private TMP_Text _infoText;
        private Button _touchScreen;

        private Coroutine _typingRoutine;
        private string[] _infoShowText;
        private int _currentCount = 0;

        private void Start()
        {
            _touchScreen = GetComponent<Button>();
            _touchScreen.OnSoundClickAsObservable().Subscribe(_ => OnClickTouchButton()).AddTo(gameObject);
        }

        public override void SetData()
        {
            _currentCount = 0;
            var data = ResourceManager.Instance.ObjectDataList.FirstOrDefault(x => x.name == PlayerViewModel.Instance.CurrentObjectName);
            if(data!=null)
            {
                _infoShowText = data.InteractionScript;
                ShowText();
            }
        }

        private void OnClickTouchButton()
        {
            if(CheckFinish())
            {
                PlayerViewModel.Instance.CurrentObjectName = string.Empty;
                PlayerViewModel.Instance.Player._canMove = true;
                PlayerViewModel.Instance.Player._canRotate = true;
                UIManager.Instance.Hide(_style);
            }
            else
            {
                _currentCount++;
                ShowText();

            }
        }

        private bool CheckFinish()
        {
            if (_currentCount == _infoShowText.Length - 1) return true;
            else return false;
        }

        private void ShowText()
        {
            if (_typingRoutine != null) StopCoroutine(_typingRoutine);
            _typingRoutine = StartCoroutine(TypingText(_infoShowText[_currentCount]));
        }

        IEnumerator TypingText(string text)
        {
            _infoText.text = string.Empty;
            for(int i=0; i<text.Length;i++)
            {
                _infoText.text += text[i];
                yield return new WaitForSeconds(0.05f);
            }
        }

        public override void Dispose()
        {
            _infoText = null;
            _touchScreen = null;
            _infoShowText = null;
            if (_typingRoutine != null)
            {
                StopCoroutine(_typingRoutine);
                _typingRoutine = null;
            }
        }
    }
}

