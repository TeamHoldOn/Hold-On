using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    public GameObject sphere;
    public GameObject target;
    public Transform goal;
        

	void Start () {
        sphere.destination = goal.position;
	}
	

	void Update () {
        target.transform.position = sphere.destination;
        sphere.Move(sphere.destination);
        if (sphere.destination == target.transform.position)
        {
            target.Vector3 = new sphere.destination();
        } 
    
	}
}
