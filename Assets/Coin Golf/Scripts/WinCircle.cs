using UnityEngine;
using System.Collections;

public class WinCircle : MonoBehaviour {
	private CoinGameController gameController;
	private CoinGolfScoreController scoreController;
	private ObstaclePlacementController placementController;

	private bool coinLeftCircle = true;
	// Use this for initialization
	void Start () {
		gameController = GameObject.FindObjectOfType<CoinGameController>();
		scoreController = GameObject.FindObjectOfType<CoinGolfScoreController>();
		placementController = GameObject.FindObjectOfType<ObstaclePlacementController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D (Collider2D collider) {
		if (collider.tag == "Coin" && coinLeftCircle) {
			CoinController coinController = collider.GetComponent<CoinController>();

			// wont detect if velocity is zero, so, here we are, testing for zero
			if (!coinController.IsCoinMoving()) {
				// give points
				scoreController.AddPoints();
				// reset position
				coinController.ResetCoin();
				// reset flick counter
				gameController.ResetFlickCount();
				// reset placement
				placementController.RandomizeTable();

				// used as condition b/c OnTriggerStay is called twice despite ResetCoin removing coin :/
				coinLeftCircle = false;
			}
		}
	} 

	void OnTriggerExit2D (Collider2D collider) {
		if (collider.tag == "Coin") {
			coinLeftCircle = true;
		}
	}
}
