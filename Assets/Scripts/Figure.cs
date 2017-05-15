using UnityEngine;
using System.Collections;

public class Figure : MonoBehaviour {

	public AudioClip OK,Wrong;
	public int[][,] dopShapes = new int[][,]{
		new int[,]{	{1,1,1,1,1}},
		new int[,]{	{1},
					{1},
					{1},
					{1},
					{1},},
		new int[,]{{1}},
		new int[,]{{1,1}},
		new int[,]{{1},
					{1}},
		new int[,]{{1,1},
					{1,1}},
		new int[,]{{1,1,1}},
		new int[,]{{1},
					{1},
					{1},},

		new int[,]{{1,1},
					{1,0}},
		new int[,]{{1,1},
				{0,1}},
		new int[,]{{0,1},
				{1,1}},
		new int[,]{{1,1},
				{1,0}},


		new int[,]{{1,1,1},
					{1,0,0},
					{1,0,0}},
		new int[,]{{1,1,1},
					{0,0,1},
					{0,0,1}},
		new int[,]{{0,0,1},
					{0,0,1},
					{1,1,1}},
		new int[,]{{1,0,0},
					{1,0,0},
					{1,1,1}},
		new int[,]{{1,1,1},
					{1,1,1},
					{1,1,1}}


		
	};
	public int[][,] shapes  = new int[][,]{
		new int[,]{{0,0,0,0,0},
					{0,0,0,0,0},
					{1,1,1,1,1},
					{0,0,0,0,0},
					{0,0,0,0,0}},
		new int[,]{{0,0,0,0,0},
					{0,0,0,0,0},
					{0,0,1,0,0},
					{0,0,0,0,0},
					{0,0,0,0,0}},
		new int[,]{{0,0,0,0,0},
					{0,0,0,0,0},
					{0,0,1,1,0},
					{0,0,0,0,0},
					{0,0,0,0,0}},
		new int[,]{{0,0,0,0,0},
					{0,0,1,1,0},
					{0,0,1,1,0},
					{0,0,0,0,0},
					{0,0,0,0,0}},
		new int[,]{{0,0,0,0,0},
					{0,0,0,0,0},
					{0,1,1,1,0},
					{0,0,0,0,0},
					{0,0,0,0,0}},

		new int[,]{{0,0,0,0,0},
				   {0,1,1,0,0},
				   {0,1,0,0,0},
				   {0,0,0,0,0},
				   {0,0,0,0,0}},

		new int[,]{{0,0,0,0,0},
			{0,1,1,1,0},
			{0,1,0,0,0},
			{0,1,0,0,0},
			{0,0,0,0,0}},
		new int[,]{{0,0,0,0,0},
			{0,1,1,1,0},
			{0,1,1,1,0},
			{0,1,1,1,0},
			{0,0,0,0,0}}
	};


	public int[,] dopShape;
	public int current;
	public Color[] colors;
	public int[,] tmpShape;
	GameObject tmp,lvl;
	public GameObject prefab;
	public bool mozhna;
	public Transform[] children;
	string arr;
	Vector3 startPos;
	bool isEasy;
	public int rotNum;
	void Start () {

	}

