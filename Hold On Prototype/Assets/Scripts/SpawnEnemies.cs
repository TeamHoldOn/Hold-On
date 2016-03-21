using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {

	public GameObject[] enemies;
	public int amount;
	private Vector3 spawnPoint;
	
	// Update is called once per frame
	void Update () {
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		amount = enemies.Length;

		if (amount < 5) {
			InvokeRepeating ("spawnEnemy", 5, 10f);

		}
	
	}

	void spawnEnemy(){
		spawnPoint.x = Random.Range(-15, 15);
		spawnPoint.y = 1.5f;
		spawnPoint.z = Random.Range(-5, 15);

		Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Length - 1)], spawnPoint, Quaternion.identity);
		CancelInvoke();
	}
			
}
