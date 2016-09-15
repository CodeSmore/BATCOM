using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinGolfScoreController : MonoBehaviour {
	private int currentScore = 0, roundScore = 0;

	[SerializeField]
	private Text scoreText = null, roundScoreText = null;

	// Use this for initialization
	void Start () {
		roundScore = 50;

		UpdateText();
	}

	public int GetScore () {
		return currentScore;
	}

	public void AddPoints () {
		currentScore += roundScore;

		ResetRoundScore();
		UpdateText();
	}

	public void DecreaseRoundScore () {
		roundScore -= 10;

		UpdateText();
	}

	void UpdateText () {
		scoreText.text = currentScore.ToString();
		roundScoreText.text = roundScore.ToString();
	}

	public void ResetRoundScore () {
		roundScore = 50;
	}
}
