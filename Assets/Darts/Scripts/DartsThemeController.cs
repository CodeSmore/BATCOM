using UnityEngine;
using System.Collections;

public class DartsThemeController : MonoBehaviour {
	[SerializeField]
	private GameObject[] dartBoards = null;

	// Use this for initialization
	void Start () {
		foreach (GameObject dartBoard in dartBoards) {
			dartBoard.SetActive(false);
		}

		dartBoards[PlayerPrefsManager.GetDartsTheme()].SetActive(true);
	}
}
