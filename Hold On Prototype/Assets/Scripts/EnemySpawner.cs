using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public Transform enemy;
	public int amount;
	private Vector3 spawnPoint;
	public GameObject[] totalEnemies;

	void Update () {
		totalEnemies = GameObject.FindGameObjectsWithTag ("Enemy");
		amount = totalEnemies.Length;

		if (amount < 8) {
			InvokeRepeating ("spawnEnemy", 5, 15f);
		}
	}

	void spawnEnemy(){
		spawnPoint.x = Random.Range(-40, 40);
		spawnPoint.y = 1.5f;
		spawnPoint.z = Random.Range(0, 15);

		Instantiate(enemy, spawnPoint, Quaternion.identity);

		spawnPoint.x = Random.Range (-40, 40);
		spawnPoint.y = 1.5f;
		spawnPoint.z = Random.Range(-30, -55);

		Instantiate(enemy, spawnPoint, Quaternion.identity);
		
		CancelInvoke();
	}
}
