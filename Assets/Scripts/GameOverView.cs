using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverView : MonoBehaviour
{
    [SerializeField] private Text _gameOverText;
    [SerializeField] private Button _loadMenu;
    [SerializeField] private Button _restartLevel;

    private void Start()
    {
        _loadMenu.onClick.AddListener(LoadMenuHandler);
        _restartLevel.onClick.AddListener(RestartLevelHandler);
    }

    private void RestartLevelHandler()
    {
        SceneManager.LoadScene("level");
    }

    private void LoadMenuHandler()
    {
        SceneManager.LoadScene("menu");
    }

    public void SetText(string text)
    {
        _gameOverText.text = text;
    }
}
