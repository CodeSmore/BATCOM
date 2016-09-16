using UnityEngine;
using System.Collections;

public class PoolThemeController : MonoBehaviour {
	[SerializeField]
	private SpriteRenderer cueStickSpriteRenderer = null;
	[SerializeField]
	private Sprite[] cueStickSprites = null;


	// Use this for initialization
	void Start () {
		cueStickSpriteRenderer.sprite = cueStickSprites[PlayerPrefsManager.GetPoolTheme()];
	}

}
