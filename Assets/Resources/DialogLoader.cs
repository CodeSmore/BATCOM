using UnityEngine;
using System.Collections;

public class DialogLoader : MonoBehaviour {

	public const string path = "dialogs";

	// Use this for initialization
	void Start () {
		DialogContainer dc = DialogContainer.Load(path);

		foreach (Dialog dialog in dc.dialogs) {
			print (dialog.text);
		}

		print (dc.dialogs[0].text);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
