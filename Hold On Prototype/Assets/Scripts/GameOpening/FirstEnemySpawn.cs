using UnityEngine;
using System.Collections;

public class FirstEnemySpawn : MonoBehaviour {

	public GameObject firstEnemy;
	public GameObject protesterSpawning;
	private Vector3 spawnPoint;
	AudioSource music;


	void Start () {

		music = GetComponent<AudioSource> ();

		Invoke ("spawnFirstEnemy", 65f);
	}

	void spawnFirstEnemy(){
		music.Play ();
		spawnPoint.x = 5f;
		spawnPoint.y = 1.5f;
		spawnPoint.z = 0f;
		Instantiate (firstEnemy, spawnPoint, Quaternion.identity);
		CancelInvoke ();
	}
}