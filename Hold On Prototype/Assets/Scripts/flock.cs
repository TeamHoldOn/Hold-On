using UnityEngine;
using System.Collections;

public class flock : MonoBehaviour {

    public float speed = 1f;
    float rotationSpeed = 2.0f;
    Vector3 averageHeading;
    Vector3 averagePosition;
    float neighborDistance = 1.0f;
             
    
	void Start () {
	}
	
	void Update () {
       if(Random.Range(0,5) < 1)
            ApplyRules();
            
	    transform.Translate(0, 0, Time.deltaTime * speed);
	}
    
    void ApplyRules() {
        GameObject[] flock;
        flock = globalFlock.allFriendlies;
        
        Vector3 vcenter = Vector3.zero;
        Vector3 vavoid = Vector3.zero;
        float gSpeed = 0.1f;
        
        Vector3 goalPos = globalFlock.goalPos;
        
        float dist;
        
        int flockSize = 0;
        foreach (GameObject friendly in flock) {
            if (friendly != this.gameObject) {
                dist = Vector3.Distance(friendly.transform.position,this.transform.position);
                
                if(dist <= neighborDistance) {
                    vcenter += friendly.transform.position;
                    flockSize++;
                }
                
                    if(dist < 1.0f) {
                        vavoid = vavoid + (this.transform.position - friendly.transform.position);
                    }
                
                    flock anotherFlock = friendly.GetComponent<flock>();
                    gSpeed = gSpeed + anotherFlock.speed;
            }
        }
    
    
    if (flockSize > 0) {
        vcenter = vcenter/flockSize + (goalPos - this.transform.position);
        speed = gSpeed/flockSize;
        
        Vector3 direction = (vcenter + vavoid) - transform.position;
        if (direction != Vector3.zero) {
            transform.rotation = Quaternion.Lerp(transform.rotation,
                                                  Quaternion.LookRotation(direction),
                                                  rotationSpeed * Time.deltaTime);
        }
    }
  }
}
