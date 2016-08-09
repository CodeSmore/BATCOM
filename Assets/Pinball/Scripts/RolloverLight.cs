using UnityEngine;
using System.Collections;

public class RolloverLight : MonoBehaviour {
	[SerializeField]
	private int pointValue = 0;
	private SpriteRenderer spriteRenderer;
	private Color startColor;

	private ScoreController scoreController;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		startColor = spriteRenderer.color;
		scoreController = GameObject.FindObjectOfType<ScoreController>();
	}
	
	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag == "Ball") {
			scoreController.AdjustScore(pointValue);

			// bump animation
			spriteRenderer.color = Color.yellow;
		}
	}

	void OnTriggerExit2D (Collider2D collider) {
		if (collider.gameObject.tag == "Ball") {
			spriteRenderer.color = startColor;
		}
	}
}
