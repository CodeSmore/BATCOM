using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (SceneManager.GetActiveScene().buildIndex == 1) {
			Screen.orientation = ScreenOrientation.Landscape;
		} else {
			Screen.orientation = ScreenOrientation.Portrait;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ResetLevel () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void LoadLevel (string levelName) {
		SceneManager.LoadScene(levelName);
	}
}
