using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BallUIController : MonoBehaviour {

	[SerializeField]
	private Image[] ballImages = null, glowImages = null;
	[SerializeField]
	private GameObject[] ballGameObjects = null;

	private OrderController orderController;

	// Use this for initialization
	void Start () {
		orderController = GameObject.FindObjectOfType<OrderController>();

		UpdateGlow();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void UpdateBallUI () {
		for (int i = 0; i < ballImages.Length; i++) {
			if (!ballGameObjects[i].activeSelf) {
				ballImages[i].color = Color.gray;
				glowImages[i].enabled = false;
			}
		}

		UpdateGlow();
	}

	void UpdateGlow () {
		// determine if 'order' still a go, if so, check which one is next and make it glow
		if (orderController.GetIsInOrder()) {
			for (int i = 0; i < ballGameObjects.Length; i++) {
				if (ballGameObjects[i].activeSelf) {
					glowImages[i].enabled = true;

					i = ballGameObjects.Length;
				}
			}
		} else {
			for (int i = 0; i < ballGameObjects.Length; i++) {
				glowImages[i].enabled = false;
			}
		}
	}

	public GameObject[] GetPointBallObjects () {
		return ballGameObjects;
	}
}
