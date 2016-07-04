using UnityEngine;
using System.Collections;

public class RevisedOpeningScene : MonoBehaviour {

	public float timer = 0f;

	public Camera openingCam1;
	public Camera openingCam2;
	public Camera openingCam3;
	public Camera openingCam4;

	public GameObject burningMan;
	public GameObject singleProtester;
	public GameObject openingRubbleTunisia;
	public GameObject openingRubbleEgypt;
	public GameObject openingRubbleLibya;
	public GameObject openingRubbleSyria;
	public GameObject openingProtestersEgypt;
	public GameObject openingProtestersLibya;
	public GameObject openingEnemiesLibya;
	public GameObject openingProtestersSyria;
	public GameObject openingEnemiesSyria;



	public CanvasGroup canvas;

	void Start(){
		burningMan.SetActive (true);
		openingCam2.enabled = false;
		openingCam3.enabled = false;
		openingCam4.enabled = false;

	}

	void FixedUpdate () {

		timer += Time.fixedDeltaTime;

		openingCam1.transform.LookAt (burningMan.transform.position);


		if (timer > 8.5) {
			canvas.alpha = 1f;
		}

		//"Ben Ali fled"
		if (timer > 10) {
			canvas.alpha = 0.4f;
			burningMan.SetActive (false);
			singleProtester.SetActive (true);
			openingRubbleTunisia.SetActive (true);
			openingCam1.transform.LookAt (singleProtester.transform.position);

			Vector3 singleProtesterDest = new Vector3 (singleProtester.transform.position.x, singleProtester.transform.position.y, 0);
			singleProtester.transform.position = Vector3.Lerp (singleProtester.transform.position, singleProtesterDest, Time.fixedDeltaTime / 9);

			Vector3 cam1Dest = singleProtesterDest;
			openingCam1.transform.position = Vector3.Lerp (openingCam1.transform.position, cam1Dest, Time.fixedDeltaTime / 12);
		}

		if (timer > 15.5) {
			canvas.alpha = 1;
			singleProtester.SetActive (false);
			openingRubbleTunisia.SetActive (false);

		}

		//"The people want to topple the regime"
		if (timer > 17) {
			openingProtestersEgypt.SetActive (true);
			openingRubbleEgypt.SetActive (true);
			openingCam2.enabled = true;
			openingCam1.enabled = false;
			canvas.alpha = 0.4f;

			Vector3 cam2Dest = new Vector3 (-15, 3, -15);
			openingCam2.transform.position = Vector3.Lerp (openingCam2.transform.position, cam2Dest, Time.fixedDeltaTime / 8);

		}

		if (timer > 21.5) {
			canvas.alpha = 1;
		}

		//Omar Suleiman starts speaking; timer here accounts for that entire period, not subtitle changes
		if (timer > 23.3) {
			openingCam3.enabled = true;
			openingCam2.enabled = false;
			canvas.alpha = 0.4f;

			Vector3 cam3destination = new Vector3 (-15, openingCam3.transform.position.y, openingCam3.transform.position.z);
			openingCam3.transform.position = Vector3.Lerp (openingCam3.transform.position, cam3destination, (Time.fixedDeltaTime / 8));
		}
			

		//Omar Suleiman stops
		if (timer > 29.9) {
			canvas.alpha = 1;
//			protesterGroup.GetComponentsInChildren<RigidbodyConstraints>();
		}

		//Qaddafi speaks
		if (timer > 32.4) {
			canvas.alpha = 0.4f;
//			NearestHexFinder.allInstantiated = true;
			openingCam4.enabled = true;
			openingCam3.enabled = false;
			openingProtestersEgypt.SetActive (false);
			openingProtestersLibya.SetActive (true);
			openingEnemiesLibya.SetActive (true);

			openingCam4.transform.LookAt(new Vector3(0, 1, -25));
			openingCam4.transform.position = Vector3.Lerp (openingCam4.transform.position, new Vector3(-35, openingCam4.transform.position.y, openingCam4.transform.position.z), (Time.fixedDeltaTime / 12));
		}

		//Qaddafi stops
		if (timer > 37.9) {
			canvas.alpha = 1;
		}

		//Bashar begins
		if (timer > 40) {
			canvas.alpha = 0.4f;
		}
			

	}
}
