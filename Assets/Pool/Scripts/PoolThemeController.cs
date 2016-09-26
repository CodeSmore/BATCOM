using UnityEngine;
using System.Collections;

public class PoolThemeController : MonoBehaviour {
	[SerializeField]
	private SpriteRenderer cueStickSpriteRenderer = null, tableSpriteRenderer = null;
	[SerializeField]
	private Sprite[] cueStickSprites = null;
	[SerializeField]
	private Sprite[] tableSprites = null;

	[SerializeField]
	private GameObject[] pointBalls = null, ballUIs = null;


	// Use this for initialization
	void Start () {
		cueStickSpriteRenderer.sprite = cueStickSprites[PlayerPrefsManager.GetPoolTheme()];
		tableSpriteRenderer.sprite = tableSprites[PlayerPrefsManager.GetPoolTheme()];

		foreach (GameObject pointBallsObject in pointBalls) {
			pointBallsObject.SetActive(false);
		}

		foreach (GameObject ballUISet in ballUIs) {
			ballUISet.SetActive(false);
		}

		pointBalls[PlayerPrefsManager.GetPoolTheme()].SetActive(true);
		ballUIs[PlayerPrefsManager.GetPoolTheme()].SetActive(true);
	}

}
