using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

	public GameObject protesters;
	public float fadeTimer = 56f;
	CanvasGroup canvasGroup;
	GameObject protestSceneManager = GameObject.Find("ProtestSceneManager");

	void FixedUpdate(){

		fadeTimer -= Time.fixedDeltaTime;
		ProtestScene ps = protestSceneManager.GetComponent<ProtestScene>();
		canvasGroup =  GetComponent<CanvasGroup> ();

		if (fadeTimer < 4) {
			protesters.SetActive (true);
			canvasGroup.alpha -= Time.deltaTime / 10;
		}

		if (ps.protestEnabled == false && fadeTimer > -6) {
			
			ps.beginProtest();
		}
	}
}
