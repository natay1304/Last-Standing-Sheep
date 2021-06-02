using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Button _play;
    [SerializeField]
    private Button _records;
    [SerializeField]
    private Button _soundsButton;
    [SerializeField]
    private AudioSource _sound;

    [SerializeField]
    private GameObject _soundPanel;
    [SerializeField]
    private GameObject _recordsPanel;

    [SerializeField]
    private string _levelSceneName;
    [SerializeField]
    private GameRecordsLoader _recordsLoader;
    [SerializeField]
    private GameResultsView _gameResultView;
    [SerializeField]
    private GameRecordsLoader _gameResultLoader;

    void Start()
    {
        _play.onClick.AddListener(StartLevel);
        _records.onClick.AddListener(OpenGameRecords);
        _soundsButton.onClick.AddListener(OpenSoundPanel);
    }

    //private void Initialize(List<Level> levels)
    //{
    //    foreach (var level in levels)
    //    {
    //        var gameResults = Instantiate(_gameResultsPrefab, _container);
    //        gameResults.Initialize(level);
    //    }
    //}

    private void OpenSoundPanel()
    {
        _sound.Play();
        _soundPanel.SetActive(true);
    }

    private void OpenGameRecords()
    {
        _sound.Play();
        _gameResultView.Initialize(_gameResultLoader.LevelInfo);
        _recordsPanel.SetActive(true);
        
    }

    private void StartLevel()
    {
        _sound.Play();
        SceneManager.LoadScene(_levelSceneName);
    }
}
