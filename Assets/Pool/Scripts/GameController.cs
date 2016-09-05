using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	[SerializeField]
	private Rigidbody2D[] allTheBallsRigidbodies = null;
	[SerializeField]
	private Image indicatorImage = null;

	[SerializeField]
	private GameObject touchController = null;

	private BallUIController ballUIController;

	// Use this for initialization
	void Start () {
		ballUIController = GameObject.FindObjectOfType<BallUIController>();
	}
	
	// Update is called once per frame
	void Update () {
		AreAllBallsImmobile();
	}

	public bool AreAllBallsImmobile () {
		// check velocities for all rigidbodies
		foreach (Rigidbody2D rigidbody in allTheBallsRigidbodies) {
			if (rigidbody && rigidbody.velocity != Vector2.zero) {
				indicatorImage.color = Color.red;

				return false;
			}
		}
		indicatorImage.color = Color.green;

		return true;
	}

	public bool AreAllBallsGone () {
		bool areAllGone = true;
		GameObject[] pointBalls = ballUIController.GetPointBallObjects();

		foreach (GameObject ball in pointBalls) {
			if (ball.activeSelf) {
				areAllGone = false;
			}
		}

		if (areAllGone) {
			PrepareEnding();
		}

		return areAllGone;
	}

	void PrepareEnding () {
		// disable touch controller
		touchController.SetActive(false);
	}
}
