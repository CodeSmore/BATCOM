using UnityEngine;
using System.Collections;

public class Bumper : MonoBehaviour {
	[SerializeField]
	private int pointValue = 0;

	private Animator bumperAnimator;

	private PinballScoreController scoreController;
	private SoundController soundController;

	// Use this for initialization
	void Start () {
		bumperAnimator = GetComponent<Animator>();
		scoreController = GameObject.FindObjectOfType<PinballScoreController>();
		soundController = GameObject.FindObjectOfType<SoundController>();
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "Ball") {
			scoreController.AdjustScore(pointValue);

			if (gameObject.tag == "Bumper Type 1") {
				soundController.PlayMultipleBumperHitsClip();
			} else if (gameObject.tag == "Bumper Type 2") {
				soundController.PlaySingleBumperHitClip();
			}

			// bump animation
			bumperAnimator.SetTrigger("BumpTrigger");
		}
	}
}
