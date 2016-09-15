using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Dialog {

	[XmlAttribute("name")]
	public string name;

	[XmlElement("Text")]
	public string text;
}
