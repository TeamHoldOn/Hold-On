using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

	void Update(){

		Invoke ("fadeOut", 2);
	}

	void fadeOut(){

		CanvasGroup canvasGroup = GetComponent<CanvasGroup> ();

		if (canvasGroup.alpha > 0) {
			canvasGroup.alpha -= Time.deltaTime / 10;
		}

		//		if (canvasGroup.alpha == 0) {
		//			Destroy (this.gameObject);
		//		}
	}
}
