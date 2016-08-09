using UnityEngine;
using System.Collections;

public class BackgroundSoundsController : MonoBehaviour {
	[SerializeField]
	private AudioSource ballRolling = null;

	private PinBall pinball;

	// Use this for initialization
	void Start () {
		pinball = GameObject.FindObjectOfType<PinBall>();
	}
	
	// Update is called once per frame
	void Update () {
		if (pinball.IsBallMoving()) {
			ballRolling.mute = false;
		} else {
			ballRolling.mute = true;
		}
	}
}
