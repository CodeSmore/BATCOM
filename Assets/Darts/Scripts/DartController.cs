using UnityEngine;
using System.Collections;

public class DartController : MonoBehaviour {

	[SerializeField]
	private GameObject dartGameObject = null, landPoint = null;
	private GameObject dartInstance;

	private SpriteRenderer touchIndicatorSpriteRenderer;
	private DartsSoundController soundController;

	private bool controlDartPosition = false;

	// Use this for initialization
	void Start () {
		touchIndicatorSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		soundController = GameObject.FindObjectOfType<DartsSoundController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (controlDartPosition) {
			MoveDart();
		}
	}

	void OnMouseDown () {
		touchIndicatorSpriteRenderer.enabled = false;
		dartInstance = Instantiate(dartGameObject) as GameObject;

		controlDartPosition = true;
	}

	void OnMouseUp () {
		touchIndicatorSpriteRenderer.enabled = true;

		// throw dart
		ThrowDart ();

		if (dartInstance != null) {
			Destroy(dartInstance);
		}

		controlDartPosition = false;
	}

	void MoveDart () {
		// move dart instance based on mouse position
		Debug.Log("moving dart");
		dartInstance.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -4f, -0.4150944f), dartInstance.transform.position.z);
	}

	void ThrowDart () {
		float landingConstant = .2f;

		Vector3 landingPoint;

		landingPoint = new Vector3 (dartInstance.transform.position.x, -.5f - dartInstance.transform.position.y * 1.5f + landingConstant, 0f);

		Instantiate(landPoint, landingPoint, Quaternion.identity);

		// lowest landing = .81
		// Highest landing = 6

		soundController.PlayDartThrowClip();
		soundController.PlayDartHitClip();
	}
}
