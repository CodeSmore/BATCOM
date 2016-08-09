using UnityEngine;
using System.Collections;

public class OrderController : MonoBehaviour {

	private bool isInOrder = true;
	private int currentBall = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool CheckIfInOrder (GameObject ballObjectScored, GameObject[] allBallObjects) {
		if (!isInOrder || allBallObjects[currentBall].name != ballObjectScored.name) {
			isInOrder = false;
		}

		currentBall++;

		return isInOrder;
	}

	public bool GetIsInOrder () {
		return isInOrder;
	}
}
