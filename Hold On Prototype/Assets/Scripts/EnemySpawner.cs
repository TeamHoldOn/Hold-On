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

		if (amount < 3) {
			InvokeRepeating ("spawnEnemy", 5, 10f);

		}
	}

	void spawnEnemy(){
		spawnPoint.x = Random.Range(-15, 15);
		spawnPoint.y = 1.5f;
		spawnPoint.z = Random.Range(-5, 15);

		Instantiate(enemy, spawnPoint, Quaternion.identity);
		CancelInvoke();
	}

}
