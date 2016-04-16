using UnityEngine;
using System.Collections;

public class FirstEnemyController : MonoBehaviour {

	public Camera firstCamera = Camera.main;
	public Camera protestCamera;
	public float hitpoints = 2;

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
			this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
			this.gameObject.GetComponent<Rigidbody>().useGravity = true;
			Destroy (GetComponent<EnemyNavigation>());
			this.gameObject.tag = "Dead";
			destroyTimer = 3f;
		}        

		if (hitpoints <= 0) {
			destroyTimer = destroyTimer - Time.deltaTime;
			if (destroyTimer < 0) {
				Destroy (this.gameObject);

				//Call the function in the ProtestScene script
				GameObject protestSceneManager = GameObject.Find("ProtestSceneManager");
				ProtestScene ps = protestSceneManager.GetComponent<ProtestScene>();
				ps.Update ();
				ps.beginProtest();
			}
		}
	}
}
