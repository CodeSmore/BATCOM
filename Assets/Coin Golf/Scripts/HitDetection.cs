using UnityEngine;
using System.Collections;

public class HitDetection : MonoBehaviour {
	private CoinSoundController soundController;

	// Use this for initialization
	void Start () {
		soundController = GameObject.FindObjectOfType<CoinSoundController>();
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "Coin") {
			// play sound
			if (gameObject.tag == "Metal") {
				soundController.PlayHitMetal();
			} else if (gameObject.tag == "Coin Stack") {
				soundController.PlayHitCoinStack();
			}
		}
	}
}
