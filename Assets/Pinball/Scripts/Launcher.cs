using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour {

	[SerializeField]
	private GameObject launcherSpring;
	[SerializeField]
	private Rigidbody2D ballRigidbody = null;

	[SerializeField]
	private float launchPower = 0;

	[SerializeField]
	private float downLerpSpeed = 1, upLerpSpeed = 5;

	[SerializeField]
	private BoxCollider2D launcherTopCollider = null;

	private SoundController soundController;

	void Start () {
		soundController = GameObject.FindObjectOfType<SoundController>();
	}

	// TODO lerp faster
	void OnMouseDrag () {
		transform.position = Vector3.Lerp (transform.position, new Vector3 (transform.position.x, Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -4.5f, -3.35f), transform.position.z), Time.deltaTime * downLerpSpeed);
		AdjustLauncherSpring();
	}

	void OnMouseUp () {
		LaunchBall();
	}

	// TODO make spring wider as launcher is pulled down
	void AdjustLauncherSpring () {

	}

	void LaunchBall () {
		// apply upwards force to ball
		launcherTopCollider.enabled = false;
		ballRigidbody.AddForce(new Vector2 (0, launchPower * (Mathf.Abs(3.5f + transform.position.y))));

		// play sound
		soundController.PlayBallShooterClip();
	}

	public void ResetLauncher () {
		int safetyExitCounter = 0;

		// used counter as waiting for position get high enough resulted in an infinite loop (somehow)
		while (safetyExitCounter < 100) {
			transform.position = Vector3.Lerp (transform.position, new Vector3 (transform.position.x, -2, transform.position.z), Time.deltaTime * upLerpSpeed);

			transform.position = new Vector3 (transform.position.x, Mathf.Clamp(transform.position.y, -4.5f, -3.5f), transform.position.z);

			safetyExitCounter++;
		} 

		launcherTopCollider.enabled = true;
	}
}
