using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResultsView : MonoBehaviour
{
    [SerializeField]
    private LeaderTimeView _leaderTimeViewPrefab;
    [SerializeField]
    private Transform _container;

    [SerializeField]
    private Button _backToMenu;
    [SerializeField]
    private AudioSource _sound;

    private void Start()
    {
        _backToMenu.onClick.AddListener(BackToMenuHandler);
    }

    private void BackToMenuHandler()
    {
        _sound.Play();
    }

    public void Initialize(Level level)
    {
        foreach (var leaderInfo in level.leaderboard)
        {
            //Debug.Log(leaderInfo.name);
            var leaderTimeView = Instantiate(_leaderTimeViewPrefab, _container);
            leaderTimeView.Initialize(leaderInfo);
        }
    }
}
