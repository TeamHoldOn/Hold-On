using UnityEngine;
using System.Collections;

public class ProtestScene : MonoBehaviour {

	public Camera mainCamera;// = Camera.main;
	public Camera protestCamera;
	public GameObject enemy;
	private Vector3 spawnPoint;
	public float protestTimer = 1f;

	void Start() {
		mainCamera.enabled = true;
		protestCamera.enabled = false;
	}

	public void beginProtest(){
		mainCamera.enabled = false;
		protestCamera.enabled = true;
		// set protesters to active 
		// spawn enemies near protestors
		Invoke("spawnEnemies", 8);

		protestTimer -= Time.deltaTime;
		if (protestTimer <= 0) {
			mainCamera.enabled = true;
			protestCamera.enabled = false;
		}
	}

//	public void endProtest(){
//		protestCamera.enabled = false;
//		mainCamera.enabled = true;
//		CancelInvoke ();
//	}

	public void spawnEnemies(){
		spawnPoint.x = Random.Range(-45, -55);
		spawnPoint.y = 1.5f;
		spawnPoint.z = Random.Range(-35, -45);

		Instantiate(enemy, spawnPoint, Quaternion.identity);
		Instantiate(enemy, spawnPoint, Quaternion.identity);

		CancelInvoke();
	}


}
