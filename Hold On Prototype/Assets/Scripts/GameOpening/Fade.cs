using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

	void Update(){

		Invoke ("fadeOut", 56);
	}

	void fadeOut(){

		CanvasGroup canvasGroup = GetComponent<CanvasGroup> ();

		if (canvasGroup.alpha > 0) {
			canvasGroup.alpha -= Time.deltaTime / 10;
		}
	}
}
