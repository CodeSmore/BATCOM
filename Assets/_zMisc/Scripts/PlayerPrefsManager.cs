using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	private const string CURRENCY_KEY = "currency";

	private const string PINBALL_CURRENT_THEME_KEY = "pinball_current_theme";
	private const string POOL_CURRENT_THEME_KEY = "pool_current_theme";
	private const string DARTS_CURRENT_THEME_KEY = "darts_current_theme";

	private const string POOL_SCIFI_THEME_PURCHASED_KEY = "pool_scifi_theme_purchased";
	private const string DARTS_SCIFI_THEME_PURCHASED_KEY = "darts_scifi_theme_purchased";
	private const string PINBALL_AQUA_BACKGROUND_PURCHASED_KEY = "pinball_aqua_background_purchased";

	private const string SOUND_FX_VOLUME_KEY = "sound_fx_volume";
	private const string MUSIC_VOLUME_KEY = "music_volume";

	//....................................................................

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

	//.............................................................

	public static int GetPinballTheme () {
		return PlayerPrefs.GetInt(PINBALL_CURRENT_THEME_KEY, 0);
	}

	public static int GetPoolTheme () {
		return PlayerPrefs.GetInt(POOL_CURRENT_THEME_KEY, 0);
	}

	public static int GetDartsTheme () {
		return PlayerPrefs.GetInt(DARTS_CURRENT_THEME_KEY, 0);
	}

	public static void SetPinballTheme (int theme) {
		PlayerPrefs.SetInt(PINBALL_CURRENT_THEME_KEY, theme);
	}

	public static void SetPoolTheme (int theme) {
		PlayerPrefs.SetInt(POOL_CURRENT_THEME_KEY, theme);
	}

	public static void SetDartsTheme (int theme) {
		PlayerPrefs.SetInt(DARTS_CURRENT_THEME_KEY, theme);
	}

	//.......................................................

	public static int GetIsPoolSciFiThemePurchased () {
		return PlayerPrefs.GetInt(POOL_SCIFI_THEME_PURCHASED_KEY, 0);
	}

	public static int GetIsDartsSciFiThemePurchased () {
		return PlayerPrefs.GetInt(DARTS_SCIFI_THEME_PURCHASED_KEY, 0);
	}

	public static int GetIsAquaThemePurchased () {
		return PlayerPrefs.GetInt(PINBALL_AQUA_BACKGROUND_PURCHASED_KEY, 0);
	}

	//.........................................................................

	public static void UnlockPoolSciFiTheme () {
		PlayerPrefs.SetInt(POOL_SCIFI_THEME_PURCHASED_KEY, 1);
	}

	public static void UnlockDartsSciFiTheme () {
		PlayerPrefs.SetInt(DARTS_SCIFI_THEME_PURCHASED_KEY, 1);
	}

	public static void UnlockAquaTheme () {
		PlayerPrefs.SetInt(PINBALL_AQUA_BACKGROUND_PURCHASED_KEY, 1);
	}

	//......................................................................

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
