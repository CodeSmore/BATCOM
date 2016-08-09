using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PoolScoreController : MonoBehaviour {

	[SerializeField]
	private float inOrderPointValue = 0, outOfOrderPointValue = 0;
	[SerializeField]
	private Text scoreText = null;

	private float currentScore = 0;

	// Use this for initialization
	void Start () {
		UpdateScoreText();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ScoreInOrderPoint () {
		currentScore += inOrderPointValue;

		UpdateScoreText();
	}

	public void ScoreOutOfOrderPoint () {
		currentScore += outOfOrderPointValue;

		UpdateScoreText();
	}

	public void ScoreBonus (bool inOrder) {
		if (inOrder) {
			currentScore += 4;
		} else {
			currentScore += 2;
		}

		UpdateScoreText();
	}

	void UpdateScoreText () {
		scoreText.text = currentScore.ToString();
	}


}
