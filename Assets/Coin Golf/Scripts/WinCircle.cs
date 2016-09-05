using UnityEngine;
using System.Collections;

public class WinCircle : MonoBehaviour {
	private LevelManager levelManager;
	private CoinGameController gameController;
	private CoinGolfScoreController scoreController;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		gameController = GameObject.FindObjectOfType<CoinGameController>();
		scoreController = GameObject.FindObjectOfType<CoinGolfScoreController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D (Collider2D collider) {
		if (collider.tag == "Coin") {
			CoinController coinController = collider.GetComponent<CoinController>();

			// wont detect if velocity is zero, so, here we are, testing for zero
			if (!coinController.IsCoinMoving()) {
				// give points
				scoreController.AddPoints(10);
				// reset position
				coinController.ResetCoin();
				// reset flick counter
				gameController.ResetFlickCount();
			}
		}
	} 
}
