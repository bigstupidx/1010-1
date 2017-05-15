using UnityEngine;
using System.Collections;

public class Watch : MonoBehaviour {

	public GameObject[] objs;

	void OnMouseDown(){
		for (int i=0;i<objs.Length;i++){
			objs[i].GetComponent<GUITexture>().color = new Color(objs[i].GetComponent<GUITexture>().color.r,
			                                                     objs[i].GetComponent<GUITexture>().color.g,
			                                                     objs[i].GetComponent<GUITexture>().color.b,
			                                                     0.1f);
		}
	}
	void OnMouseUp(){
		for (int i=0;i<objs.Length;i++){
			objs[i].GetComponent<GUITexture>().color = new Color(objs[i].GetComponent<GUITexture>().color.r,
			                                                     objs[i].GetComponent<GUITexture>().color.g,
			                                                     objs[i].GetComponent<GUITexture>().color.b,
			                                                     1f);
		}
	}
}
