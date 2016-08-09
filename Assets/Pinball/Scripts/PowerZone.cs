using UnityEngine;
using System.Collections;

public class PowerZone : MonoBehaviour {
	[SerializeField]
	private float launchForce = 0;

	private bool powerZoneActive = false;

	private GameObject ball = null;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindGameObjectWithTag("Ball");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "Ball") {
			powerZoneActive = true;
		}
	}

	void OnTriggerExit2D (Collider2D collider) {
		if (collider.tag == "Ball") {
			powerZoneActive = false;
		}
	}

	public void LaunchBall () {
		if (powerZoneActive) {
			Debug.Log("launch");
			// apply force to ball
			ball.GetComponent<Rigidbody2D>().AddForce(new Vector2 (0, launchForce));
		}
	}
}
