using UnityEngine;
using System.Collections;

public class HP : MonoBehaviour {

    public int hitpoints = 2;
    public GameObject Friendly;
    public GameObject Enemy;
    
 
       
    void OnCollisionEnter(Collision collision) {
       if ("Enemy" == collision.gameObject.tag) {
           hitpoints--;
       }
    }
    
    void Update() {
        if (hitpoints == 0) {
           this.Friendly.SetActive(false);
        }        
    }
	
}
