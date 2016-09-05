using UnityEngine;
using System.Collections;

enum Direction {Up, Down};

public class Booster : MonoBehaviour {
	[SerializeField]
	private Direction boosterDirection = Direction.Up;
	[SerializeField]
	private float boosterForce = 0, pointValue = 0;

	private Rigidbody2D ballRigidbody;
	private PinballScoreController scoreController;
	private SoundController soundController;

	// Use this for initialization
	void Start () {
		ballRigidbody = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>();
		scoreController = GameObject.FindObjectOfType<PinballScoreController>();
		soundController = GameObject.FindObjectOfType<SoundController>();
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag == "Ball") {
			scoreController.AdjustScore((int)pointValue);
			soundController.PlaySpeedBoostClip();
		}
	}

	void OnTriggerStay2D (Collider2D collider) {	
		if (collider.gameObject.tag == "Ball") {

			if (boosterDirection == Direction.Up) {
				ballRigidbody.AddForce(Vector2.up * boosterForce);
			} else if (boosterDirection == Direction.Down) {
				ballRigidbody.AddForce(Vector2.down * boosterForce);
			}
		}
	}
}
