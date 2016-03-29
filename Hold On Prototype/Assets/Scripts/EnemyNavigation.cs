using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyNavigation : MonoBehaviour {

	public float rotationSpeed = 1.0f;
	public float speed = 1.25f;
	public float timer = 0f;
	public float targetScanTime = 3.0f;
	public GameObject target;


	// Use this for initialization
	void Start () {
		target = FindClosestFriendly (this.transform.position);
		timer = targetScanTime;
	}

	// Update is called once per frame
	void FixedUpdate () {

		timer -= Time.fixedDeltaTime;

		if(timer < 0){
			target = FindClosestFriendly (this.transform.position);
			timer = 3;
		}

		Rigidbody enemyBody = this.GetComponent<Rigidbody> ();

//		transform.position = Vector3.MoveTowards (transform.position, target.transform.position, move);
		
	    //make the enemy "look" at the target"
//		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), rotationSpeed * Time.deltaTime);

		Vector3 targetDirection =  target.transform.position - transform.position;

		enemyBody.velocity += targetDirection.normalized * speed * Time.fixedDeltaTime;

		enemyCollisionAversion ();

	}

	//this function will find the closest friendly. 
	private GameObject FindClosestFriendly(Vector3 enemyLocation){
		GameObject closestFriendly = null;
		float closestFriendlyDistance = Mathf.Infinity;
		GameObject[] friendlies = GameObject.FindGameObjectsWithTag ("Friendly"); //& GameObject.FindGameObjectsWithTag("Leader");

		foreach (GameObject friendly in friendlies) {
			float tempDistance = Vector3.Distance (enemyLocation, friendly.transform.position);

			if (tempDistance < closestFriendlyDistance) {
				closestFriendly = friendly;
				closestFriendlyDistance = tempDistance;
			}
		}

		return closestFriendly;
	}

	void OnCollisionEnter(Collision collision) {

		float bounceSpeed;

		if (collision.gameObject.tag == "Player") {
			Vector3 bounceDirection = transform.position - collision.gameObject.transform.position;
			Rigidbody enemyBody = this.GetComponent<Rigidbody> ();
			bounceSpeed = 2f;
			enemyBody.velocity += (bounceDirection * bounceSpeed);
		}

		if (collision.gameObject.tag == "Friendly" || collision.gameObject.tag == "Leader") {
			Vector3 bounceDirection = (transform.position - collision.gameObject.transform.position);
			Rigidbody enemyBody = this.GetComponent<Rigidbody> ();
			bounceSpeed = 1.5f;
			enemyBody.velocity += (bounceDirection * bounceSpeed);
		}
	}

	void enemyCollisionAversion(){

		float minDistance = 1.5f;
		float collisionAvoidanceForce = 0.75f;
		Vector3 selfPosition = transform.position; 
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");

		foreach (GameObject enemy in enemies) {

			float tempDist = Vector3.Distance (selfPosition, enemy.transform.position);

			if (tempDist < minDistance){
				Vector3 repulseDirection = enemy.transform.position - selfPosition;
				Rigidbody collisionRisk = enemy.GetComponent<Rigidbody>();
				collisionRisk.velocity += repulseDirection.normalized * collisionAvoidanceForce;
			}
		}
	}
		

}