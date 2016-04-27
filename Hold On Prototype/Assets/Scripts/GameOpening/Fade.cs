using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

	public GameObject protesters;
	public float fadeTimer = 56; //should be 56
	public GameObject protestSceneManager;


	void Update(){
		CanvasGroup canvasGroup =  GetComponent<CanvasGroup> ();

		if (fadeTimer < 2) {
			protesters.SetActive (true);
			canvasGroup.alpha -= Time.deltaTime / 10;
		}

		if (canvasGroup.alpha == 0 && fadeTimer < -5) {

			protestSceneManager.SetActive (true);
		}
	}
		
	void FixedUpdate(){

		fadeTimer -= Time.fixedDeltaTime;
	}
}
