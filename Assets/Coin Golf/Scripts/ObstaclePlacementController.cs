using UnityEngine;
using System.Collections;

public class ObstaclePlacementController : MonoBehaviour {

	[SerializeField]
	private GameObject[] placementLocationObjects = null;
	private Vector3[] locations;

	[SerializeField]
	private GameObject[] obstacleGameObjects = null;
	[SerializeField]
	private GameObject obstacleParent = null;

	[SerializeField]
	private int maxNumberOnTable = 0;

	// Use this for initialization
	void Start () {
		locations = new Vector3[placementLocationObjects.Length]; 

		int index = 0;
		foreach (GameObject objectPlacement in placementLocationObjects) {
			locations[index] = objectPlacement.transform.position;
			index++;
		}

		RandomizeTable();
	}

	public void RandomizeTable () {
		ClearTable();

		int numberPlaced = 0;
		bool[] spotsPlaced = new bool[locations.Length];

		while (numberPlaced < maxNumberOnTable) {
			int randPlacementIndex = Random.Range(0, locations.Length - 1);

			if (spotsPlaced[randPlacementIndex] == false) {
				int randObstacleIndex = Mathf.FloorToInt(Random.Range(0, obstacleGameObjects.Length - 0.1f));


				GameObject spawnedObstacle = Instantiate(obstacleGameObjects[randObstacleIndex], locations[randPlacementIndex], Quaternion.identity) as GameObject;
				spawnedObstacle.transform.parent = obstacleParent.transform;

				spotsPlaced[randPlacementIndex] = true;
				numberPlaced++;
			}
		}
	}

	void ClearTable () {
		foreach (Transform child in obstacleParent.transform) {
			Destroy(child.gameObject);
		}
	}
}
