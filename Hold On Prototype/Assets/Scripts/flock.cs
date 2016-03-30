using UnityEngine;
using System.Collections;

public class flock : MonoBehaviour {
 
    private GameObject Leader;
    public GameObject Friendly;
    private GameObject[] Friendlies;
    public float speed = 3.0f;
    public float minDistance = 1.0f;
    
    
    void Start() {
        Friendlies = GameObject.FindGameObjectsWithTag("Friendly");
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
        foreach (GameObject Friendly in Friendlies) {
           if (Friendly.tag != "Leader") {
               Leader = (GameObject.FindWithTag("Leader"));
               transform.position = Vector3.MoveTowards(transform.position, Leader.transform.position, (Time.deltaTime)/speed);
           }    
        }       
    }          
    
    void LastUpdate() { 
               Vector3 currentPos = Friendly.transform.position;
               float currentDist = Vector3.Distance (currentPos, Friendly.transform.position);
			   if (currentDist < minDistance) {
			        Vector3 repulseDirection = Friendly.transform.position - currentPos;
				    Rigidbody collisionRisk = Friendly.GetComponent<Rigidbody>();
				    collisionRisk.velocity += repulseDirection.normalized * 0.5f;
               }
    }
}