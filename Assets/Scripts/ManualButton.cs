using UnityEngine;
using System.Collections;



public class ManualButton : MonoBehaviour {

	void OnMouseUp(){

		GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r+0.05f,
		                                                 GetComponent<SpriteRenderer>().color.g+0.05f,
		                                                 GetComponent<SpriteRenderer>().color.b+0.05f,
		                                                 1);
		Application.LoadLevel(2);
		PlayerPrefs.SetInt("isFirst",1);
	}
	void OnMouseDown(){
		GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r-0.05f,
		                                                 GetComponent<SpriteRenderer>().color.g-0.05f,
		                                                 GetComponent<SpriteRenderer>().color.b-0.05f,
		                                                 1);
	}
	void Start(){

		switch  (Application.systemLanguage.ToString()){
		case "Russian":
			transform.FindChild("manual").GetComponent<TextMesh>().text = "Как играть";
			break;
		case "Ukrainian":
			transform.FindChild("manual").GetComponent<TextMesh>().text = "Як грати ?";
			break;
			
		default:
			transform.FindChild("manual").GetComponent<TextMesh>().text = "How to play";
			break;
		}

		/*if (PlayerPrefs.GetInt("isFirstTime") != 1)
		{
			Social.localUser.Authenticate(authenticated =>
			                              {
				if (!authenticated || !Social.localUser.authenticated){}});
			Social.ReportScore(PlayerPrefs.GetInt ("Record"), "CgkIi7D7pIMWEAIQCA", (bool success) =>{});
		}*/

	}
}
