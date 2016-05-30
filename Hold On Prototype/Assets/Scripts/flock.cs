using UnityEngine;
using System.Collections;

public class flock : MonoBehaviour {
 
    GameObject Leader;
    GameObject[] Friendlies;
    GameObject[] Leaders;
    bool optimize;
    
    void Awake() {
        Friendlies = GameObject.FindGameObjectsWithTag("Friendly");
        Leaders = GameObject.FindGameObjectsWithTag("Leader");
        optimize = false;    
    }
    
    void OnCollisionEnter(Collision collision) {
       if (collision.gameObject.tag == "Player") {
           optimize = true;
           if (null != GameObject.FindWithTag("Leader")) {
               GameObject oldLeader = GameObject.FindWithTag("Leader");
               oldLeader.tag = "Friendly";
           }
           
           gameObject.tag = "Leader";           
       }
    }
    
    void Update() {
        Leaders = GameObject.FindGameObjectsWithTag("Leader");
        Leader = GameObject.FindWithTag("Leader");
    }
    
    void FixedUpdate() {
        float minDist = 2f;
        Vector3 selfPosition = transform.position;  
        if (Leaders.Length != 0) {
            foreach (GameObject Friendly in Friendlies) {
                if (Friendly != Leader) {
                    Rigidbody avoid = Friendly.GetComponent<Rigidbody>();
                    
                    if (optimize) {
                        avoid.AddForce(-(Friendly.transform.position), ForceMode.Impulse);
                        optimize = false;  
                    }
                    
                    Vector3 followLeader = Leader.transform.position - Friendly.transform.position;
                    Rigidbody follow = GetComponent<Rigidbody>();
                    follow.AddForce(followLeader.normalized * 0.3f, ForceMode.Impulse); 
                    follow.velocity += followLeader.normalized;
           
                    float speedLimit = follow.velocity.sqrMagnitude;
                    if (speedLimit > 0.8f) {
                        follow.velocity += -(follow.velocity.normalized * 1.2f); 
                    }
      
                    float currentDist = Vector3.Distance (selfPosition, Friendly.transform.position);
                    if (currentDist < minDist) {
                        Vector3 repulse = Friendly.transform.position - selfPosition;
                        avoid.velocity += repulse.normalized * 0.3f;
                    }
                }
            }
        }
    }
}