using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

	public GameObject protesters;
	public float fadeTimer = 56; //should be 56
	public GameObject protestSceneManager;


	void Start(){
		CanvasGroup canvasGroup = GetComponent<CanvasGroup> ();
		canvasGroup.alpha = .4f;
	}
		
	void FixedUpdate(){

		fadeTimer -= Time.fixedDeltaTime;
	}
}
