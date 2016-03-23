using UnityEngine;
using System.Collections;

public class EnemyHP : MonoBehaviour {

	public float hitpoints = 3f;

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			hitpoints--;
		}

		if (collision.gameObject.tag == "Friendly") {
			hitpoints -= 0.5f;
		}
	}
		
	void Update() {
		if (hitpoints == 0) {
			Destroy (this.gameObject);
		}
	}


}