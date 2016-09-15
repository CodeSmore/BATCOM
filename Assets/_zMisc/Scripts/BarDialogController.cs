using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BarDialogController : MonoBehaviour {
	[SerializeField]
	private GameObject dialogBox = null;
	[SerializeField]
	private Text dialogText = null;
	[SerializeField]
	private float dialogCancelTime = 4;

	private bool startTimer = false;
	private bool firstDialog = true;
	private float dialogTimer = 0;

	private int dialogIndex = 0;

	public const string path = "dialogs";
	DialogContainer dc;

	void Start () {
		dc = DialogContainer.Load(path);

		dialogText.text = dc.dialogs[0].text;
		firstDialog = true;
	}

	// Update is called once per frame
	void Update () {
		if (startTimer) {
			if (dialogTimer >= dialogCancelTime) {
				RemoveDialogBox();
			}

			dialogTimer += Time.deltaTime;
		}
	}

	void OnMouseDown () {
		DisplayDialogBox();
	}

	void DisplayDialogBox () {
		// pick dialog
		ChangeText();

		dialogBox.SetActive(true);

		startTimer = true;
		dialogTimer = 0;
	}

	void RemoveDialogBox () {
		// change text for next time
		startTimer = false;
		dialogTimer = 0;

		dialogBox.SetActive(false);
	}

	void ChangeText () {
		// used to ensure greeting is always the first dialog
		if (!firstDialog) {
			dialogIndex = Random.Range(1, dc.dialogs.Count - 1);

			dialogText.text = dc.dialogs[dialogIndex].text;
		}

		firstDialog = false;

//		dialogIndex++;
//
//		if (dialogIndex >= dc.dialogs.Count) {
//			dialogIndex = 0;
//		}

	}
}
