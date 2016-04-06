using UnityEngine;
using System.Collections;

public class HP : MonoBehaviour {

    public int hitpoints = 2;
    public GameObject Friendly;
         
    void OnCollisionEnter(Collision collision) {
       if (collision.gameObject.tag == "Enemy") {
           hitpoints--;
       }
    }
    
    void Death() {
        Friendly.SetActive(false);
    }
    
    void Update() {
        if (hitpoints == 0) {
           Friendly.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
           Friendly.GetComponent<Rigidbody>().useGravity = true;
           Destroy (GetComponent<flock>());
           Friendly.tag = "Dead";
           Invoke("Death", 3);
        }        
    }
	
}
