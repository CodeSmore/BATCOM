using UnityEngine;
using System.Collections;

public class LandPoint : MonoBehaviour {
	private DartsScoreController scoreController;

	private int score = 0;

	//delay is to allow all triggers before score is recorded
	private float delay = 0.5f;
	private float counter = 0;
	private bool scoreCounted = false;


	// Use this for initialization
	void Start () {
		scoreController = GameObject.FindObjectOfType<DartsScoreController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (scoreCounted == false) {
			if (counter > delay) {
				scoreController.AddScore(score);
				scoreCounted = true;
			} else {
				counter += Time.deltaTime;
			}
		}

	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "DartLandSlot") {
			int targetScore = collider.GetComponentInParent<PointArea>().GetPointValue();

			if (targetScore > score) {
				score = targetScore;
			}
		}

	}
}
