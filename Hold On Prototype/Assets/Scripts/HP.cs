using UnityEngine;
using System.Collections;

public class HP : MonoBehaviour {

    public int hitpoints = 3;
    public GameObject Friendly;
         
    void OnCollisionEnter(Collision collision) {
       if (collision.gameObject.tag == "Enemy") {
           hitpoints--;
       }
    }
    
    void Update() {
        if (hitpoints == 0) {
           this.Friendly.SetActive(false);
        }        
    }
	
}
