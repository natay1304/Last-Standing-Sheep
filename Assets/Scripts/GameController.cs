using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
	[SerializeField] private Button _settingsButton;
	[SerializeField] private Button _loadPauseButton;
	[SerializeField] private Button _loadMenuButton;
	[SerializeField] private GameObject _pausePanel;
	[SerializeField] private GameObject _settingsPanel;
	[SerializeField] private AudioSource _sound;

	[SerializeField] private GameObject _gameOverPanel;
	[SerializeField] private GameOverView _gameOverView;
	[SerializeField] private GameRecordsLoader _gameRecordsLoader;
	[SerializeField] private PlayerInput _player;

	[SerializeField] private Timer _timer;

	[SerializeField] private int _enemyCount;
	[SerializeField] private Spawner _spawner;
	private bool _gameOver;

	private void Awake()
	{
		_settingsButton.onClick.AddListener(SettingsButtonHandler);
		_loadPauseButton.onClick.AddListener(PauseButtonHandler);
		_loadMenuButton.onClick.AddListener(LoadMenuHandler);

		_spawner.Spawn(_enemyCount);
	}

	private void Start()
	{
		_timer.StartTimer();
		_player.OnPlayerFallen += OnPlayerFallenHandler;
		_spawner.OnAllEnemiesFallen += OnAllEnemiesFallenHandler;
	}

	private void OnAllEnemiesFallenHandler()
	{
		_gameOverView.SetText("Y O U  W I N");
		_gameOverPanel.SetActive(true);
		_timer.Pause(true);
		_gameRecordsLoader.AddPlayerResult("MY NAME", _timer.CurrentTime);
	}

	private void OnPlayerFallenHandler()
	{
		_gameOverView.SetText("Y O U  L O S E");
		_gameOverPanel.SetActive(true);
		_timer.Pause(true);
		_gameRecordsLoader.AddPlayerResult("MY NAME", _timer.CurrentTime);
	}

	private void LoadMenuHandler()
	{
		SceneManager.LoadScene("menu");
		_sound.Play();
	}

	private void PauseButtonHandler()
	{
		_pausePanel.SetActive(true);
		_sound.Play();
	}

	private void SettingsButtonHandler()
	{
		_settingsPanel.SetActive(true);
		_sound.Play();
	}
}