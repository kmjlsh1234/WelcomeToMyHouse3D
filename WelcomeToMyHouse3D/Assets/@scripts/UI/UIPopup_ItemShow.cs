using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPopup_ItemShow : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private TMP_Text _titleText;
    private Coroutine _showCoroutine;

    private void Start()
    {
        if (_showCoroutine != null) StopCoroutine(_showCoroutine);
        _showCoroutine = StartCoroutine(ShowPopup());
    }


    IEnumerator ShowPopup()
    {
        yield return null;
    }
}
