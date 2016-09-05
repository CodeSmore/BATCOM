using UnityEngine;
using System.Collections;

public class BoundaryController : MonoBehaviour {
	private LevelManager levelManager;
	private CoinController coinController;
	private CoinGameController gameController;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
		coinController = FindObjectOfType<CoinController>();
		gameController = FindObjectOfType<CoinGameController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit2D (Collider2D collider) {
		if (collider.tag == "Coin") {
			// reset position
			coinController.ResetCoin();
			// reset flick counter
			gameController.ResetFlickCount();
		}
	}
}
