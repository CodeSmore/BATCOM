using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("DialogCollection")]
public class DialogContainer {

	[XmlArray("Dialogs")]
	[XmlArrayItem("Dialog")]
	public List<Dialog> dialogs = new List<Dialog>();

	public static DialogContainer Load(string path) {
		TextAsset _xml = Resources.Load<TextAsset>(path);

		XmlSerializer serializer = new XmlSerializer(typeof(DialogContainer));

		StringReader reader = new StringReader(_xml.text);

		DialogContainer dialogs = serializer.Deserialize(reader) as DialogContainer;

		reader.Close();

		return dialogs;
	}
	
}
