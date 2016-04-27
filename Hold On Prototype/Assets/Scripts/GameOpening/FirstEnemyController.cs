using UnityEngine;
using System.Collections;

public class FirstEnemyController : MonoBehaviour {

	public Camera firstCamera = Camera.main;
	public Camera protestCamera;
	public float hitpoints = 3;

	float destroyTimer = -1;

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			hitpoints--;
		}

		if (collision.gameObject.tag == "Friendly") {
			hitpoints -= 0.5f;
		}
	}

	void Update() {
		if (hitpoints == 0 && this.gameObject.tag != "Dead") {
			Destroy (GetComponent<EnemyNavigation>());
			this.gameObject.GetComponent<Rigidbody>().useGravity = true;

			this.gameObject.tag = "Dead";
			destroyTimer = 3f;
		}        

		if (hitpoints <= 0) {
			destroyTimer = destroyTimer - Time.deltaTime;
			if (destroyTimer < 0) {
				this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

				Destroy (this.gameObject);
			}
		}
	}
}
