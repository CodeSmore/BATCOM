using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BarBackgroundSoundController : MonoBehaviour {
	
	void Awake () {
		gameObject.GetComponent<AudioSource>().Play();
	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);

		if (FindObjectsOfType(GetType()).Length > 1) {
			Destroy(gameObject);
		}

		if (SceneManager.GetActiveScene().buildIndex == 0) {
			gameObject.GetComponent<AudioSource>().volume = PlayerPrefsManager.GetMusicVolume();
		}
	}
}
