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
           //transform.position = Vector3.MoveTowards(transform.position, SafeArea.transform.position, Time.deltaTime);
           
           //Flee();
            
           } 
                
        if (hitpoints == 0) {
           Friendly.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
           Friendly.GetComponent<Rigidbody>().useGravity = true;
           Friendly.tag = "Dead";
           Invoke("Death", 3);
        }
    }
        
    //void Flee() {}
        
    void Death() {
        Friendly.SetActive(false);
    }
}