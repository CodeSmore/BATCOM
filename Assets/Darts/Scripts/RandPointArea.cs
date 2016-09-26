using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RandPointArea : MonoBehaviour {

	[SerializeField]
	private int minPointValue = 0, maxPointValue = 0;
	[SerializeField]
	private Text zoneTextElement = null;

	private int pointValue;

	void Start () {
		SetPointValue();
		SetTextElement();
	}

	void SetPointValue () {
		pointValue = Mathf.CeilToInt(Random.Range(minPointValue - 0.9f, maxPointValue));
	}

	void SetTextElement () {
		zoneTextElement.text = pointValue.ToString();
	}

	public int GetPointValue () {
		return pointValue;
	}
}
