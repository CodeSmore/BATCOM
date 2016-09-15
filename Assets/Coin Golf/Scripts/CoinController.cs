using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class CoinController : MonoBehaviour {
	[SerializeField]
	private float forceCoefficient = 3;
	[SerializeField]
	private float velocityThreshold = 0;

	private float fingerStartTime = 0.0f;
	private Vector2 fingerStartPos = Vector2.zero;

	private bool isSwipe = false, inCircle = false, coinWasLaunched = false;
	private float minSwipeDist = 50.0f;
	private float maxSwipeTime = 0.5f;

	// used when removing flick since sometimes velocity is registered at zero even when coinWasLaunched is set to true
	private float timeSinceStopAfterLaunch = 0;

	private Vector3 origPos;

	private EventSystem eventSystem;
	private Rigidbody2D coinRigidbody;
	private CoinGameController gameController;
	private CoinGolfScoreController scoreController;

	// Use this for initialization
	void Start () {
		eventSystem = GameObject.FindObjectOfType<EventSystem>();
		coinRigidbody = GetComponent<Rigidbody2D>();
		gameController = GameObject.FindObjectOfType<CoinGameController>();
		scoreController = GameObject.FindObjectOfType<CoinGolfScoreController>();

		origPos = transform.position;
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "Win Circle") {
			inCircle = true;
		}
	}

	void OnTriggerExit2D (Collider2D collider) {
		if (collider.tag == "Win Circle") {
			inCircle = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(timeSinceStopAfterLaunch);

		HandleVelocity();
		HandleFlickRemoval();

		if (eventSystem.currentSelectedGameObject == null && coinRigidbody.velocity == Vector2.zero && gameController.GetFlicksRemaining() > 0) {
			if (Input.touchCount > 0) {
				Debug.Log("Touching");
				foreach (Touch touch in Input.touches) {
					switch(touch.phase) {
						case TouchPhase.Began :
							// this is a new touch
							isSwipe = true;
							fingerStartTime = Time.time;
							fingerStartPos = touch.position;
							break;
						case TouchPhase.Canceled : 
							Debug.Log("canceled");
							// the touch is being canceled
							isSwipe = false;

							break;
						case TouchPhase.Ended :
							float gestureTime = Time.time - fingerStartTime;
							float gestureDist = (touch.position - fingerStartPos).magnitude;

							if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist) {
								Vector2 direction = touch.position - fingerStartPos;

								coinRigidbody.AddForce(forceCoefficient * direction / gestureTime);
								coinWasLaunched = true;
							}
							break;

					}
				}
			} else if (Input.GetMouseButton(0) || Input.GetMouseButtonUp(0)) {
				HandleMouseInput();
			}

		}
	}

	void HandleMouseInput () {
	// not touched because it's a PC build
		if (Input.GetMouseButtonDown(0)) {
		// NEW MOUSE CLICK/DRAG
			isSwipe = true;
			fingerStartTime = Time.time;
			fingerStartPos = (Vector2)Input.mousePosition;
		} else if (Input.GetMouseButtonUp(0)) {
		// END OF MOUSE CLICK/DRAG
			float mGestureTime = Time.time - fingerStartTime;
			float mGestureDist = ((Vector2)Input.mousePosition - fingerStartPos).magnitude;

			if (isSwipe && mGestureTime < maxSwipeTime && mGestureDist > minSwipeDist) {
				Vector2 direction = (Vector2)Input.mousePosition - fingerStartPos;
				Vector2 force = forceCoefficient * direction / mGestureTime;
		
				coinRigidbody.AddForce(force);	
				coinWasLaunched = true;		
			}
		}
	}

	void HandleVelocity () {
		if (Mathf.Abs(coinRigidbody.velocity.x) < velocityThreshold && Mathf.Abs(coinRigidbody.velocity.y) < velocityThreshold) {
			coinRigidbody.velocity = Vector2.zero;
		}
	}

	public bool IsCoinMoving () {
		if (coinRigidbody.velocity.x > -.01f && coinRigidbody.velocity.x < .01f && coinRigidbody.velocity.y > -.01f && coinRigidbody.velocity.x < .01f) {
			return false;
		} 

		return true;
	}

	public void ResetCoin () {
		transform.position = origPos;
		coinRigidbody.velocity = Vector2.zero;
		inCircle = false;
		coinWasLaunched = false;
	}

	public void HandleFlickRemoval () {
		// if coin stops (when labeled as moving) and coin isn't in circle, remove flick
		if (coinWasLaunched && !IsCoinMoving()) {
			timeSinceStopAfterLaunch += Time.deltaTime;
		}

		if (coinWasLaunched && !IsCoinMoving() && !inCircle && timeSinceStopAfterLaunch > .1f) {
			gameController.RemoveFlick();
			coinWasLaunched = false;
			timeSinceStopAfterLaunch = 0;

			//remove round points
			scoreController.DecreaseRoundScore();
		}
	}
}
