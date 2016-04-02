using UnityEngine;
using System.Collections;

public class EnemyHP : MonoBehaviour {

    public float hitpoints = 3;

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
           this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
           this.gameObject.GetComponent<Rigidbody>().useGravity = true;
           Destroy (GetComponent<EnemyNavigation>());
           this.gameObject.tag = "Dead";
           Destroy (this.gameObject, 3);
        }        
	}


}