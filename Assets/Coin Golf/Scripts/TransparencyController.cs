using UnityEngine;
using System.Collections;

public class TransparencyController : MonoBehaviour {

	[SerializeField] 
	private float transparencyAmount = .75f;

	private SpriteRenderer spriteRenderer;

	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "Coin") {
			spriteRenderer.color = new Color (spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, transparencyAmount);		
		}
	}

	void OnTriggerExit2D (Collider2D collider) {
		if (collider.tag == "Coin") {
			spriteRenderer.color = new Color (spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
		}
	}
}
