using UnityEngine;
using System.Collections;

public class flock : MonoBehaviour {
 
    GameObject Leader;
    GameObject[] Friendlies;
    GameObject[] Leaders;
    
    void Awake() {
        Friendlies = GameObject.FindGameObjectsWithTag("Friendly");
        Leaders = GameObject.FindGameObjectsWithTag("Leader");    
    }
    
    void OnCollisionEnter(Collision collision) {
       if (collision.gameObject.tag == "Player") {
           if (null != GameObject.FindWithTag("Leader")) {
               GameObject oldLeader = GameObject.FindWithTag("Leader");
               oldLeader.tag = "Friendly";
           }
           
           gameObject.tag = "Leader";           
       }
    }
    
    void Update() {
        Leaders = GameObject.FindGameObjectsWithTag("Leader");
    }
    
    void FixedUpdate() {
        float minDist = 2f;
<<<<<<< HEAD
        Vector3 selfPosition = transform.position;  
        if (Leaders.Length != 0) {
            foreach (GameObject Friendly in Friendlies) {
                if (Friendly != GameObject.FindWithTag("Leader")) {
                    Leader = (GameObject.FindWithTag("Leader"));
                    Vector3 followLeader = Leader.transform.position - Friendly.transform.position;
                    Rigidbody follow = GetComponent<Rigidbody>();
                    follow.velocity += followLeader.normalized * 0.1f;
           
                    float speedLimit = follow.velocity.sqrMagnitude;
                    if (speedLimit > 3f) {
                        follow.velocity += -(follow.velocity.normalized); 
                    }
      
                    float currentDist = Vector3.Distance (selfPosition, Friendly.transform.position);
                    if (currentDist < minDist) {
                        Vector3 repulse = Friendly.transform.position - selfPosition;
                        Rigidbody avoid = Friendly.GetComponent<Rigidbody>();
                        avoid.velocity += repulse.normalized * 0.3f; 
                    }
                }
=======
                
        foreach (GameObject Friendly in Friendlies) {
            float currentDist = Vector3.Distance (transform.position, Friendly.transform.position);
            if (currentDist < minDist) {
                Vector3 repulse = Friendly.transform.position - transform.position;
                Rigidbody avoid = Friendly.GetComponent<Rigidbody>();
                avoid.velocity += repulse.normalized * 0.3f; 
>>>>>>> refs/remotes/origin/master
            }
        }
    }
}