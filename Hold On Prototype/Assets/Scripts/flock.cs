using UnityEngine;
using System.Collections;

public class flock : MonoBehaviour {
 
    public GameObject Friendly;
    private GameObject Leader;
    public GameObject[] friendlies;
    private Transform target;
    
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
      foreach (GameObject Friendly in friendlies) {
           if (this.Friendly.tag != "Leader") {
               GameObject Leader = (GameObject.FindWithTag("Leader"));
               float speed = 1 * Time.deltaTime;
               target = Leader.transform;
               transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
           }
      }
    }           
}