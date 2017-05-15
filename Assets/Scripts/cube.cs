using UnityEngine;
using System.Collections;

public class cube : MonoBehaviour {

	Vector3 newPos;
	public Vector2 pos;
	GameObject enemy;
	GameObject lvl;
	public bool end;
	void Start(){
		lvl = GameObject.FindGameObjectWithTag("Level");
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag=="ware"){
			enemy = other.gameObject;
		}

	}
	void OnTriggerStay2D(Collider2D other){
		other.GetComponent<SpriteRenderer>().color = new Color(0.5f,0.5f,0.5f,1);
	}
	void OnTriggerExit2D(Collider2D other){
		other.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.31f,0.31f,0.31f,1);
	}
	void Update(){
		if (end)
			StartCoroutine(Die ());
	}
	public void Check(){
		enemy.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.31f,0.31f,0.31f,1);
		try{int x = (int)enemy.transform.GetComponent<Ware>().pos.x;
			int y = (int)enemy.GetComponent<Ware>().pos.y;
			if (lvl.GetComponent<Level>().pole[x,y]==1)
				transform.parent.GetComponent<Figure>().mozhna=false;
		}catch{transform.parent.GetComponent<Figure>().mozhna=false;}

	}
	public void Fix(){

		GetComponent<Animation>().clip = GetComponent<Animation>().GetClip("Fix");
		GetComponent<Animation>().Play();
		int x = (int)enemy.transform.GetComponent<Ware>().pos.x;
		int y = (int)enemy.GetComponent<Ware>().pos.y;
		//GameObject.Find("TurnBack").transform.GetComponent<TurnBack>().lastCubesX.Add(x);
		//GameObject.Find("TurnBack").transform.GetComponent<TurnBack>().lastCubesY.Add(y);
		this.name = ""+x+y;
		transform.parent = null;
		this.transform.localScale = new Vector3(1f,1f,0);
		lvl.GetComponent<Level>().pole[x,y]=1;
		lvl.GetComponent<Level>().Score++;
		this.transform.position = enemy.transform.position;
		Destroy(this.GetComponent<CircleCollider2D>());
		//transform.localScale = new Vector3(0.5f,0.5f,0);
		enemy.GetComponent<Ware>().zan=true;	
	}


	IEnumerator Die() {
		GetComponent<Animation>().Play("Destroy");
		yield return new WaitForSeconds(1);
		Destroy(this.gameObject);//this will wait 5 seconds
	}
}
