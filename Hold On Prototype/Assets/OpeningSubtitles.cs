using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OpeningSubtitles : MonoBehaviour {

	float timer = 0f;
	Text subtitle; 

	void Start () {

		subtitle = GetComponent<Text>();

			
	}
	
	void FixedUpdate () {
//		StartCoroutine (SubtitleText()); 
		timer += Time.fixedDeltaTime;

		if (timer > 6){
			subtitle.text = "I understood you. Yes, I understood you.";
		}

		if (timer > 8.5) {
			subtitle.text = "";
		}

		if (timer > 10) {
			subtitle.text = "Ben Ali fled!";
		}

		if (timer > 15.5) {
			subtitle.text = "";
		}

		if (timer > 17) {
			subtitle.text = "The people want to topple the regime!";
		}

		if (timer > 21.5) {
			subtitle.text = "";
		}

		if (timer > 23.3) {
			subtitle.text = "President Hosni Mubarak has decided";
		}

		if (timer > 25.2){
			subtitle.text = "";
		}

		if (timer > 26.8) {
			subtitle.text = "to relinquish the position of president of the republic";
		}

		if (timer > 29.9) {
			subtitle.text = "";
		}

		if (timer > 32.4) {
			subtitle.text = "...inch by inch!";
		}

		if (timer > 33.9){
			subtitle.text = "Home by home!";
		}

		if (timer > 35){
			subtitle.text = "House by house! Alley by alley!";
		}

		if (timer > 37.9){
			subtitle.text = "";
		}

		if (timer > 40) {
			subtitle.text = "If you have chanted 'With our blood and with our souls, we sacrifice ourselves for you, Bashar,'";
		}

		if (timer > 43) {
			subtitle.text = "then it is only right that President Bashar be a sacrifice for his nation and people.";
		}

		if (timer > 46.5) {
			subtitle.text = "";
		}

		if (timer > 48.5) {
			subtitle.text = "Only Allah, Syria, and Bashar!";
		}

		if (timer > 54) {
			subtitle.text = "";
		}
	
	}

//	IEnumerator SubtitleText(){
//		yield return new WaitForSeconds (6f);
//		subtitle.text = "I understood you. Yes, I understood you."; 
//
//		yield return new WaitForSeconds(2f);
//		subtitle.text = "";
//
//		yield return new WaitForSeconds (3f);
//		subtitle.text = "Ben Ali fled!";
//	
//	}
}
