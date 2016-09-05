using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour {
	[SerializeField]
	private float powah = 1;
	[SerializeField]
	private float maxForce = 0;
	[SerializeField]
	private float cueToBallDistanceThreshold = 0;
	[SerializeField]
	private GameObject cueBall = null, cueStick = null, dashedLine = null;
	private Rigidbody2D cueBallRigidbody2D;

	private bool preparingToFire = false;
	private GameController gameController;
	private SoundController soundController;

	private EventSystem eventSystem;

	Vector2 ballToStickVector;

	// used for cuestick lerp on shot
	private bool shootCue = false;

	// Use this for initialization
	void Start () {
		gameController = GameObject.FindObjectOfType<GameController>();
		cueBallRigidbody2D = cueBall.GetComponent<Rigidbody2D>();
		soundController = GameObject.FindObjectOfType<SoundController>();
		eventSystem = GameObject.FindObjectOfType<EventSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if (preparingToFire) {
			HandleCueStick();
			HandleReleasePower();
			HandleCueStickAndLinePosition();
			HandleCueStickAndLineRotation();
		} 

		if (shootCue) {
			Shoot();
		}
	}

	// make cue stick visible, oribiting cue ball
	// move cue stick further away from ball based on finger distance from cue ball
	void OnMouseDown () {
		if (gameController.AreAllBallsImmobile() && !eventSystem.IsPointerOverGameObject()) {
			preparingToFire = true;
		}
	}

	// on release, shoot pool cue ball
	void OnMouseUp () {
		if (gameController.AreAllBallsImmobile() && preparingToFire) {
			preparingToFire = false;
			InitiatePoolShot();
		}
	}

	void HandleCueStick () {
		if (!cueStick.activeSelf) {
			cueStick.SetActive(true);
		}

		if (!dashedLine.activeSelf) {
			dashedLine.SetActive(true);
		}
	}

	void HandleReleasePower () {}

	void HandleCueStickAndLinePosition () {
		cueStick.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, cueStick.transform.position.z);

		dashedLine.transform.localPosition = -cueStick.transform.localPosition;
	}

	void HandleCueStickAndLineRotation () {
		ballToStickVector = cueBall.transform.position - cueStick.transform.position;
		float zRotation = 0;
		float sign;

		if (cueBall.transform.position.y < cueStick.transform.position.y) {
			sign = -1f;
		} else {
			sign = 1f;
		}

		zRotation = Vector2.Angle(ballToStickVector, Vector2.right);

		cueStick.transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, zRotation * sign));
		dashedLine.transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, zRotation * sign));

		dashedLine.transform.localScale = new Vector3 (ballToStickVector.magnitude * .5f, dashedLine.transform.localScale.y, dashedLine.transform.localScale.z);

	}

	void InitiatePoolShot () {
		// remove dashed line
		dashedLine.SetActive(false);
	
		shootCue = true;
	}

	void Shoot () {
		// speed stick fires towards cue ball
		float speed = 20;

		// the lerp
		cueStick.transform.position = Vector3.Lerp (cueStick.transform.position, cueBall.transform.position, Time.deltaTime * speed);

		// once it's close enough, actually shoot the cue ball
		if (Vector3.Distance(cueStick.transform.position, cueBall.transform.position) < cueToBallDistanceThreshold) {
			shootCue = false;
			cueStick.SetActive(false);

			// shoot ball
			Vector2 shootForce = ballToStickVector * powah;
			shootForce = new Vector2 (Mathf.Clamp(shootForce.x, -maxForce, maxForce), Mathf.Clamp(shootForce.y, -maxForce, maxForce));

			cueBallRigidbody2D.AddForce(shootForce);

			// play hit sound
			soundController.PlayStickHitsCueBall();
		}
	}
}
