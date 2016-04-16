using UnityEngine;
using System.Collections;

public class ProtestScene : MonoBehaviour {

	public Camera mainCamera;// = Camera.main;
	public Camera protestCamera;
	public GameObject enemy;
	private Vector3 spawnPoint;
	public float protestTimer = 10f;
	public GameObject enemySpawner;

	void Start() {
		mainCamera.enabled = true;
		protestCamera.enabled = false;
	}

	public void Update(){
		protestTimer -= Time.deltaTime / 50;

		if (protestTimer <= 0) {
			mainCamera.enabled = true;
			protestCamera.enabled = false;
			enemySpawner.SetActive (true);
		}
	}

	public void beginProtest(){
		mainCamera.enabled = false;
		protestCamera.enabled = true;
		Invoke("spawnEnemies", 8);

		protestTimer -= Time.deltaTime;
		if (protestTimer <= 0) {
			mainCamera.enabled = true;
			protestCamera.enabled = false;
		}
	}

	public void spawnEnemies(){
		spawnPoint.x = Random.Range(-45, -55);
		spawnPoint.y = 1.5f;
		spawnPoint.z = Random.Range(-35, -45);

		Instantiate(enemy, spawnPoint, Quaternion.identity);
		Instantiate(enemy, spawnPoint, Quaternion.identity);
		CancelInvoke();
	}
}
