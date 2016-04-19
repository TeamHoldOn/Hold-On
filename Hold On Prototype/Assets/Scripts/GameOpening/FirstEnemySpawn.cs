using UnityEngine;
using System.Collections;

public class FirstEnemySpawn : MonoBehaviour {

	public GameObject firstEnemy;
	public GameObject protesterSpawning;
	private Vector3 spawnPoint;

	void Start () {

		Invoke ("spawnFirstEnemy", 70f);
	}

	void spawnFirstEnemy(){
		spawnPoint.x = 15f;
		spawnPoint.y = 1.5f;
		spawnPoint.z = 15f;
		Instantiate (firstEnemy, spawnPoint, Quaternion.identity);
		CancelInvoke ();
	}


}