using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {
	private PauseController pauseController;

	// Use this for initialization
	void Start () {
		if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2) {
			Screen.orientation = ScreenOrientation.Landscape;
		} else {
			Screen.orientation = ScreenOrientation.Portrait;
		}

		pauseController = GameObject.FindObjectOfType<PauseController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ResetLevel () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void LoadLevel (string levelName) {
		if (pauseController) {
			pauseController.SaveSliderValues();
		}
	 
		SceneManager.LoadScene(levelName);

		Time.timeScale = 1;
	}

	public void QuitGame () {
		Application.Quit();
	}
}
