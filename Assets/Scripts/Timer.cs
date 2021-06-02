using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text _timerText;
    private string _format = "0";

    private float _currentTime = 0f;
    private bool _isPaused;

    public float CurrentTime => _currentTime;


    public void StartTimer()
    {
        _isPaused = false;
        UpdateUI();
    }
  private void Update()
    {
        if(_isPaused)
            return;
        _currentTime = Mathf.Max(0, _currentTime + Time.deltaTime);
        UpdateUI();
    }
    private void UpdateUI()
    {
        _timerText.text = _currentTime.ToString(_format);
    }

    public void Pause(bool value)
    {
        _isPaused = value;
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
}
