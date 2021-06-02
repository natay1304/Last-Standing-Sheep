using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
	public AudioSource Sound;
	public AudioSource Music;

	[SerializeField] private ToggleController _toggleMusic;
	[SerializeField] private ToggleController _toggleSound;

	[SerializeField] private Button _closeBotton;
	[SerializeField] private GameObject _settingsPanel;

	private void Awake()
	{
		if (!PlayerPrefs.HasKey("Sound"))
			PlayerPrefs.SetInt("Sound", 1);

		if (!PlayerPrefs.HasKey("Music"))
			PlayerPrefs.SetInt("Music", 1);

		Sound.mute = PlayerPrefs.GetInt("Sound") == 0;
		Music.mute = PlayerPrefs.GetInt("Music") == 0;
		
		Music.Play();
		_toggleMusic.SetValue(!Music.mute);
		_toggleSound.SetValue(!Sound.mute);

		_toggleMusic.OnValueChanged += MusicValueChangedHandler;
		_toggleSound.OnValueChanged += SoundValueChangedHandler;
		_closeBotton.onClick.AddListener(SettingsPanelHandler);
	}

	private void SettingsPanelHandler()
	{
		Sound.Play();
	}

	private void SoundValueChangedHandler(bool value)
	{
		Sound.mute = !value;
		PlayerPrefs.SetInt("Sound", value ? 1 : 0);
	}

	private void MusicValueChangedHandler(bool value)
	{
		Music.mute = !value;
		PlayerPrefs.SetInt("Music", value ? 1 : 0);
	}
}