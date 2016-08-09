using UnityEngine;
using System.Collections;

public class LauncherController : MonoBehaviour {

	private Launcher launcher;

	// Use this for initialization
	void Start () {
		launcher = GameObject.FindObjectOfType<Launcher>();
	}
	
	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "Ball") {
			launcher.ResetLauncher();
		}
	}
}
