using UnityEngine;
using System.Collections;

public class LauncherDoor : MonoBehaviour {
	[SerializeField]
	private SpriteRenderer spriteRenderer = null, otherSpriteRenderer = null;
	[SerializeField]
	private BoxCollider2D doorCollider = null, otherCollider = null, doorTrigger = null;
	// Use this for initialization
	void Start () {
		spriteRenderer.enabled = false;
		doorCollider.enabled = false;
		otherSpriteRenderer.enabled = false;
		otherCollider.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "Ball") {
			ActivateDoor();
		}
	}

	void ActivateDoor () {
		spriteRenderer.enabled = true;
		doorCollider.enabled = true;
		otherSpriteRenderer.enabled = true;
		otherCollider.enabled = true;
		doorTrigger.enabled = false;
	}
}
