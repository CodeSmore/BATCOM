using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinballPauseController : MonoBehaviour {
	[SerializeField]
	private GameObject pauseMenu = null, confirmQuitMenu = null, countdownPanel = null;
	[SerializeField]
	private Text countdownText = null;
	[SerializeField]
	private float timeToCountDown = 3;

	[SerializeField]
	private Slider soundFXSlider = null, musicSlider = null;

	[SerializeField]
	private AudioSource pinballSource = null;
	private AudioSource musicSource, soundFXSource;

	private float timer = 0;
	private bool countingDown = false;

	private Rigidbody2D ballRigidbody;
	private Vector2 ballVelocityOnPause;

	void Awake () {
		if (GameObject.Find("BackgroundMusic")) {
			musicSource = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
			soundFXSource = GameObject.FindObjectOfType<SoundController>().GetComponent<AudioSource>();
		} 

		timer = timeToCountDown;

		ballRigidbody = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>();
		pinballSource.volume = PlayerPrefsManager.GetSoundFXVolume();

		pauseMenu.SetActive(false);
	}

	void OnEnable () {
		UpdateSliders();

	}

	void Update () {
		if (countingDown) {
			timer -= Time.deltaTime;

			ManageCountdownText();
			if (timer <= 0) {
				ballRigidbody.isKinematic = false;
				ballRigidbody.velocity = ballVelocityOnPause;
				//remove countdown panel
				countdownPanel.SetActive(false);

				countingDown = false;

				timer = timeToCountDown;
			}
		}
	}

	public void OpenMenu () {
		pauseMenu.SetActive(true);

		ballVelocityOnPause = ballRigidbody.velocity;

		ballRigidbody.isKinematic = true;

		ballRigidbody.velocity = Vector2.zero;
	}

	public void CloseMenu () {
		pauseMenu.SetActive(false); 
		// enable countdown panel
		countdownPanel.SetActive(true);

		countingDown = true;
	}

	public void OpenQuitMenu () {
		confirmQuitMenu.SetActive(true);
	}

	public void CloseQuitMenu () {
		confirmQuitMenu.SetActive(false);
	}

	void ManageCountdownText () {
		// update text element
		countdownText.text = Mathf.CeilToInt(timer).ToString();
	}

	public void UpdateSliders () {
		soundFXSlider.value = PlayerPrefsManager.GetSoundFXVolume();
		musicSlider.value = PlayerPrefsManager.GetMusicVolume();
	}

	public void SaveSliderValues () {
		PlayerPrefsManager.SetSoundFXVolume(soundFXSlider.value);
		PlayerPrefsManager.SetMusicVolume(musicSlider.value);

		soundFXSource.volume = soundFXSlider.value;
		musicSource.volume = musicSlider.value;
		pinballSource.volume = soundFXSlider.value;
	}
}
