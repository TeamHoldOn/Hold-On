using UnityEngine;
using System.Collections;

public class protesterFlocking : MonoBehaviour {

    GameObject[] Protesters;
    public GameObject Protester;
    public GameObject EastWall;
    public GameObject SouthWall;
    public GameObject WestWall;
    public Rigidbody rb;
    bool eWall;
    bool sWall;
    bool wWall; 

    void Awake() {
        Protesters = GameObject.FindGameObjectsWithTag("Protester");
        bool eWall = false;
        bool sWall = false;
        bool wWall = false;
    }
    
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject == EastWall) {
            eWall = true;
            sWall = false;
            wWall = false;
        }
        
        if (collision.gameObject == SouthWall) {
            sWall = true;
            eWall = false;
            wWall = false;
        }
        
        if (collision.gameObject == WestWall) {
            wWall = true;
            eWall = false;
            sWall = false;
        }
    }
    
    void FixedUpdate() {
        Vector3 center = Vector3.zero;
        Vector3 avoid = Vector3.zero;
        float dist;
        float flockSize = 0;
        float speedLimit = rb.velocity.sqrMagnitude;
        
        foreach (GameObject Protester in Protesters) {
            if (!eWall && !sWall && !wWall) {
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
                    rb.velocity = (center.normalized + avoid.normalized);
                
                    if (speedLimit > 0.9f) {
                        rb.velocity += -(rb.velocity.normalized);
                    }
                }
            }
            
            if (eWall) {
                sWall = false;
                wWall = false;
               
                Vector3 eWallPush = -(transform.position);
                rb.velocity = eWallPush.normalized;
                
                if (speedLimit > 0.9f) {
                        rb.velocity -= rb.velocity.normalized;
                }
            }
            
            if (sWall) {
                eWall = false;
                wWall = false;
                
                Vector3 sWallPush = -(transform.position);
                rb.velocity = sWallPush.normalized;
                
                if (speedLimit > 0.9f) {
                        rb.velocity -= rb.velocity.normalized;
                }
            }
            
            if (wWall) {
                sWall = false;
                eWall = false;
                
                Vector3 wWallPush = -(transform.position);
                rb.velocity = wWallPush.normalized;
                
                if (speedLimit > 0.9f) {
                        rb.velocity -= rb.velocity.normalized;
                }            
            }
        }
    }
}