using UnityEngine;
using System.Collections;

public class FirstEnemySpawn : MonoBehaviour {

	public GameObject firstEnemy;
	private Vector3 spawnPoint;

	void Start () {

		Invoke ("SpawnFirstEnemy", 10f);
	}

	void SpawnFirstEnemy(){
		spawnPoint.x = 15f;
		spawnPoint.y = 1.5f;
		spawnPoint.z = 15f;
		Instantiate (firstEnemy, spawnPoint, Quaternion.identity);
		CancelInvoke ();
	}
}