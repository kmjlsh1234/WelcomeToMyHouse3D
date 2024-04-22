using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Assets.Scripts.Manager;

namespace Assets.Scripts.UI
{
    public class UIPopup_Fade : PopupBase
    {
        private Image _image;
        private Coroutine _fadeRoutine;
        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public override void SetData()
        {
            base.SetData();
            if (_fadeRoutine != null) StopCoroutine(_fadeRoutine);
            _fadeRoutine = StartCoroutine(FadeInOut());
        }

        IEnumerator FadeInOut()
        {
            _image.DOFade(0f, 0f);
            _image.DOFade(1f, 1f);
            yield return new WaitForSeconds(3f);
            _image.DOFade(0f, 3f);
            yield return new WaitForSeconds(3f);
            UIManager.Instance.Hide(_style);
        }
    }
}

