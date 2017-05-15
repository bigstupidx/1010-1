using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Button : MonoBehaviour {

	public Transform[] pixs;
	void Start(){
		if (this.name=="restart"){
			switch  (Application.systemLanguage.ToString()){
			case "Russian":
				this.GetComponent<GUIText>().text = "Заново";
				break;
			case "Ukrainian":
				this.GetComponent<GUIText>().text = "Ще раз";
				break;
			
			default:
				this.GetComponent<GUIText>().text = "Restart";
				break;
			}
		}
		if (this.name=="menu"){
			switch  (Application.systemLanguage.ToString()){
			case "Russian":
				this.GetComponent<GUIText>().text = "Меню";
				break;
			case "Ukrainian":
				this.GetComponent<GUIText>().text = "Меню";
				break;
			default:
				this.GetComponent<GUIText>().text = "Menu";
				break;
			}
		}
		if (this.name=="rate"){
			switch  (Application.systemLanguage.ToString()){
			case "Russian":
				this.GetComponent<GUIText>().text = "Оценить!";
				break;
			case "Ukrainian":
				this.GetComponent<GUIText>().text = "Оцінити!";
				break;
			default:
				this.GetComponent<GUIText>().text = "Rate it!";
				break;
			}
		}
		if (this.name=="noads"){
			switch  (Application.systemLanguage.ToString()){
			case "Russian":
				this.GetComponent<GUIText>().text = "Удалить рекламу";
				break;
			case "Ukrainian":
				this.GetComponent<GUIText>().text = "Задрала реклама";
				break;
			default:
				this.GetComponent<GUIText>().text = "Remove ads";
				break;
			}
		}
		if (this.name=="ratetext"){
			switch  (Application.systemLanguage.ToString()){
			case "Russian":
				this.GetComponent<GUIText>().text = "Если Вам\n понравилась игра,\nможете поставить\n оценку.";
				break;
			case "Ukrainian":
				this.GetComponent<GUIText>().text = "Слава Україні!\nСподобалась гра?\nПостав оцінку!";
				break;
			default:
				this.GetComponent<GUIText>().text = "Have fun with game?\nLet's rate it!";
				break;
			}
		}
		if (this.name=="never"){
			switch  (Application.systemLanguage.ToString()){
			case "Russian":
				this.GetComponent<GUIText>().text = "Не беспокойте меня";
				break;
			case "Ukrainian":
				this.GetComponent<GUIText>().text = "Я москаль";
				break;
			default:
				this.GetComponent<GUIText>().text = "Never!";
				break;
			}
		}
		if (this.name=="no"){
			switch  (Application.systemLanguage.ToString()){
			case "Russian":
				this.GetComponent<GUIText>().text = "Чуть пожже";
				break;
			case "Ukrainian":
				this.GetComponent<GUIText>().text = "Пізніше";
				break;
			default:
				this.GetComponent<GUIText>().text = "Maybe later...";
				break;
			}
		}
		if (this.tag == "GUI"){
			print (this.name);
		this.GetComponent<GUITexture>().pixelInset = new Rect((this.GetComponent<GUITexture>().pixelInset.x*Screen.width/480),
		                                                      (this.GetComponent<GUITexture>().pixelInset.y*Screen.height/800),
		                                                      this.GetComponent<GUITexture>().pixelInset.width*Screen.width/480,
		                                                      this.GetComponent<GUITexture>().pixelInset.height*Screen.height/800);
		}
		if (this.tag == "GUIText"){
			this.GetComponent<GUIText>().fontSize = 39*Screen.height/800;
			GetComponent<GUIText>().pixelOffset = new Vector2(GetComponent<GUIText>().pixelOffset.x*Screen.width/480,
			                                                  GetComponent<GUIText>().pixelOffset.y*Screen.height/800);
		}
		pixs = GetComponentsInChildren<Transform>();
	}
	void OnMouseDown(){

		try{
		GetComponent<AudioSource>().Play();
		}catch{}
		if (this.tag == "GUI"){
			
			transform.parent.GetComponent<GUITexture>().pixelInset = new Rect(transform.parent.GetComponent<GUITexture>().pixelInset.x+3,
			                                                                  transform.parent.GetComponent<GUITexture>().pixelInset.y+3,
			                                                                  transform.parent.GetComponent<GUITexture>().pixelInset.width-6,
			                                                                  transform.parent.GetComponent<GUITexture>().pixelInset.height-6);
		}
		else if (this.tag == "GUIText"){
			transform.parent.GetComponent<GUITexture>().pixelInset = new Rect(this.GetComponent<GUITexture>().pixelInset.x+3,
			                                                      this.GetComponent<GUITexture>().pixelInset.y+3,
			                                                      this.GetComponent<GUITexture>().pixelInset.width-6,
			                                                      this.GetComponent<GUITexture>().pixelInset.height-6);
		}
		else{
			for (int i=1;i<pixs.Length;i++){
				pixs[i].transform.localScale = new Vector3(pixs[i].transform.localScale.x * 1.05f, 
				                                           pixs[i].transform.localScale.y * 1.05f, 
				                                           pixs[i].transform.localScale.z);
			}
		}
		//this.transform.GetComponent<SpriteRenderer>().color  new Color(0.9f,0.9f,0.9f,1f);
	}
	IEnumerator Play()
	{
		yield return new WaitForSeconds(0.5f);
		if 	(PlayerPrefs.GetInt("isFirst")==0){
			PlayerPrefs.SetInt("isFirst",1);
			Application.LoadLevel(2);
		}
		else 
			Application.LoadLevel(1);
	}
	void OnMouseUp(){
		if (this.tag == "GUI"){

			transform.parent.GetComponent<GUITexture>().pixelInset = new Rect(transform.parent.GetComponent<GUITexture>().pixelInset.x-3,
			                                                                  transform.parent.GetComponent<GUITexture>().pixelInset.y-3,
			                                                                  transform.parent.GetComponent<GUITexture>().pixelInset.width+6,
			                                                                  transform.parent.GetComponent<GUITexture>().pixelInset.height+6);
		}
		if (this.tag == "GUIText"){

			transform.parent.GetComponent<GUITexture>().pixelInset = new Rect(this.GetComponent<GUITexture>().pixelInset.x-3,
			                                                      this.GetComponent<GUITexture>().pixelInset.y-3,
			                                                      this.GetComponent<GUITexture>().pixelInset.width+6,
			                                                      this.GetComponent<GUITexture>().pixelInset.height+6);
		}
		else{
			for  (int i=1;i<pixs.Length;i++){
				pixs[i].GetComponent<Animation>().Play();
			}
		}
		//this.transform.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
		switch (this.name){
			case "play":
				StartCoroutine(Play());
			break;
			case "star":
			string urlString = "market://details?id=" + "com.Happaro.TenTenRevolution";
				Application.OpenURL (urlString);
				break;
			case "achievs":
			try{
				Social.ShowAchievementsUI();
			}catch{}		
			break;
			case "restartButton":
				Application.LoadLevel(1);
				break;
			case "menuButton":
			try{
				//GameObject.Find("lvl").GetComponent<Level>().bannerView.Destroy();
			}catch{}
				Application.LoadLevel(0);
				break;
			case "noadsButton":
				string urlString2 = "market://details?id=" + "com.Happaro.TenTenShapeFull";
				Application.OpenURL (urlString2);
				break;

			case "fbButton":
				fbShare("I got new score!","My result is " + " cubes. How about You, dude?");
				break;

			case "noButton":
				Destroy(transform.parent.transform.parent.gameObject);
				break;
			case "neverButton":
				PlayerPrefs.SetInt("isRated",1);
				Destroy(transform.parent.transform.parent.gameObject);
				break;
			case "rateButton":
				string urlString1 = "market://details?id=" + "com.Happaro.TenTenShapeFull";
				Application.OpenURL (urlString1);
				PlayerPrefs.SetInt("isRated",1);
				Destroy(transform.parent.transform.parent.gameObject);
				break;

		}

	}
	/*
	string AppId = ;
	string ShareUrl = ;
	string pictureLink = ;
	string link = "https://play.google.com/store/apps/details?id=com.Happaro.TenTenRevolution";
	string name = ;
	string redirectUri = ;*/

	void fbShare(string caption, string description)
	{
		Application.OpenURL("http://www.facebook.com/dialog/feed" +		                    "?app_id=" + "815513258521230" +
		                    "&link=" + WWW.EscapeURL("http://play.google.com/store/apps/details?id=com.Happaro.TenTenRevolution")+
		                    "&picture=" + WWW.EscapeURL("http://cs618116.vk.me/v618116694/23293/oieu28Vv9H0.jpg") +
		                    "&name=" + WWW.EscapeURL("Amazing game 1010 Shapes") +
		                    "&caption=" + WWW.EscapeURL(caption) +
		                    "&description=" + WWW.EscapeURL(description) +
		                    "&redirect=" + WWW.EscapeURL("http://www.facebook.com"));
	}

}

