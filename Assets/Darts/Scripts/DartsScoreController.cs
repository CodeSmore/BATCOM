using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DartsScoreController : MonoBehaviour {

	[SerializeField]
	private Text scoreText = null;

	private int currentScore = 0;

	// Use this for initialization
	void Start () {
		scoreText.text = "0";
		currentScore = 0;
	}
	
	private void UpdateText () {
		scoreText.text = currentScore.ToString();
	}

	public void AddScore (int addition) {
		currentScore += addition;

		UpdateText();
	}

	public int GetScore () {
		return currentScore;
	}
}
