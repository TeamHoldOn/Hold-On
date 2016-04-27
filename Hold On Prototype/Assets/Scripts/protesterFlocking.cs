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
                float eWallDist = Vector3.Distance(Protester.transform.position, EastWall.transform.position);
                Vector3 eWallPush = (EastWall.transform.position - Protester.transform.position);
                rb.velocity = -(eWallPush.normalized);
                
                if (speedLimit > 0.9f) {
                        rb.velocity += -(rb.velocity.normalized);
                }
            }
            
            if (sWall) {
                float sWallDist = Vector3.Distance(Protester.transform.position, SouthWall.transform.position);
                Vector3 sWallPush = (SouthWall.transform.position - Protester.transform.position);
                rb.velocity = -(sWallPush.normalized);
                
                if (speedLimit > 0.9f) {
                        rb.velocity += -(rb.velocity.normalized);
                }
            }
            
            if (wWall) {
                float wWallDist = Vector3.Distance(Protester.transform.position, WestWall.transform.position);
                Vector3 wWallPush = (WestWall.transform.position - Protester.transform.position);
                rb.velocity = -(wWallPush.normalized);
                
                if (speedLimit > 0.9f) {
                        rb.velocity += -(rb.velocity.normalized);
                }
            }
        }
    }
}