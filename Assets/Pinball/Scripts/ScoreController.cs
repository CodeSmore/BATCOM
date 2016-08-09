using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour {
	private float currentScore = 0; 

	[SerializeField]
	private Text scoreText = null;

	// Use this for initialization
	void Start () {
		UpdateScore();
	}
	
	// Update is called once per frame
	void UpdateScore () {
		scoreText.text = currentScore.ToString();
	}

	public void AdjustScore (int points) {
		currentScore += points;

		UpdateScore();
	}
}
