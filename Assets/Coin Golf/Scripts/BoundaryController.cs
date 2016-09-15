using UnityEngine;
using System.Collections;

public class BoundaryController : MonoBehaviour {
	private CoinGameController gameController;

	// Use this for initialization
	void Start () {
		gameController = FindObjectOfType<CoinGameController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit2D (Collider2D collider) {
		if (collider.tag == "Coin") {
			// end game
			gameController.EndGame();
		}

		if (collider.tag == "Coin Stack") {
			Destroy(collider.gameObject);
		}
	}
}
