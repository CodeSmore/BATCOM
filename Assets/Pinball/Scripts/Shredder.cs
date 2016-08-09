using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Shredder : MonoBehaviour {
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnTriggerExit2D (Collider2D collider) {
		if (collider.tag == "Ball") {
			levelManager.ResetLevel();
		}
	}
}
