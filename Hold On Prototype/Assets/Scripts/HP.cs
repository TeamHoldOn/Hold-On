using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class HP : MonoBehaviour {

    public int hitpoints = 2;
    public GameObject Friendly;
    public GameObject SafeArea;
    public AudioClip death;
    AudioSource audio;
     
    void Start() {
	    audio = GetComponent<AudioSource>();
	}
    
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
                
        if (hitpoints <= 0) {
           Friendly.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
           Friendly.GetComponent<Rigidbody>().useGravity = true;
           Friendly.tag = "Dead";
           Invoke("Death", 3);
           audio.PlayOneShot(death, 1.5f);
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