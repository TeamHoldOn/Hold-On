using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public float speed = 1.1f;
	public float rotationSpeed = 1.1f;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject target = FindClosestFriendly (this.transform.position);

		//make the enemy "look" at the target"
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), rotationSpeed * Time.deltaTime);

		transform.position += (transform.forward * speed * Time.deltaTime);
	
	}

	//this function will find the closest friendly. 
	private GameObject FindClosestFriendly(Vector3 enemyLocation){
		GameObject closestFriendly = null;
		float closestFriendlyDistance = Mathf.Infinity;
		GameObject[] friendlies = GameObject.FindGameObjectsWithTag ("Friendly");

		foreach (GameObject friendly in friendlies) {
			float tempDistance = Vector3.Distance (enemyLocation, friendly.transform.position);

			if (tempDistance < closestFriendlyDistance) {
				closestFriendly = friendly;
				closestFriendlyDistance = tempDistance;
			}
		}

		return closestFriendly;
	}
}
