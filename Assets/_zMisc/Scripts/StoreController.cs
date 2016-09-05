using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoreController : MonoBehaviour {
	[SerializeField]
	private GameObject pinballStorePanel = null, aquaPurchaseBackgroundPanel = null;

	[SerializeField]
	private int costOfPinballBackground2 = 5000;
	[SerializeField]

	// Use this for initialization
	void Start () {
		pinballStorePanel.SetActive(false);
		aquaPurchaseBackgroundPanel.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TogglePinballStore () {
		pinballStorePanel.SetActive(!pinballStorePanel.activeSelf);
	}


	public void SetBackground (int background) {
		if (background == 0) {
			PlayerPrefsManager.SetPinballBackground(background);

		} else if (background == 1) {
			if (PlayerPrefsManager.GetIsAquaBackgroundPurchased() == 1) {
				PlayerPrefsManager.SetPinballBackground(background);
			} else {
				// open buy screen
				aquaPurchaseBackgroundPanel.SetActive(true);

				// yes button instance
				Button yesButton = GameObject.Find("Pinball 2 Yes Button").GetComponent<Button>();

				if (CurrencyController.GetCurrency() < costOfPinballBackground2) {
					// make yes button invalid
					yesButton.interactable = false;
				} else {
					// make yes button valid
					yesButton.interactable = true;
				}
			}
		}
	}

	public void ClosePurchaseWindow () {
		GameObject.Find("Buy Panel").SetActive(false);
	}

	public void Purchase () {
		CurrencyController.SubtractCurrency(costOfPinballBackground2);
		PlayerPrefsManager.SetPinballBackground(1);
		PlayerPrefsManager.UnloackAquaBackground();
		ClosePurchaseWindow();
	}
}

