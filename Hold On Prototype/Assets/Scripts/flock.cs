using UnityEngine;
using System.Collections;

public class flock : MonoBehaviour {
 
    private GameObject Leader;
    
    void OnCollisionEnter(Collision collision) {
       if (collision.gameObject.tag == "Player") {
           if (null != GameObject.FindWithTag("Leader")) {
               GameObject oldLeader = GameObject.FindWithTag("Leader");
               oldLeader.tag = "Friendly";
           }
           
           gameObject.tag = "Leader";
           
       }
    }
    
    void Update () {
      foreach (GameObject Friendly in GameObject.FindGameObjectsWithTag("Friendly")) {
           if (Friendly.tag != "Leader") {
               Leader = (GameObject.FindWithTag("Leader"));
               transform.position = Vector3.MoveTowards(transform.position, Leader.transform.position, Time.deltaTime);
           }
      }
    }           
}