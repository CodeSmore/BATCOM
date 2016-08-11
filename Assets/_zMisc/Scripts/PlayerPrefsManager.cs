using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	private const string CURRENCY_KEY = "currency";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static int GetCurrency () {
		return PlayerPrefs.GetInt(CURRENCY_KEY, 0);
	}

	public static void SaveCurrency (int newCurrencyTotal) {
		PlayerPrefs.SetInt(CURRENCY_KEY, newCurrencyTotal);
	} 
}
