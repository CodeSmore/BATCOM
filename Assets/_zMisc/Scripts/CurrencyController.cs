using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurrencyController : MonoBehaviour {

	private static int currentCurrency = 0;

	[SerializeField]
	private Text currencyText = null;

	// on awake, load currency from playerprefs
	void Awake () {
		currentCurrency = PlayerPrefsManager.GetCurrency();

		UpdateCurrencyText();
	}

	// save currency to player prefs on scene end
	void OnDisable () {
		PlayerPrefsManager.SaveCurrency(currentCurrency);
	}

	// and application closure...
	void OnApplicationQuit () {
		PlayerPrefsManager.SaveCurrency(currentCurrency);
	}

	void UpdateCurrencyText () {
		currencyText.text = "$" + currentCurrency.ToString();
	}

	public static void AddCurrency (int addedCurrency) {
		currentCurrency += addedCurrency;
		PlayerPrefsManager.SaveCurrency(currentCurrency);
		Debug.Log("adding score"); 
	}

	public static void SubtractCurrency (int subtractedCurrency) {
		currentCurrency -= subtractedCurrency;
		PlayerPrefsManager.SaveCurrency(currentCurrency);
	}

}
