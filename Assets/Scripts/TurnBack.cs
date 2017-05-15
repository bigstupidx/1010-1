using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TurnBack : MonoBehaviour {

	public List<int> lastCubesX, lastCubesY;
	public int lastShapeNum,rotlast;
	public string lastname;
	public GameObject lvl,shapePrefab;
	public bool Avaible;
	GameObject tmp;


	public enum SwipeDirection{
		Up,
		Down,
		Right,
		Left
	}
	
	//public static event Action<SwipeDirection> Swipe;
	private bool swiping = false;
	private bool eventSent = false;
	private Vector2 lastPosition;

	void Update(){
		if (Input.touchCount == 0) 
			return;
		
		if (Input.GetTouch(0).deltaPosition.sqrMagnitude != 0){
			if (swiping == false){
				swiping = true;
				lastPosition = Input.GetTouch(0).position;
				return;
			}
			else{
				if (!eventSent) {
						Vector2 direction = Input.GetTouch(0).position - lastPosition;
						
					print (direction.x+" + "+direction.y);
					if (direction.x<-13f&&Avaible&&Mathf.Abs(direction.y)<5){
						print (direction.x);
						Back ();

					}
						/*if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
							if (direction.x > 0) {print("Right");}
							else
						{Back();
							print("Left");}
						}
						else{
							if (direction.y > 0)
							print("Up");
							else
									print("Down");
						}*/
						
						eventSent = true;
					}
				}
			}

		else{
			swiping = false;
			eventSent = false;
		}
	}


	void OnMouseUp(){
		if (lvl.GetComponent<Level>().left!=3&&Avaible){
			Back();
		}


	}
	void Back(){
		if (lvl.GetComponent<Level>().left!=3&&Avaible){
			lvl.GetComponent<Level>().Score-=5;
			tmp = Instantiate(shapePrefab) as GameObject;
			tmp.name = lastname;

			switch (lastname){
			case "shape1":
				break;
			case "shape2":
				tmp.transform.Translate(1.75f,0,0);
				break;
			case "shape3":
				tmp.transform.Translate(3.5f,0,0);
				break;
			}
			lvl.GetComponent<Level>().left++;
			tmp.GetComponent<Figure>().current = lastShapeNum;
			tmp.GetComponent<Figure>().rotNum = rotlast;
			tmp.GetComponent<Figure>().iCurrentShape(lastShapeNum);
			for (int i=0;i<lastCubesX.Count;i++){
				Destroy(GameObject.Find(lastCubesX[i]+""+lastCubesY[i]));
				lvl.GetComponent<Level>().pole[lastCubesX[i],lastCubesY[i]]=0;
			}
			GetComponent<AudioSource>().Play ();
			Avaible=false;
		}
	}

}
