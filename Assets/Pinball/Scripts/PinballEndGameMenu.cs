using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinballEndGameMenu : MonoBehaviour {
	[SerializeField]
	private Text score = null, currencyEarnedText = null, totalCurrency = null;

	private PinballScoreController scoreController;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnEnable () {
		scoreController = GameObject.FindObjectOfType<PinballScoreController>();

		UpdateText();
	}

	void UpdateText () {
		score.text = "Score: " + scoreController.GetScore().ToString();

		int currencyEarned = Mathf.FloorToInt(scoreController.GetScore() / 10);

		currencyEarnedText.text = currencyEarned.ToString();
		PlayerPrefsManager.AddCurrency(currencyEarned);

		totalCurrency.text = PlayerPrefsManager.GetCurrency().ToString();
	}
}
