using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinGolfScoreController : MonoBehaviour {
	private int currentScore;

	[SerializeField]
	private Text scoreText = null;

	// Use this for initialization
	void Start () {
		UpdateText();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int GetScore () {
		return currentScore;
	}

	public void AddPoints (int points) {
		currentScore += points;

		UpdateText();
	}

	void UpdateText () {
		scoreText.text = currentScore.ToString();
	}
}
