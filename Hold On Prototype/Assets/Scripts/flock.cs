using UnityEngine;
using System.Collections;

public class flock : MonoBehaviour {
 
    GameObject Leader;
    GameObject Player;
    GameObject[] Friendlies;
    GameObject[] Leaders;
    bool leaderVel;
    Rigidbody leaderRB;
    
    void Awake() {
        Friendlies = GameObject.FindGameObjectsWithTag("Friendly");
        Leaders = GameObject.FindGameObjectsWithTag("Leader");
        Player = GameObject.FindWithTag("Player");
        leaderVel = false;
    }
    
    void OnCollisionEnter(Collision collision) {
       if (collision.gameObject == Player) {
           if (null != GameObject.FindWithTag("Leader")) {
               GameObject oldLeader = GameObject.FindWithTag("Leader");
               oldLeader.tag = "Friendly";
           }
           
           gameObject.tag = "Leader";
           leaderRB = gameObject.GetComponent<Rigidbody>();
           leaderVel = true;           
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
            if (leaderVel) {
                Vector3 leaderVec = Leader.transform.position - Player.transform.position;
                leaderRB.AddForce(leaderVec.normalized, ForceMode.Impulse);
                leaderVel = false;
            }
                        
            foreach (GameObject Friendly in Friendlies) {
                if (Friendly != Leader) {
                    Vector3 followLeader = Leader.transform.position - Player.transform.position;
                    Rigidbody follow = GetComponent<Rigidbody>();
                    follow.velocity += followLeader.normalized / 2;
           
                    float speedLimit = follow.velocity.sqrMagnitude;
                    if (speedLimit > 0.9f) {
                        follow.velocity -= follow.velocity.normalized; 
                    }
      
                    float currentDist = Vector3.Distance (selfPosition, Friendly.transform.position);
                    if (currentDist < minDist) {
                        Vector3 repulse = Friendly.transform.position - selfPosition;
                        Rigidbody avoid = Friendly.GetComponent<Rigidbody>();
                        avoid.velocity += repulse.normalized * 0.3f;
                    }
                }
            }
        }
    }
}