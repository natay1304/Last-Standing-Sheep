using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelView : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Button _closeButton;

    private void Start()
    {
        _closeButton.onClick.AddListener(CloseButtonHandler);
    }

    private void OnEnable()
    {
        _animator.SetBool("Close", false);
    }

    private void CloseButtonHandler()
    {
        _animator.SetBool("Close", true);
        StartCoroutine(SetAvtiveDelayed(1f, false));
    }

    private IEnumerator SetAvtiveDelayed(float delay, bool active)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(active);
    }
}
