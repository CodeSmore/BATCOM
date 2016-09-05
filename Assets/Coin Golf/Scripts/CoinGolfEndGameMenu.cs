using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinGolfEndGameMenu : MonoBehaviour {
	private CoinGolfScoreController scoreController;

	[SerializeField]
	private Text score = null, currencyEarnedText = null, totalCurrency = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnEnable () {
		scoreController = GameObject.FindObjectOfType<CoinGolfScoreController>();

		UpdateText();
	}

	void UpdateText () {
		score.text = "Score: " + scoreController.GetScore().ToString();

		int currencyEarned = Mathf.FloorToInt(scoreController.GetScore() / 10);

		currencyEarnedText.text = "Earned: $" + currencyEarned.ToString();
		PlayerPrefsManager.AddCurrency(currencyEarned);

		totalCurrency.text = "New Total:\n$" + PlayerPrefsManager.GetCurrency().ToString();
	}
}
