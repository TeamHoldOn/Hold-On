/*using UnityEngine;
using System.Collections;

public class cinematic : MonoBehaviour {

    public GameObject firstProtester;

	void Awake () {
        
        GameObject[] firstProtesters = GameObject.FindGameObjectsWithTag("firstProtester");
        Rigidbody fpRB = firstProtester.GetComponent<Rigidbody>();
	}
	
	void Update () {
        if (firstProtesters.Length <= 4) {
            foreach (GameObject firstProtester in firstProtesters) {
                transform.positition =  
                
                if (Friendly != Leader) {
                    Vector3 followLeader = Leader.transform.position - Friendly.transform.position;
                    Rigidbody follow = GetComponent<Rigidbody>();
                    follow.velocity += followLeader.normalized * 0.1f;
           
                    float speedLimit = follow.velocity.sqrMagnitude;
                    if (speedLimit > 1f) {
                        follow.velocity += -(follow.velocity.normalized); 
                    }
            }
        }
	}
}

