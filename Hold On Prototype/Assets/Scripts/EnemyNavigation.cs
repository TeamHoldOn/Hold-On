using UnityEngine;
using System.Collections;

public class EnemyNavigation : MonoBehaviour {

	//public float targetScanTime = 5.0f;
	public float speed = 1.5f;
	public float rotationSpeed = 1.0f;
	public float timer = 0f;
	public float targetScanTime = 2.0f;
	GameObject target;

	// Use this for initialization
	void Start () {
		target = FindClosestFriendly (this.transform.position);
		timer = targetScanTime;
	}

	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;

		if(timer < 0){
			target = FindClosestFriendly (this.transform.position);
			timer = 2;
		}


		float move = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target.transform.position, move);
		
	    //make the enemy "look" at the target"
		//transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target().transform.position - transform.position), rotationSpeed * Time.deltaTime);

		//transform.position += (transform.forward * speed * Time.deltaTime);

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

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			Vector3 bounceDirection = transform.position - collision.gameObject.transform.position;
			Rigidbody enemyBody = this.GetComponent<Rigidbody> ();
			enemyBody.velocity += bounceDirection;
		}

		if (collision.gameObject.tag == "Friendly") {
			Vector3 bounceDirection = (transform.position - collision.gameObject.transform.position) * .75f;
			Rigidbody enemyBody = this.GetComponent<Rigidbody> ();
			enemyBody.velocity += bounceDirection;
		}
	}

}