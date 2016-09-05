

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ball : MonoBehaviour {

	[SerializeField]
	private float velocityThreshold = 0;
	[SerializeField]
	private float distanceTilSpriteSwap = 0;
	[SerializeField]
	private Sprite[] animationSprites = null;
	private int spritePlaceHolder = 0;

	private Rigidbody2D ballRigidbody;
	private SoundController soundController;
	private SpriteRenderer currentSprite;

	private float switchSpriteTimer = 0;

	// Use this for initialization
	void Start () {
		ballRigidbody = GetComponent<Rigidbody2D>();
		soundController = GameObject.FindObjectOfType<SoundController>();
		currentSprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		// if ball velocity (x & y) is below threshold, stop all velocity
		if (Mathf.Abs(ballRigidbody.velocity.x) < velocityThreshold && Mathf.Abs(ballRigidbody.velocity.y) < velocityThreshold) {
			ballRigidbody.velocity = Vector2.zero;
		} else {
			HandleSpriteAnimation();
			HandleDirection();
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "Point Pool Ball" || collision.gameObject.tag == "Cue Ball") {
			soundController.PlayOneBallHit();
		}
	}

	public void HandleSpriteAnimation () {
		// switch sprites based on magnitude of velocity
		float speed = ballRigidbody.velocity.magnitude;

		switchSpriteTimer += speed;

		if (switchSpriteTimer >= distanceTilSpriteSwap) {
			SwitchSprite();
			switchSpriteTimer = 0;
		}
	}

	public void SwitchSprite () {
		// if sprites are present (ex. not for cue ball)
		if (animationSprites.Length > 0) {
			if (spritePlaceHolder + 1 == animationSprites.Length) {
				spritePlaceHolder = 0;
			} else {
				spritePlaceHolder++;
			}

			currentSprite.sprite = animationSprites[spritePlaceHolder];
		}
	}

	public void HandleDirection () {
		Quaternion lookRotation = Quaternion.LookRotation(ballRigidbody.velocity.normalized);

		lookRotation.x = 0.0f;
		lookRotation.y = 0.0f;

		transform.rotation = lookRotation;
	}
}
