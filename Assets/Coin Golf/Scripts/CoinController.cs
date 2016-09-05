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

	private bool isSwipe = false;
	private float minSwipeDist = 50.0f;
	private float maxSwipeTime = 0.5f;

	private Vector2 origPos;

	private EventSystem eventSystem;
	private Rigidbody2D coinRigidbody;
	private CoinGameController gameController;

	// Use this for initialization
	void Start () {
		eventSystem = GameObject.FindObjectOfType<EventSystem>();
		coinRigidbody = GetComponent<Rigidbody2D>();
		gameController = GameObject.FindObjectOfType<CoinGameController>();

		origPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		HandleVelocity();

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
								Vector2 swipeType = Vector2.zero;

								coinRigidbody.AddForce(forceCoefficient * direction / gestureTime);
								gameController.RemoveFlick();
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
				Vector2 swipeType = Vector2.zero;

				Vector2 force = forceCoefficient * direction / mGestureTime;
		
				coinRigidbody.AddForce(force);
				gameController.RemoveFlick();
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
	}
}
