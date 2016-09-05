using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DartsGameController : MonoBehaviour {
	[SerializeField]
	private int numbHitsPerGame = 0;
	private int hitsLeft;

	[SerializeField]
	private GameObject[] dartIcons = null;
	[SerializeField]
	private GameObject touchIcon = null;
	[SerializeField]
	private GameObject endGameMenu = null;

	private bool endGame;
	private float endGameCount;

	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();

		hitsLeft = numbHitsPerGame;
	}
	
	// Update is called once per frame
	void Update () {
		if (endGame) {
			if (endGameCount > 1) {
				endGameMenu.SetActive(true);
			}

			endGameCount += Time.deltaTime;
		}
	}

	public void RemoveThrow () {
		dartIcons[hitsLeft - 1].GetComponent<Image>().color = Color.gray;

		hitsLeft--;

		if (hitsLeft == 0) {
			// end game
			EndGame();
		}


	}

	private void EndGame() {
		endGame = true;

		touchIcon.SetActive(false);
	}
}
