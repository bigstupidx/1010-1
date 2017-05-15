using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public GameObject lvl;
	// Use this for initialization
	void Start () {
		this.GetComponent<TextMesh>().text = "" + PlayerPrefs.GetInt("Record");
	}
	
	// Update is called once per frame
	void Update () {
		if (this.name=="Score")
		this.GetComponent<TextMesh>().text = "" + lvl.GetComponent<Level>().Score;
	}
}
