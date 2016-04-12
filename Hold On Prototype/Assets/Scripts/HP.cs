using UnityEngine;
using System.Collections;

public class HP : MonoBehaviour {

    public int hitpoints = 2;
    public GameObject Friendly;
    public GameObject SafeArea;
     
    void OnCollisionEnter(Collision collision) {
       if (collision.gameObject.tag == "Enemy") {
           hitpoints--;
       }
    }
    
    void Update() {
        if (hitpoints == 1) {
           Destroy (GetComponent<flock>());
           Fleeing();
           } 
                
        if (hitpoints == 0) {
           Friendly.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
           Friendly.GetComponent<Rigidbody>().useGravity = true;
           Friendly.tag = "Dead";
           Invoke("Death", 3);
        }
    }
    
    void Fleeing() {
        Vector3 fleeTo = SafeArea.transform.position - transform.position;
        Rigidbody flee = this.Friendly.GetComponent<Rigidbody>();
        flee.velocity += fleeTo.normalized;
        float speedLimit = flee.velocity.sqrMagnitude;
        if (speedLimit > 3f) {
            flee.velocity += -(flee.velocity.normalized); 
           } 
    }
        
    void Death() {
        Friendly.SetActive(false);
    }
}