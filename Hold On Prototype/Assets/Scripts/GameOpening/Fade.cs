using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

	public GameObject protesters;
	public float fadeTimer = 4.5f; //should be 56
	GameObject protestSceneManager;


	void Update(){
		CanvasGroup canvasGroup =  GetComponent<CanvasGroup> ();

		if (fadeTimer < 2) {
			protesters.SetActive (true);
			canvasGroup.alpha -= Time.deltaTime / 10;
		}

		if (canvasGroup.alpha == 0 && fadeTimer < -2) {

			protestSceneManager.SetActive (true);
		}

		
	}
		
	void FixedUpdate(){

		fadeTimer -= Time.fixedDeltaTime;
	}
}
