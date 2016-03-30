using UnityEngine;
using System.Collections;

public class flock : MonoBehaviour {
 
    private GameObject Leader;
    private GameObject[] Friendlies;
    
    void Awake() {
        Friendlies = GameObject.FindGameObjectsWithTag ("Friendly");
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
    
    void FixedUpdate() {
        Flocking();
        MinimumDistance();
        
    }
    
    void Flocking () {
      foreach (GameObject Friendly in Friendlies) {
        if (Friendly != GameObject.FindWithTag("Leader"))   
           Leader = (GameObject.FindWithTag("Leader"));
           Vector3 followLeader = Leader.transform.position - Friendly.transform.position;
           Rigidbody follow = GetComponent<Rigidbody>();
           follow.velocity += followLeader.normalized * 0.1f;
           
           float speedLimit = follow.velocity.sqrMagnitude;
           if (speedLimit > 10f) {
               follow.velocity += -(follow.velocity.normalized); 
           }
      }
    }
    
    void MinimumDistance() {
        float minDist = 2f;
        Vector3 selfPosition = transform.position;
        
        
        foreach (GameObject Friendly in Friendlies) {
            float currentDist = Vector3.Distance (selfPosition, Friendly.transform.position);
            if (currentDist < minDist) {
                Vector3 repulse = Friendly.transform.position - selfPosition;
                Rigidbody avoid = Friendly.GetComponent<Rigidbody>();
                avoid.velocity += repulse.normalized * 0.3f; 
            }
        }
    }           
}