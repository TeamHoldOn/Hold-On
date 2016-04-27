using UnityEngine;
using System.Collections;

public class ProtestScene : MonoBehaviour {

	public Camera mainCamera;
	public Camera protestCamera;
	public GameObject enemy;
	private Vector3 spawnPoint;
	public float protestTimer = 5f;
	public GameObject enemySpawner;
	public GameObject protesters;
	public bool protestEnabled = false;
	private Vector3 cameraPositionOffset;

	void Start() {
		mainCamera.enabled = false;
		protestCamera.enabled = true;
		beginProtest ();
	}

	public void Update(){

		protestTimer -= Time.deltaTime / 25;

		if (protestTimer <= 0) {

			protestCamera.transform.position = Vector3.Lerp(protestCamera.transform.position, mainCamera.transform.position, Time.deltaTime / 2.5f);
			protestCamera.transform.rotation = Quaternion.Lerp (protestCamera.transform.rotation, mainCamera.transform.rotation, Time.deltaTime / 2);

			if (mainCamera.transform.position.x - protestCamera.transform.position.x < .05) {

				mainCamera.enabled = true;
				protestCamera.enabled = false;
				Destroy (protestCamera);
				enemySpawner.SetActive (true);
			}
		}
	}

	public void beginProtest(){
		protestEnabled = true;
		mainCamera.enabled = false;
		protestCamera.enabled = true;
		spawnEnemies ();
        chant.startChant = true;
	}

	public void spawnEnemies(){
		spawnPoint.x = Random.Range(-40, -50);
		spawnPoint.y = 1.5f;
		spawnPoint.z = -25f;

		Instantiate(enemy, spawnPoint, Quaternion.identity);
		Instantiate(enemy, spawnPoint, Quaternion.identity);
		CancelInvoke();
	}
}
