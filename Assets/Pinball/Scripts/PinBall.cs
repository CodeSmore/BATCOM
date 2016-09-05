using UnityEngine;
using System.Collections;

public class PinBall : MonoBehaviour {
	private Rigidbody2D ballRigidbody;

	// Use this for initialization
	void Start () {
		ballRigidbody = GetComponent<Rigidbody2D>();
	}

	public bool IsBallMoving () {
		if (ballRigidbody && ballRigidbody.velocity != Vector2.zero) {
			return true;
		}

		return false;
	}
}
