using UnityEngine;
using System.Collections;

public class RevisedOpeningScene : MonoBehaviour {

	public float timer = 0f;

	public Camera openingCam1;
	public Camera openingCam2;
	public Camera openingCam3;
	public Camera openingCam4;
	public Camera openingCam5;

	public GameObject burningMan;
	public GameObject singleProtester;
	public GameObject openingRubbleSidiBouzid;
	public GameObject openingRubbleTunisia;
	public GameObject openingRubbleEgypt;
	public GameObject openingRubbleLibya;
	public GameObject openingRubbleSyria;
	public GameObject openingProtestersEgypt;
	public GameObject openingProtestersEgypt2;
	public GameObject openingProtestersLibya;
	public GameObject openingEnemiesLibya;
	public GameObject openingProtestersSyria;
	public GameObject openingEnemiesSyria;

	public Light mainLight;

	public CanvasGroup canvas;

	void Start(){
		burningMan.SetActive (true);
		openingCam2.enabled = false;
		openingCam3.enabled = false;
		openingCam4.enabled = false;
		openingCam5.enabled = false;
	}

	void FixedUpdate () {

		timer += Time.fixedDeltaTime;

		openingCam1.transform.LookAt (burningMan.transform.position);
		openingCam1.transform.position = Vector3.Lerp (openingCam1.transform.position, burningMan.transform.position, Time.fixedDeltaTime / 8);

		if (timer > 6 & timer <= 8.5) {
			canvas.alpha = 0;
			HP health = burningMan.GetComponent<HP>();
			health.hitpoints = 0;
		}

		if (timer > 8.5 & timer <= 10) {
			canvas.alpha = 1f;
			openingRubbleSidiBouzid.SetActive (false);
		}

		//"Ben Ali fled"
		if (timer > 10 & timer <= 15.5) {
			if (timer > 10 & timer <= 10.1) {	
				openingCam1.transform.position = new Vector3 (-10, 6, -29);
			}

			mainLight.enabled = false;
			canvas.alpha = 0f;
			singleProtester.SetActive (true);
			openingRubbleTunisia.SetActive (true);
			openingCam1.transform.LookAt (singleProtester.transform.position);

			Vector3 singleProtesterDest = new Vector3 (singleProtester.transform.position.x, singleProtester.transform.position.y, 0);
			singleProtester.transform.position = Vector3.Lerp (singleProtester.transform.position, singleProtesterDest, Time.fixedDeltaTime / 6);

			Vector3 cam1Dest = new Vector3 (openingCam1.transform.position.x, openingCam1.transform.position.y, 0);
//			openingCam1.transform.Translate (Vector3.up * Time.fixedDeltaTime * 2);
//			openingCam1.transform.position = Vector3.Lerp (openingCam1.transform.position, cam1Dest, Time.fixedDeltaTime / 8);
		}

		if (timer > 15.5 & timer <= 17) {
			Destroy (openingCam1);
			canvas.alpha = 1;
			singleProtester.SetActive (false);
			openingRubbleTunisia.SetActive (false);
		}

		//"The people want to topple the regime"
		if (timer > 17 & timer <= 21.5) {
			openingProtestersEgypt.SetActive (true);
			openingRubbleEgypt.SetActive (true);
			openingCam2.enabled = true;
			openingCam1.enabled = false;
			canvas.alpha = 0f;

			Vector3 cam2Dest = new Vector3 (-15, 3, -15);
			openingCam2.transform.position = Vector3.Lerp (openingCam2.transform.position, cam2Dest, Time.fixedDeltaTime / 8);

		}

		if (timer > 21.5 & timer <= 23.3) {
			canvas.alpha = 1;

		}

		//Omar Suleiman starts speaking; timer here accounts for that entire period, not subtitle changes
		if (timer > 23.3 & timer <= 29.9) {
			openingProtestersEgypt.SetActive (false);
			openingProtestersEgypt2.SetActive (true);
			openingCam3.enabled = true;
			openingCam2.enabled = false;
			Destroy (openingCam2);
			canvas.alpha = 0f;

			Vector3 cam3destination = new Vector3 (-15, openingCam3.transform.position.y, openingCam3.transform.position.z);
			openingCam3.transform.position = Vector3.Lerp (openingCam3.transform.position, cam3destination, (Time.fixedDeltaTime / 5));
		}
			

		//Omar Suleiman stops
		if (timer > 29.9 & timer <= 32.4) {
			canvas.alpha = 1;
		}

		//Qaddafi speaks
		if (timer > 32.4 & timer <= 37.9) {
			mainLight.enabled = true;
			openingCam4.enabled = true;
			openingCam3.enabled = false;
			Destroy (openingCam3);
			openingProtestersEgypt2.SetActive (false);
			openingRubbleEgypt.SetActive (false);
			openingRubbleLibya.SetActive (true);
			openingProtestersLibya.SetActive (true);
			openingEnemiesLibya.SetActive (true);

			canvas.alpha = 0f;


//			openingCam4.transform.LookAt(new Vector3(-20, 0, -7));
			openingCam4.transform.position = Vector3.Lerp (openingCam4.transform.position, new Vector3(1, openingCam4.transform.position.y, openingCam4.transform.position.z), (Time.fixedDeltaTime / 12));
		}

		//Qaddafi stops
		if (timer > 37.9 & timer <= 40) {
			canvas.alpha = 1;

		}

		//Bashar begins
		if (timer > 40) {
			openingRubbleLibya.SetActive (false);
			openingProtestersLibya.SetActive (false);
			openingEnemiesLibya.SetActive (false);

			openingRubbleSyria.SetActive (true);
			openingProtestersSyria.SetActive (true);
			openingEnemiesSyria.SetActive (true);

			openingCam5.enabled = true;
			openingCam4.enabled = false;
			Destroy (openingCam4);
			canvas.alpha = 0f;

			Vector3 lookAtPoint = new Vector3 (-10, 0, -20);
			openingCam5.transform.LookAt (lookAtPoint);
			openingCam5.transform.Translate (Vector3.right * Time.fixedDeltaTime);
		}

	}


}
