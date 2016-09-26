using UnityEngine;
using System.Collections;

public class TitleScreenController : MonoBehaviour {
	[SerializeField]
	private GameObject creditsPanel = null;

	// Use this for initialization
	void Start () {
		creditsPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OpenCreditsPanel () {
		creditsPanel.SetActive(true);
	}

	public void CloseCreditsPanel () {
		creditsPanel.SetActive(false);
	}
}
