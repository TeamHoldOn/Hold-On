using UnityEngine;
using System.Collections;

public class ProtestScene : MonoBehaviour {

	public Camera mainCamera;// = Camera.main;
	public Camera protestCamera;
	public GameObject enemy;
	private Vector3 spawnPoint;
	public float protestTimer = 5f;
	public GameObject enemySpawner;
	public GameObject protesters;
	public static bool protestEnabled = false;

	void Start() {
		mainCamera.enabled = true;
		protestCamera.enabled = false;
	}

	public void Update(){

		if (protestEnabled == true) {
			protestTimer -= Time.deltaTime / 50;

			if (protestTimer <= 0) {
				mainCamera.enabled = true;
				protestCamera.enabled = false;
				enemySpawner.SetActive (true);
				protestEnabled = false;
			}
		}
	}

	public void beginProtest(){
		protestEnabled = true;
		mainCamera.enabled = false;
		protestCamera.enabled = true;
		protesters.SetActive (true);
		Invoke("spawnEnemies", 6);
	}

	public void spawnEnemies(){
		spawnPoint.x = Random.Range(-30, -38);
		spawnPoint.y = 1.5f;
		spawnPoint.z = -30;

		Instantiate(enemy, spawnPoint, Quaternion.identity);
		Instantiate(enemy, spawnPoint, Quaternion.identity);
		CancelInvoke();
	}
}
