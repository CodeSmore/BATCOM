using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	private const string CURRENCY_KEY = "currency";
	private const string PINBALL_CURRENT_BACKGROUND_KEY = "pinball_current_background";
	private const string PINBALL_AQUA_BACKGROUND_PURCHASED_KEY = "pinball_aqua_background_purchased";

	private const string SOUND_FX_VOLUME_KEY = "sound_fx_volume";
	private const string MUSIC_VOLUME_KEY = "music_volume";

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

	public static void AddCurrency (int additionalCurrency) {
		int newTotal = PlayerPrefsManager.GetCurrency() + additionalCurrency;

		PlayerPrefs.SetInt(CURRENCY_KEY, newTotal);
	}

	public static int GetPinballBackground () {
		return PlayerPrefs.GetInt(PINBALL_CURRENT_BACKGROUND_KEY, 0);
	}

	public static void SetPinballBackground (int background) {
		PlayerPrefs.SetInt(PINBALL_CURRENT_BACKGROUND_KEY, background);
	}

	public static int GetIsAquaBackgroundPurchased () {
		return PlayerPrefs.GetInt(PINBALL_AQUA_BACKGROUND_PURCHASED_KEY, 0);
	}

	public static void UnloackAquaBackground () {
		PlayerPrefs.SetInt(PINBALL_AQUA_BACKGROUND_PURCHASED_KEY, 1);
	}

	public static void SetSoundFXVolume (float newVolume) {
		PlayerPrefs.SetFloat(SOUND_FX_VOLUME_KEY, newVolume); 
	}

	public static float GetSoundFXVolume () {
		return PlayerPrefs.GetFloat(SOUND_FX_VOLUME_KEY, 1f);
	}

	public static void SetMusicVolume (float newVolume) {
		PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, newVolume); 
	}

	public static float GetMusicVolume () {
		return PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY, 1f);
	}
}
