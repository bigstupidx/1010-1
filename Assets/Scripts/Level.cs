using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour {

	public GameObject back_pixel,shape,needPrefab,gameOverWindow,pauseWindow,rateWindow;
	public Camera cam;
	GameObject tmp,tmp1,tmp2,tmp3;
	int x,y;
	public AudioClip destroy,lose,newRecord;
	public Color[] colorsDay, colorsNight;
	public int Score;
	public int left=0;
	public int[,] prevShape;
	public int[,] needShape;
	GameObject myNeed,myNeed2;
	public bool end;
	bool isDay;
	bool isnewrec;
	bool cr=false;
	bool isGameOver;
	bool isFirst=true;
	float shakeTime;
	string[] achievs = {"CgkIi7D7pIMWEAIQAA","CgkIi7D7pIMWEAIQAQ","CgkIi7D7pIMWEAIQCg","CgkIi7D7pIMWEAIQAw",
		"CgkIi7D7pIMWEAIQBA","CgkIi7D7pIMWEAIQBQ","CgkIi7D7pIMWEAIQBg","CgkIi7D7pIMWEAIQBw"};

	public int[,] pole = new int[,]{{0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0}};

	public int[,] ooo,oooNext;
	List<Transform> backPix = new List<Transform>();
	public int[][,] shapes  = new int[][,]{
		new int[,]{ {0,1,1,0},
					{1,1,1,1},
					{1,1,1,1},
					{0,1,1,0}},
		new int[,]{ {0,0,1,0,0},
					{0,1,1,1,0},
					{1,1,1,1,1}},

		new int[,]{ {1,1,0,0,1,1},
					{1,1,0,0,1,1},
					{1,1,1,1,1,1},},

		new int[,]{ {1,0,0,0},
					{1,1,0,0},
					{1,1,1,0},
					{1,1,1,1}},
		
		new int[,]{ {1,1,1,1},
					{1,1,1,1},
					{0,1,1,0},
					{0,1,1,0}},
		new int[,]{ {0,0,0,1,0,0,0},
					{0,0,1,1,1,0,0},
					{0,1,1,1,1,1,0}},

		new int[,]{ {1,1,1,1},
					{1,0,0,1},
					{1,0,0,1},
					{1,1,1,1}},

		new int[,]{{1,1,1,1,1,1,1,1,1,1}},

		new int[,]{{1,1,1,1,1,1},
					{1,1,1,1,1,1}},
				
		/*new int[,]{{1,1},
					{1,1},
					{1,1},
					{1,1},
					{1,1},
					{1,1},
					{1,1},
					{1,1},
					{1,1},
					{1,1}},*/
		new int[,]{{1},
			{1},
			{1},
			{1},
			{1},
			{1},
			{1},
			{1},
			{1},
			{1}},

		new int[,]{{1,1,1,1},
			{1,1,1,1},
			{1,1,1,1},
			{1,1,1,1}},
					
		new int[,]{{1,1,0,0},
					{1,1,0,0},
					{1,1,1,1},
					{1,1,1,1}},
		new int[,]{ {0,1,1,0},
					{1,1,1,1},
					{1,1,1,1},
					{0,1,1,0},
					{0,1,1,0}},

		new int[,]{{0,0,1,1},
				{0,0,1,1},
				{1,1,1,1},
				{1,1,1,1}}
		
	};
	bool showed;

	void Start () {

	
		//PlayerPrefs.SetInt("Record",10);
		NewPart();
		ooo = shapes[Random.Range(0,shapes.Length)];
		oooNext = shapes[Random.Range(0,shapes.Length)];
		myNeed = Instantiate(needPrefab) as GameObject;
		myNeed.GetComponent<Need>().Change();
		myNeed2 = Instantiate(needPrefab) as GameObject;
		myNeed2.transform.Translate(-2f,0,0);
		myNeed2.transform.name="ooo2";
		myNeed2.GetComponent<Need>().Change();
		for (int i=0;i<10;i++){
			for (int j=0;j<10;j++){

				tmp = Instantiate(back_pixel,new Vector3(j*0.5f,i*(-0.5f),0),Quaternion.identity) as GameObject;
				tmp.transform.parent = this.transform;
				tmp.name = ""+i+"-"+j;
				tmp.GetComponent<Ware>().pos=new Vector2(i,j);
				 backPix.Add(tmp.transform);
			}
		}
	}

	void Update () {
		shakeTime+=Time.deltaTime;
		if (Input.acceleration.magnitude>2f&&shakeTime>1){
			if (isDay){
				cam.backgroundColor = colorsDay[0];
				for (int i=0;i<backPix.Count;i++){
					backPix[i].GetComponent<SpriteRenderer>().color = colorsDay[1];
				}
			}
				
			else {
				cam.backgroundColor = colorsNight[0];
				for (int i=0;i<backPix.Count;i++){
					backPix[i].GetComponent<SpriteRenderer>().color = colorsNight[1];
				}
			}
			isDay = isDay? false:true;
			shakeTime=0;
		}
		if (end){
			StartCoroutine(More());

		}

		if (Input.GetKeyDown(KeyCode.Escape))
				Application.LoadLevel(0);
		if (Input.GetKeyDown(KeyCode.R)) Application.LoadLevel(Application.loadedLevel);
	
	}
	public void NewPart(){
		tmp1 = Instantiate(shape) as GameObject;
		tmp1.name="shape1";
		tmp1.GetComponent<Figure>().iStart();
		tmp2 = Instantiate(shape) as GameObject;
		tmp2.name="shape2";
		tmp2.transform.Translate(1.75f,0,0);
		tmp2.GetComponent<Figure>().iStart();

		tmp3 = Instantiate(shape) as GameObject;
		tmp3.name="shape3";
		tmp3.transform.Translate(3.5f,0,0);
		tmp3.GetComponent<Figure>().iStart();

		left=3;
		print ("sozdano");
		/*if (isFirst) isFirst=false;
		else CheckTurn();*/
	}
	public bool Check(int[,] oo){
		if (!isnewrec&&Score > PlayerPrefs.GetInt("Record"))
		{
			GetComponent<AudioSource>().clip = newRecord;
			GetComponent<AudioSource>().Play();
			isnewrec=true;
		}

		bool isFind=true;
		for (int n1=0;n1<10-oo.GetLength(0)+1;n1++){
			for (int n2=0;n2<10-oo.GetLength(1)+1;n2++){
				isFind=true;
				for (int i=0+n1;i<oo.GetLength(0)+n1;i++){
					for (int j=0+n2;j<oo.GetLength(1)+n2;j++){

						if (oo[i-n1,j-n2]==1&&pole[i,j]!=1){
							isFind=false;

							break;
						}
						x=n1;
						y=n2;
					}
				}
				if (isFind)

					break;
			}
			if (isFind)
				break;
		}

		if (isFind){
			int a=x,b=y;
					for (int i=x;i<oo.GetLength(0)+x;i++){
						for (int j=y;j<oo.GetLength(1)+y;j++){
							if (oo[i-a,j-b]==1){
								GameObject.Find(""+i+""+j).GetComponent<cube>().end=true;
								pole[i,j]=0;
								Score+=2;
								
							}
						}
					}
			GetComponent<AudioSource>().clip = destroy;
			GetComponent<AudioSource>().Play ();

			Check(oo);

		}
		if (left==0) NewPart();
		CheckTurn();
		return isFind;
		//needShape=Random.Range();

		//isFind=false;


	}
	public void Hummer(){
		
		for (int i=2;i<8;i++){
			for (int j=2;j<8;j++){

				try{
					GameObject.Find(""+i+""+j).GetComponent<cube>().end=true;
					pole[i,j]=0;
					Score++;
				}catch{}
					//Score+=1;
					

			}
		}
		GetComponent<AudioSource>().clip = destroy;
		GetComponent<AudioSource>().Play ();
	}
	void ShowMatrix(int[,] a){
		string str="";
		for (int i=0;i<10;i++){
			for (int j=0;j<10;j++){
				str+=a[i,j];
			}
			str+="\n";
		}
		print(str);
	}
	public void ChangeShape(){
		ooo = oooNext;
		oooNext = shapes[Random.Range(0,shapes.Length)];
		Destroy(myNeed.gameObject);
		Destroy(myNeed2.gameObject);


		myNeed = Instantiate(needPrefab) as GameObject;
		myNeed.transform.name="ooo1";
		myNeed.GetComponent<Need>().Change();
		myNeed2 = Instantiate(needPrefab) as GameObject;
		myNeed2.transform.Translate(-2f,0,0);
		myNeed2.transform.name="ooo2";
		myNeed2.GetComponent<Need>().Change();

		/*
		myNeed =  myNeed2;
		myNeed.transform.Translate(2f,0,0);
		myNeed.transform.name="ooo1";
		myNeed.GetComponent<Need>().Change();
		myNeed2 = Instantiate(needPrefab) as GameObject;
		myNeed2.transform.Translate(-2f,0,0);
		myNeed2.transform.name="ooo2";
		myNeed2.GetComponent<Need>().Change();
		//Check(ooo);*/
	}
	
	IEnumerator More() {
		yield return new WaitForSeconds(2);
		if (Check(ooo)){

			ChangeShape();
			end=true;
		}
		//this will wait 5 seconds
		else {
			if (isGameOver&&!cr){


				print("game over more end");
				if (PlayerPrefs.GetInt("Record")<Score) PlayerPrefs.SetInt("Record",Score);
				GameObject g = Instantiate(gameOverWindow) as GameObject;
				try{GameObject.Find("shape1").GetComponent<CircleCollider2D>().enabled=false;}catch{}
				try{GameObject.Find("shape2").GetComponent<CircleCollider2D>().enabled=false;}catch{}
				try{GameObject.Find("shape3").GetComponent<CircleCollider2D>().enabled=false;}catch{}
				try{GameObject.Find("BackTurn").GetComponent<TurnBack>().enabled=false;}catch{}
				g.name="gameover";
				GetComponent<AudioSource>().clip = lose;
				GetComponent<AudioSource>().Play();
				g.transform.FindChild("text").GetComponent<GUIText>().text = "No available moves\nScore: "+Score;
				if (Application.systemLanguage.ToString()=="Russian")
				g.transform.FindChild("text").GetComponent<GUIText>().text = "Больше некуда всунуть\nСчет: "+Score;
				if (Application.systemLanguage.ToString()=="Ukrainian")
				g.transform.FindChild("text").GetComponent<GUIText>().text = "Більше нікуди впихнути\nРахунок: "+Score;
				//if (CheckTurn) Destroy(g);
				cr=true;

				
				PlayerPrefs.SetInt("AdsNum",PlayerPrefs.GetInt("AdsNum")+1);
				if (PlayerPrefs.GetInt("AdsNum") % 7 == 0 && PlayerPrefs.GetInt("isRated") == 0){
					Instantiate(rateWindow); 
				}

			}

			end = false;
		}
	
	}

	public void CheckTurn(){
		isGameOver=true;
		bool tmpBool;
		try{
			tmpBool = CheckShape(GameObject.Find("shape1").GetComponent<Figure>().dopShape);
			if (tmpBool) isGameOver=false;
			print ("1 - "+tmpBool);
		}catch{print ("1 dont ava");}
		try{
			tmpBool = CheckShape(GameObject.Find("shape2").GetComponent<Figure>().dopShape);
			if (tmpBool) isGameOver=false;
			print ("2 - " +tmpBool);

		}catch{print ("2 dont ava");}
		try{
			tmpBool = CheckShape(GameObject.Find("shape3").GetComponent<Figure>().dopShape);
			if (tmpBool) isGameOver=false;
			print ("3 - " +tmpBool);
		}catch{print ("3 dont ava");}

		if (isGameOver) {StartCoroutine(More()); print("simple game over");}
		/*if (isGameOver){
			if (PlayerPrefs.GetInt("Record")<Score) PlayerPrefs.SetInt("Record",Score);
			GameObject g = Instantiate(gameOverWindow) as GameObject;
			try{GameObject.Find("shape1").GetComponent<CircleCollider2D>().enabled=false;}catch{}
			try{GameObject.Find("shape2").GetComponent<CircleCollider2D>().enabled=false;}catch{}
			try{GameObject.Find("shape3").GetComponent<CircleCollider2D>().enabled=false;}catch{}
			try{GameObject.Find("BackTurn").GetComponent<TurnBack>().enabled=false;}catch{}
			g.name="gameover";
			g.transform.FindChild("text").GetComponent<GUIText>().text = "Ходи закінчились\nРахунок: "+Score;
			//if (CheckTurn) Destroy(g);
		}*/

	}
	bool CheckShape(int[,] ssshape){


			bool isAv=true;
		for (int n1=0;n1<10-ssshape.GetLength(0)+1;n1++){
			for (int n2=0;n2<10-ssshape.GetLength(1)+1;n2++){
				isAv=true;
				for (int i=0+n1;i<ssshape.GetLength(0)+n1;i++){
					for (int j=0+n2;j<ssshape.GetLength(1)+n2;j++){
							
						if (ssshape[i-n1,j-n2]==1&&pole[i,j]!=0){
							isAv=false;
								
								break;
							}
							x=n1;
							y=n2;
						}
					}
					if (isAv)
						
						break;
				}
				if (isAv)
					break;
		}
		return isAv;
	}

}
