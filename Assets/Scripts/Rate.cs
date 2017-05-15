using UnityEngine;
using System.Collections;

public class Rate : MonoBehaviour {
	string urlString = "market://details?id=" + "com.Happaro.FizruksTest";
	public void Ono(){
		if (this.transform.tag == "resume") {
			Time.timeScale=1;	
			Destroy (transform.parent.gameObject);
				}
		if (this.transform.tag == "rate")
			Application.OpenURL (urlString);
		if (transform.tag == "exit")
						Application.Quit ();

	}
}
