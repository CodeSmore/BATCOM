using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Shredder : MonoBehaviour {
	private PinballGameController gameController;

	// Use this for initialization
	void Start () {
		gameController = GameObject.FindObjectOfType<PinballGameController>();
	}

	void OnTriggerExit2D (Collider2D collider) {
		if (collider.tag == "Ball") {
			Destroy(collider.gameObject);
			gameController.EndGame();
		}
	}
}
