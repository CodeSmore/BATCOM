using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseController : MonoBehaviour {
	[SerializeField]
	private GameObject pauseMenu = null, confirmQuitMenu = null;


	private AudioSource soundFXSource;
	private AudioSource backgroundMusicSource;

	[SerializeField]
	private Slider soundFXSlider = null, musicSlider = null;


	private float sliderWorkTimer = 0;

	void Awake () {
		if (GameObject.Find("BackgroundMusic")) {
			backgroundMusicSource = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
			soundFXSource = GameObject.FindObjectOfType<SoundController>().GetComponent<AudioSource>();
		} 

		UpdateSliders();
		pauseMenu.SetActive(false);
	}

	void Update () {
		sliderWorkTimer += Time.deltaTime;
	}

	void OnDisable () {
		sliderWorkTimer = 0;
	}

	void OnEnable () {
		sliderWorkTimer = 0;
		UpdateSliders();
	}

	public void OpenMenu () {
		pauseMenu.SetActive(true);

		Time.timeScale = 0;
	}

	public void CloseMenu () {
		pauseMenu.SetActive(false); 

		Time.timeScale = 1;
	}

	public void OpenQuitMenu () {
		confirmQuitMenu.SetActive(true);
	}

	public void CloseQuitMenu () {
		confirmQuitMenu.SetActive(false);
	}

	public void UpdateSliders () {
		if (soundFXSlider) {
			soundFXSlider.value = PlayerPrefsManager.GetSoundFXVolume();
			musicSlider.value = PlayerPrefsManager.GetMusicVolume();
		}
	}

	public void SaveSliderValues () {
		if (sliderWorkTimer > 0.1) {
			PlayerPrefsManager.SetSoundFXVolume(soundFXSlider.value);
			PlayerPrefsManager.SetMusicVolume(musicSlider.value);
				
			soundFXSource.volume = soundFXSlider.value;
			backgroundMusicSource.volume = musicSlider.value;
		}
	}
}
