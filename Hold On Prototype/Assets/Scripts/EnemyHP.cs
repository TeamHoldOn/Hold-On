using UnityEngine;
using System.Collections;

public class EnemyHP : MonoBehaviour {

	public int hitpoints = 3;
	//public GameObject Enemy;

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			hitpoints--;
		}
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Friendly")
			hitpoints -= 0.5f;
	}

	void Update() {
		if (hitpoints == 0) {
			Destroy (this.gameObject);
		}
	}


}