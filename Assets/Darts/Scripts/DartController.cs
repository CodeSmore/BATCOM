using UnityEngine;
using System.Collections;

public class DartController : MonoBehaviour {

	[SerializeField]
	private GameObject dartGameObject = null, landPoint = null;
	private GameObject dartInstance;

	private SpriteRenderer touchIndicatorSpriteRenderer;
	private SoundController soundController;
	private DartsGameController gameController;

	private bool controlDartPosition = false;

	[SerializeField]
	private GameObject pauseMenu = null;

	[SerializeField]
	private float airTime = 5f;

	private bool lerpTime = false;
	private bool throwing = false;
	private bool enableRelease = false;
	private Vector3 landingPoint;

	// Use this for initialization
	void Start () {
		touchIndicatorSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		soundController = GameObject.FindObjectOfType<SoundController>();
		gameController = GameObject.FindObjectOfType<DartsGameController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (controlDartPosition) {
			MoveDart();
		}
	}

	void FixedUpdate () {
		if (lerpTime) {
			dartInstance.transform.position = Vector3.Lerp(dartInstance.transform.position, landingPoint, Time.deltaTime * airTime);

			if (dartInstance.transform.position.y + .1 > landingPoint.y) {
				EndThrow();
			}
		} 
	}

	void OnMouseDown () {
		// stops bug of throwing while in the middle of throw x.x
		if (throwing == false && !pauseMenu.activeSelf) {
			touchIndicatorSpriteRenderer.enabled = false;
			dartInstance = Instantiate(dartGameObject) as GameObject;

			controlDartPosition = true;

			enableRelease = true;
		}
	}

	void OnMouseUp () {
		if (enableRelease) {
			ThrowDart ();

			controlDartPosition = false;

			enableRelease = false;
		}
	}

	void MoveDart () {
		// move dart instance based on mouse position
		dartInstance.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -4f, -0.4150944f), dartInstance.transform.position.z);
	}

	void ThrowDart () {
		throwing = true;
		float landingConstant = .2f;

		landingPoint = new Vector3 (dartInstance.transform.position.x, -.5f - dartInstance.transform.position.y * 1.5f + landingConstant, 0f);

		lerpTime = true;

		// triggers animation to make dart smaller as it travels
		Animator dartAnimator = dartInstance.GetComponent<Animator>();
		dartAnimator.SetTrigger("ThrowTrigger");

		// plays "whoosh" sound
		soundController.PlayDartThrowClip();
	}

	void EndThrow () {
		lerpTime = false;
		Instantiate(landPoint, landingPoint, Quaternion.identity);
		soundController.PlayDartHitClip();
		touchIndicatorSpriteRenderer.enabled = true;
		Destroy(dartInstance);
		gameController.RemoveThrow();

		throwing = false;
	}
}
