using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinGameController : MonoBehaviour {
	[SerializeField]
	private Image[] flickImages = null;

	private bool beginEnd = false;
	private float endTimer = 0;
	[SerializeField]
	private float endTimerThreshold = 3;

	[SerializeField]
	private GameObject endGameMenu = null;

	private int flicksRemaining = 0;

	// Use this for initialization
	void Start () {
		flicksRemaining = flickImages.Length;
	}

	void Update () {
		if (beginEnd /* and coin isn't moving*/) {
			endTimer += Time.deltaTime;

			if (endTimer >= endTimerThreshold) {
				// when reaches threshold, show end game and assign points
				endGameMenu.SetActive(true);
			}
		}
	}
	
	public void RemoveFlick () {
		flickImages[flicksRemaining - 1].gameObject.SetActive(false);

		flicksRemaining--;  

		if (flicksRemaining == 0) {
			beginEnd = true;
		}
	}

	public int GetFlicksRemaining () {
		return flicksRemaining;
	}

	public void ResetFlickCount () {
		endTimer = 0;
		beginEnd = false;
		flicksRemaining = flickImages.Length;

		foreach (Image flickImage in flickImages) {
			flickImage.gameObject.SetActive(true);
		}
	}
}
