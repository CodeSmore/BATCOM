using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PoolEndGameMenu : MonoBehaviour {
	[SerializeField]
	private Text score = null, currencyEarnedText = null, totalCurrency = null;

	private PoolScoreController scoreController;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnEnable () {
		scoreController = GameObject.FindObjectOfType<PoolScoreController>();

		UpdateText();
	}

	void UpdateText () {
		score.text = "Score: " + scoreController.GetScore().ToString();

		int currencyEarned = Mathf.FloorToInt(scoreController.GetScore());

		currencyEarnedText.text = "Earned: $" + currencyEarned.ToString();
		PlayerPrefsManager.AddCurrency(currencyEarned);

		totalCurrency.text = "New Total:\n$" + PlayerPrefsManager.GetCurrency().ToString();
	}
}
