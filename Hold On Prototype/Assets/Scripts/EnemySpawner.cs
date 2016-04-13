using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public Transform enemy;
	public int amount;
	private Vector3 spawnPoint;
	public GameObject[] totalEnemies;

	// Update is called once per frame
	void Update () {
		totalEnemies = GameObject.FindGameObjectsWithTag ("Enemy");
		amount = totalEnemies.Length;

		if (amount < 4) {
			InvokeRepeating ("spawnEnemy", 5, 12f);
		}
	}

	void spawnEnemy(){
		spawnPoint.x = Random.Range(-20, 20);
		spawnPoint.y = 1.5f;
		spawnPoint.z = Random.Range(-10, 20);

		Instantiate(enemy, spawnPoint, Quaternion.identity);
		CancelInvoke();
	}
}
