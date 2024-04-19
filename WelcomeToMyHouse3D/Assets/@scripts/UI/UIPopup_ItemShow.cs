using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Assets.Scripts.Manager;
using Assets.Scripts.Common;

public class UIPopup_ItemShow : MonoBehaviour
{
    [SerializeField] private TMP_Text _titleText;
    private Coroutine _showCoroutine;

    private void Start()
    {
        SetData();
    }

    private void SetData()
    {
        _titleText.text = $"{PlayerViewModel.Instance.CurrentItemName} È¹µæ";
        if (_showCoroutine != null) StopCoroutine(_showCoroutine);
        _showCoroutine = StartCoroutine(ShowPopup());
    }


    IEnumerator ShowPopup()
    {
        _titleText.DOFade(0f, 0f);
        _titleText.DOFade(1f, 1f);
        yield return new WaitForSeconds(2f);
        _titleText.DOFade(0f, 1f);
        yield return new WaitForSeconds(1f);
        UIManager.Instance.Hide(PopupStyle.ItemShow);
    }
}
