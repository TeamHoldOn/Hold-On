using UnityEngine;
using System.Collections;

public class protesterFlocking : MonoBehaviour {

    GameObject[] Protesters;

    void Awake() {
        Protesters = GameObject.FindGameObjectsWithTag("Protester");
    }
    
    void FixedUpdate() {
        Vector3 center = Vector3.zero;
        Vector3 avoid = Vector3.zero;
        float dist;
        float flockSize = 0;
        
        foreach (GameObject Protester in Protesters) {
            dist = Vector3.Distance(Protester.transform.position, transform.position);
                
            if (dist <= 10f) {
                center += Protester.transform.position;
                flockSize++;
            }
            
            if (dist < 2f) {
                avoid += (transform.position - Protester.transform.position);
            }
    
            if (flockSize > 0) {
                center = center/flockSize + transform.position;
                Rigidbody rb = Protester.GetComponent<Rigidbody>();
                rb.velocity = (center.normalized + avoid.normalized) * 0.3f;
                
                float speedLimit = rb.velocity.sqrMagnitude;
                if (speedLimit > 0.8f) {
                    rb.velocity += -(rb.velocity.normalized);
                }
            }
        }
    }
}