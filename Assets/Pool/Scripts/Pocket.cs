using UnityEngine;
using System.Collections;

public class Pocket : MonoBehaviour {

	[SerializeField]
	private Transform cueBallResetTransform = null;

	private BallUIController ballUIController;
	private OrderController orderController;
	private PoolScoreController poolScoreController;
	private SoundController soundController;

	// Use this for initialization
	void Start () {
		ballUIController = GameObject.FindObjectOfType<BallUIController>();
		orderController = GameObject.FindObjectOfType<OrderController>();
		poolScoreController = GameObject.FindObjectOfType<PoolScoreController>();
		soundController = GameObject.FindObjectOfType<SoundController>();
	}

	void OnTriggerEnter2D (Collider2D collider) {
		// determine score increase based on ball entered (scoreController??)

		if (collider.gameObject.tag == "Point Pool Ball") {
			collider.gameObject.SetActive(false);
			soundController.PlayBallInHole();

			// score point!!!
			if (orderController.CheckIfInOrder(collider.gameObject, ballUIController.GetPointBallObjects())) {
				poolScoreController.ScoreInOrderPoint();
			} else {
				poolScoreController.ScoreOutOfOrderPoint();
			}

			// bonus point at end
			if (collider.gameObject.name == ballUIController.GetPointBallObjects()[7].name) {
				poolScoreController.ScoreBonus(orderController.GetIsInOrder());
			}

			ballUIController.UpdateBallUI();

		} else if (collider.gameObject.tag == "Cue Ball") {
			collider.gameObject.transform.position = cueBallResetTransform.position;
			collider.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}

	}
}
