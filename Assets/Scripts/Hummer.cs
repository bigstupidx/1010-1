using UnityEngine;
using System.Collections;

public class Hummer : MonoBehaviour {

	public GameObject lvl;
	public bool avaible;

	public int num=1;

	/*int[,] shape = new int[,]{{1,1,1,1,1},
		{1,1,1,1,1},
		{1,1,1,1,1},
		{1,1,1,1,1},
		{1,1,1,1,1}};*/

	void Update () {
		if (lvl.GetComponent<Level>().Score>=num*500){
			GetComponent<SpriteRenderer>().color = new Color(0.8f,0.8f,0.8f,1);
			avaible=true;
		}
			
	}


	void OnMouseUp(){
		GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r+0.04f,
		                                                 GetComponent<SpriteRenderer>().color.g+0.04f,
		                                                 GetComponent<SpriteRenderer>().color.b+0.04f,
		                                                 GetComponent<SpriteRenderer>().color.a);
		if (avaible==true){

			lvl.GetComponent<Level>().Hummer();
			num = lvl.GetComponent<Level>().Score/500+1;


			GetComponent<SpriteRenderer>().color = new Color(0.2f,0.2f,0.2f,0.2f);
			GetComponent<AudioSource>().Play();
		}

	}
	void OnMouseDown(){
		GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r-0.04f,
		                                                 GetComponent<SpriteRenderer>().color.g-0.04f,
		                                                 GetComponent<SpriteRenderer>().color.b-0.04f,
		                                                 GetComponent<SpriteRenderer>().color.a);
	}




}
