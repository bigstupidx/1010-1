using UnityEngine;
using System.Collections;

public class Lang : MonoBehaviour {
	public string rus, ukr, eng;
	void Start () {
		if (Application.systemLanguage.ToString()=="Russian")
			this.GetComponent<TextMesh>().text = rus;
		else if (Application.systemLanguage.ToString()=="Ukrainian")
			this.GetComponent<TextMesh>().text = ukr;
		else this.GetComponent<TextMesh>().text = eng;
	}
}
