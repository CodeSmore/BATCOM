using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameSelectController : MonoBehaviour {
	[SerializeField]
	private GameObject menu = null;
	[SerializeField]
	private Text menuGameText = null;

	private string gameText = null;

	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SelectGame (string gameName) {
		gameText = gameName;

		menu.SetActive(true);
		menuGameText.text = gameName + "?";
	}

	public void LoadGame () {
		levelManager.LoadLevel(gameText);
	}

	public void CloseMenu () {
		menu.SetActive(false);
	}
}
