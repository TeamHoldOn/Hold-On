using UnityEngine;
using System.Collections;

public class HP : MonoBehaviour {

    public int hitpoints = 2;
    public GameObject Friendly;
    public GameObject Enemy;
         
    void OnCollisionEnter(Collision collision) {
       if (collision.gameObject.tag == "Enemy") {
           hitpoints--;
       }
    }
    
    void Update() {
        if (hitpoints == 1) {
           Destroy (GetComponent<flock>());
           Flee();
            
           } 
                
        if (hitpoints == 0) {
           Friendly.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
           Friendly.GetComponent<Rigidbody>().useGravity = true;
           Friendly.tag = "Dead";
           Invoke("Death", 3);
        }
    }
        
    void Flee() {
        float minDist = 2f;
        Vector3 selfPosition = transform.position;
        float currentDist = Vector3.Distance (selfPosition, Enemy.transform.position);
            if (currentDist < minDist) {
                Vector3 repulse = Friendly.transform.position - selfPosition;
                Rigidbody avoid = Friendly.GetComponent<Rigidbody>();
                avoid.velocity += repulse.normalized * 0.3f; 
            }
        }
        
    void Death() {
        Friendly.SetActive(false);
    }
}