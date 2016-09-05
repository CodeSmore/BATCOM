using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinballStyleController : MonoBehaviour {
	[SerializeField]
	private Image backgroundImage = null;
	[SerializeField]
	private Sprite[] backgroundSprites = null;

	// Use this for initialization
	void Start () {
		backgroundImage.sprite = backgroundSprites[PlayerPrefsManager.GetPinballBackground()];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
