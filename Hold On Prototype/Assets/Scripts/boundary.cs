using UnityEngine;
using System.Collections;

public class boundary : MonoBehaviour {
    
    public Renderer rend;
    
    void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }
    
	void OnBecameInvisible () {
	    rend.enabled = false;
	}
	
	void OnBecameVisisble () {
	    rend.enabled = true;
	}
}