	public void iCurrentShape(int shapeNum){

		lvl = GameObject.FindGameObjectWithTag("Level");
		tmpShape = shapes[current];
		tmpShape = RotateMatrix(tmpShape,rotNum);
		startPos = this.transform.position;
		SetDopShape(current,rotNum);
		for (int i=0;i<5;i++){
			for (int j=0;j<5;j++){
				arr+=tmpShape[i,j];
				if (tmpShape[i,j]==1){
					
					tmp = Instantiate(prefab,this.transform.position,Quaternion.identity) as GameObject;
					tmp.transform.Translate(-0.5f+j*0.25f,1.3f+i*(-0.25f),0);
					tmp.transform.parent = this.transform;
					tmp.GetComponent<SpriteRenderer>().color = colors[current];
				}
			}
			arr+="\n";
		}
		children = GetComponentsInChildren<Transform>();
	}
	public void iStart(){
		lvl = GameObject.FindGameObjectWithTag("Level");
		isEasy = Random.Range(0,100*1000)/1000<90?true:false;
		if (isEasy)
			tmpShape = shapes[current=Random.Range(0,(shapes.Length-2)*1000)/1000];
		else tmpShape = shapes[current=Random.Range(shapes.Length-2,shapes.Length)];
		startPos = this.transform.position;
		rotNum = Random.Range(0,4);
		tmpShape = RotateMatrix(tmpShape,rotNum);
		SetDopShape(current,rotNum);
		for (int i=0;i<5;i++){
			for (int j=0;j<5;j++){
				arr+=tmpShape[i,j];
				if (tmpShape[i,j]==1){
					
					tmp = Instantiate(prefab,this.transform.position,Quaternion.identity) as GameObject;
					tmp.transform.Translate(-0.5f+j*0.25f,1.3f+i*(-0.25f),0);
					tmp.transform.parent = this.transform;
					tmp.GetComponent<SpriteRenderer>().color = colors[current];
				}
			}
			arr+="\n";
		}
		children = GetComponentsInChildren<Transform>();
	}
	void OnMouseDown(){
		mozhna = true;
		print (dopShape.GetLength(0));
		this.transform.localScale = new Vector3(2f,2f,-1);
	}
	void OnMouseDrag(){
		this.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
		                                      Camera.main.ScreenToWorldPoint(Input.mousePosition).y-0.6f+0.1f*dopShape.GetLength(0),
		                                      -1);
	}
	void OnMouseUp(){
		for (int i=1;i<children.Length;i++){
			children[i].GetComponent<cube>().Check();
		}
		if (mozhna){
			/*GameObject.Find("TurnBack").transform.GetComponent<TurnBack>().lastCubesX.Clear();
			GameObject.Find("TurnBack").transform.GetComponent<TurnBack>().lastCubesY.Clear();
			GameObject.Find("TurnBack").transform.GetComponent<TurnBack>().lastShapeNum = current;
			GameObject.Find("TurnBack").transform.GetComponent<TurnBack>().lastname = this.name;
			GameObject.Find("TurnBack").transform.GetComponent<TurnBack>().rotlast = rotNum;
			GameObject.Find("TurnBack").transform.GetComponent<TurnBack>().Avaible=true;*/

			this.name="blahblahblah";
			GetComponent<AudioSource>().clip=OK;
			GetComponent<AudioSource>().Play();
			for (int i=1;i<children.Length;i++){
				children[i].GetComponent<cube>().Fix();
			}
			Destroy(this.GetComponent<CircleCollider2D>());
			Destroy(this.GetComponent<SpriteRenderer>());
			lvl.GetComponent<Level>().left--;

			//else lvl.GetComponent<Level>().CheckTurn();
			if (lvl.GetComponent<Level>().Check(lvl.GetComponent<Level>().ooo)){
				lvl.GetComponent<Level>().ChangeShape();
				lvl.GetComponent<Level>().end=true;

			}
			//if (lvl.GetComponent<Level>().left>0) lvl.GetComponent<Level>().CheckTurn();
			//if (lvl.GetComponent<Level>().left==0) lvl.GetComponent<Level>().NewPart();
				

		}
		else {
			GetComponent<AudioSource>().clip=Wrong;
			GetComponent<AudioSource>().Play();
			this.transform.localScale = new Vector3(1f,1f,-1);
			this.transform.position = startPos;
		}
			
	}
	int[,] RotateMatrix(int[,] a,int rots){
		if (rots==0) return a;
		else {
			int[,] b = new int[5,5];
			for(int n=0;n<rots;n++){
				
				for (int i=0;i<5;i++){
					for (int j=0;j<5;j++){
						b[j,5-i-1]=a[i,j];
					}
				}
				for (int i=0;i<5;i++){
					for (int j=0;j<5;j++){
						a[i,j]=b[i,j];
					}
				}
			}
			return b;
		}

	}
	void SetDopShape(int index,int rots){
		switch (index){
		case 0:
			if (rots%2==0) dopShape=dopShapes[0];
			else dopShape=dopShapes[1];
			break;
		case 1: 
			dopShape = dopShapes[2];
			break;
		case 2:
			if (rots%2==0) dopShape=dopShapes[3];
			else dopShape=dopShapes[4];
			break;
		case 3: 
			dopShape = dopShapes[5];
			break;
		case 4:
			if (rots%2==0) dopShape=dopShapes[6];
			else dopShape=dopShapes[7];
			break;
		case 5:
			dopShape=dopShapes[8+rots];
			break;
		case 6:
			dopShape=dopShapes[12+rots];
			break;
		case 7:
			dopShape=dopShapes[16];
			break;


		}
	}
	string ShowMatrix(int[,] a){
		string str="";
		for (int i=0;i<a.Length;i++){
			for (int j=0;j<5;j++){
				str+=a[i,j];
			}
			str+="\n";
		}
		return str;
	}


}
