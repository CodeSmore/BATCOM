using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoreController : MonoBehaviour {
	
	[SerializeField]
	private GameObject poolStorePanel = null, scifiPurchaseThemePanel = null;
	[SerializeField]
	private GameObject dartsStorePanel = null, dartsSciFiPurchaseThemePanel = null;
	[SerializeField]
	private GameObject pinballStorePanel = null, aquaPurchaseThemePanel = null;
	[SerializeField]
	private GameObject[] poolThemeButtonIndicators = null, dartsThemeButtonIndicators = null,pinballThemeButtonIndicators = null;

	[SerializeField]
	private int costOfPoolSciFiTheme = 20000, costOfDartsSciFiTheme = 100, costOfPinballAquaTheme = 5000;

	private CurrencyController currencyController;

	// Use this for initialization
	void Start () {
		pinballStorePanel.SetActive(false);
		aquaPurchaseThemePanel.SetActive(false);

		HandleButtonIndicators();

		currencyController = GameObject.FindObjectOfType<CurrencyController>();
	}

	public void TogglePoolStore () {
		poolStorePanel.SetActive(!poolStorePanel.activeSelf);

		BarDialogController.SetDialogEnabled(!poolStorePanel.activeSelf);

	}

	public void ToggleDartsStore () {
		dartsStorePanel.SetActive(!dartsStorePanel.activeSelf);

		BarDialogController.SetDialogEnabled(!dartsStorePanel.activeSelf);
	}

	public void TogglePinballStore () {
		pinballStorePanel.SetActive(!pinballStorePanel.activeSelf);

		BarDialogController.SetDialogEnabled(!pinballStorePanel.activeSelf);
	}


	public void SetPoolTheme (int themeIndex) {
		if (themeIndex == 0) {
			PlayerPrefsManager.SetPoolTheme(themeIndex);

		} else if (themeIndex == 1) {
			if (PlayerPrefsManager.GetIsPoolSciFiThemePurchased() == 1) {
				PlayerPrefsManager.SetPoolTheme(themeIndex);
			} else {
				// open buy screen
				scifiPurchaseThemePanel.SetActive(true);

				// yes button instance
				Button yesButton = GameObject.Find("Pool 2 Yes Button").GetComponent<Button>();

				if (CurrencyController.GetCurrency() < costOfPoolSciFiTheme) {
					// make yes button invalid
					yesButton.interactable = false;
				} else {
					// make yes button valid
					yesButton.interactable = true;
				}
			}
		}

		HandleButtonIndicators();
	}

	public void SetDartsTheme (int themeIndex) {
		if (themeIndex == 0) {
			PlayerPrefsManager.SetDartsTheme(themeIndex);

		} else if (themeIndex == 1) {
			if (PlayerPrefsManager.GetIsDartsSciFiThemePurchased() == 1) {
				PlayerPrefsManager.SetDartsTheme(themeIndex);
			} else {
				// open buy screen
				dartsSciFiPurchaseThemePanel.SetActive(true);

				// yes button instance
				Button yesButton = GameObject.Find("Darts 2 Yes Button").GetComponent<Button>();

				if (CurrencyController.GetCurrency() < costOfDartsSciFiTheme) {
					// make yes button invalid
					yesButton.interactable = false;
				} else {
					// make yes button valid
					yesButton.interactable = true;
				}
			}
		}

		HandleButtonIndicators();
	}

	public void SetPinballTheme (int themeIndex) {
		if (themeIndex == 0) {
			PlayerPrefsManager.SetPinballTheme(themeIndex);

		} else if (themeIndex == 1) {
			if (PlayerPrefsManager.GetIsAquaThemePurchased() == 1) {
				PlayerPrefsManager.SetPinballTheme(themeIndex);
			} else {
				// open buy screen
				aquaPurchaseThemePanel.SetActive(true);

				// yes button instance
				Button yesButton = GameObject.Find("Pinball 2 Yes Button").GetComponent<Button>();

				if (CurrencyController.GetCurrency() < costOfPinballAquaTheme) {
					// make yes button invalid
					yesButton.interactable = false;
				} else {
					// make yes button valid
					yesButton.interactable = true;
				}
			}
		}

		HandleButtonIndicators();
	}

	// TODO find better way to close purchase windows than several methods
	public void ClosePoolSciFiPurchaseWindow () {
		GameObject.Find("SciFi Buy Panel").SetActive(false);
	}

	public void CloseDartsSciFiPurchaseWindow () {
		GameObject.Find("Darts SciFi Buy Panel").SetActive(false);
	}

	public void ClosePurchaseWindow () {
		GameObject.Find("Buy Panel").SetActive(false);
	}


	public void PurchaseSciFiTheme () {
		CurrencyController.SubtractCurrency(costOfPoolSciFiTheme);
		// update store text

		PlayerPrefsManager.SetPoolTheme(1);
		PlayerPrefsManager.UnlockPoolSciFiTheme();
		HandleButtonIndicators();
		ClosePoolSciFiPurchaseWindow();

		currencyController.UpdateCurrencyText();
	}

	public void PurchaseDartsSciFiTheme () {
		CurrencyController.SubtractCurrency(costOfDartsSciFiTheme);
		PlayerPrefsManager.SetDartsTheme(1);
		PlayerPrefsManager.UnlockDartsSciFiTheme();
		HandleButtonIndicators();
		CloseDartsSciFiPurchaseWindow();

		currencyController.UpdateCurrencyText();
	}

	public void PurchaseAquaTheme () {
		CurrencyController.SubtractCurrency(costOfPinballAquaTheme);
		PlayerPrefsManager.SetPinballTheme(1);
		PlayerPrefsManager.UnlockAquaTheme();
		HandleButtonIndicators();
		ClosePurchaseWindow();

		currencyController.UpdateCurrencyText();
	}



	void HandleButtonIndicators () {
		// enable indicator based on which theme is active

		foreach (GameObject indicator in poolThemeButtonIndicators) {
			indicator.SetActive(false);
		}
		poolThemeButtonIndicators[PlayerPrefsManager.GetPoolTheme()].SetActive(true);

		foreach (GameObject indicator in dartsThemeButtonIndicators) {
			indicator.SetActive(false);
		}
		dartsThemeButtonIndicators[PlayerPrefsManager.GetDartsTheme()].SetActive(true);

		foreach (GameObject indicator in pinballThemeButtonIndicators) {
			indicator.SetActive(false);
		}
		pinballThemeButtonIndicators[PlayerPrefsManager.GetPinballTheme()].SetActive(true);
	}
}

