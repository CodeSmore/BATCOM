using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	[SerializeField]
	private int maxHealth = 0;

	private int currentHealth, halfHealth;

	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();

		currentHealth = maxHealth;
		halfHealth = Mathf.CeilToInt((float)maxHealth / 2);
		Debug.Log(halfHealth);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "Ball") {
			ShieldWasHit();
		}
	}

	void ShieldWasHit () {
		currentHealth--;

		if (currentHealth <= 0) {
			// destroy shield
			Destroy(gameObject);
		} else if (currentHealth == 1) {
			// make shield red
			spriteRenderer.color = Color.red;
		} else if (currentHealth <= halfHealth) {
			// make shield yellow
			spriteRenderer.color = Color.yellow;
		} 
	}
}
