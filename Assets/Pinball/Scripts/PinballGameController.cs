using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinballGameController : MonoBehaviour {
	[SerializeField]
	private GameObject endGameMenu = null, leftPaddleButton = null, rightPaddleButton = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void EndGame () {
		// enable end game menu
		// disable paddles, launcher

		endGameMenu.SetActive(true);

		leftPaddleButton.SetActive(false);
		rightPaddleButton.SetActive(false);
	}
}
