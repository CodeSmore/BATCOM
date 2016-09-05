using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour {
	[SerializeField]
	private GameObject leftPaddle = null, rightPaddle = null;

	private bool leftPaddleActive = false, rightPaddleActive = false;

	[SerializeField]
	private Transform leftDownTransform = null, leftUpTransform = null, rightDownTransform = null, rightUpTransform = null;

	private float rightCounter = 0, leftCounter = 0;
	[SerializeField]
	private float flipUpSpeed = 1;

	private PowerZone leftPowerZone, rightPowerZone;
	private SoundController soundController;

	// Use this for initialization
	void Start () {
		leftPowerZone = GameObject.Find("LeftPowerZone").GetComponent<PowerZone>();
		rightPowerZone = GameObject.Find("RightPowerZone").GetComponent<PowerZone>();

		soundController = GameObject.FindObjectOfType<SoundController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (leftPaddleActive) {
			FlipLeftPaddle();
		} 

		if (rightPaddleActive) {
			FlipRightPaddle();
		} 
	}

	void FlipLeftPaddle () {
		if (leftCounter == 0) {
			// launch the ball!!!!
			leftPowerZone.LaunchBall();
		}

		leftCounter += Time.deltaTime;

		leftPaddle.transform.rotation = Quaternion.Slerp(leftDownTransform.rotation, leftUpTransform.rotation, leftCounter * flipUpSpeed);
	}

	void FlipRightPaddle () {
		if (rightCounter == 0) {
			// launch the ball!!!!
			rightPowerZone.LaunchBall();
		}

		rightCounter += Time.deltaTime;

		rightPaddle.transform.rotation = Quaternion.Slerp(rightDownTransform.rotation, rightUpTransform.rotation, rightCounter * flipUpSpeed);
	}

	public void ToggleLeftPaddleActive () {
		leftPaddleActive = !leftPaddleActive;

		if (leftPaddleActive) {
			soundController.PlayPaddlesClip();
		}
	}

	public void ToggleRightPaddleActive () {
		rightPaddleActive = !rightPaddleActive;

		if (rightPaddleActive) {
			soundController.PlayPaddlesClip();
		}
	}

	public void ResetLeftPaddle () {
		// return paddle to original position

		leftPaddle.transform.rotation = leftDownTransform.rotation;
		leftCounter = 0;
	}

	public void ResetRightPaddle () {
		// return paddle to original position

		rightPaddle.transform.rotation = rightDownTransform.rotation;
		rightCounter = 0;
	}
}
