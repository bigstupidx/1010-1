using UnityEngine;
using System.Collections;

public class Need : MonoBehaviour {

	public GameObject lvl,prefab,tmp;
	int[,] tmpShape;
	public bool changed;
	public Color[] colors;
	// Use this for initialization
	void Start () {
		lvl = GameObject.FindWithTag("Level");
		//animation.Play("Need");
	}


	public void Change(){
		lvl = GameObject.FindWithTag("Level");
		if (this.name=="ooo2"){
			tmpShape = lvl.GetComponent<Level>().oooNext;
			for (int i=0;i<tmpShape.GetLength(0);i++){
				for (int j=0;j<tmpShape.GetLength(1);j++){
					if (tmpShape[i,j]==1){
						
						tmp = Instantiate(prefab,this.transform.position,Quaternion.identity) as GameObject;
						tmp.transform.Translate(-1f+j*0.15f,1f+i*(-0.15f),0);
						tmp.transform.parent = this.transform;
						tmp.transform.localScale = new Vector3(0.5f,0.5f,0);
						tmp.GetComponent<SpriteRenderer>().color = colors[0];
						//tmp.GetComponent<SpriteRenderer>().color = colors[current];
					}
				}
			}
			this.transform.Translate((10-tmpShape.GetLength(1))*0.075f,(10-tmpShape.GetLength(0))*(-0.075f),0);
			int tmpLength = tmpShape.GetLength(1)>tmpShape.GetLength(0)?tmpShape.GetLength(1):tmpShape.GetLength(0);
			this.transform.localScale = new Vector3(0.5f*10f/tmpLength,0.5f*10f/tmpLength,1);
			this.transform.Translate((10-tmpLength)*0.19f,(10-tmpLength)*(-0.19f),0);
		}
		else if (this.name=="ooo3"){
			tmpShape = lvl.GetComponent<Level>().ooo;
			for (int i=0;i<tmpShape.GetLength(0);i++){
				for (int j=0;j<tmpShape.GetLength(1);j++){
					if (tmpShape[i,j]==1){
						tmp.GetComponent<SpriteRenderer>().color = colors[1];
						//tmp.GetComponent<SpriteRenderer>().color = colors[current];
					}
				}
			}
		}
		else{
			tmpShape = lvl.GetComponent<Level>().ooo;
			for (int i=0;i<tmpShape.GetLength(0);i++){
				for (int j=0;j<tmpShape.GetLength(1);j++){
					if (tmpShape[i,j]==1){
						
						tmp = Instantiate(prefab,this.transform.position,Quaternion.identity) as GameObject;
						tmp.transform.Translate(-1f+j*0.15f,1f+i*(-0.15f),0);
						tmp.transform.parent = this.transform;
						tmp.transform.localScale = new Vector3(0.5f,0.5f,0);
						tmp.GetComponent<SpriteRenderer>().color = colors[1];
						//tmp.GetComponent<SpriteRenderer>().color = colors[current];
					}
				}
			}
			this.transform.Translate((10-tmpShape.GetLength(1))*0.075f,(10-tmpShape.GetLength(0))*(-0.075f),0);
			int tmpLength = tmpShape.GetLength(1)>tmpShape.GetLength(0)?tmpShape.GetLength(1):tmpShape.GetLength(0);
			this.transform.localScale = new Vector3(0.5f*10f/tmpLength,0.5f*10f/tmpLength,1);
			this.transform.Translate((10-tmpLength)*0.19f,(10-tmpLength)*(-0.19f),0);
		}

	}
}
