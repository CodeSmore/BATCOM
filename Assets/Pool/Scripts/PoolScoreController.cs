using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PoolScoreController : MonoBehaviour {

	[SerializeField]
	private int inOrderPointValue = 0, outOfOrderPointValue = 0;
	[SerializeField]
	private Text scoreText = null;

	private int currentScore = 0;

	private GameController gameController;
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		gameController = GameObject.FindObjectOfType<GameController>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
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

		if (gameController.AreAllBallsGone()) {
			CurrencyController.AddCurrency(currentScore);
			levelManager.LoadLevel("Home");
		}
	}


}
