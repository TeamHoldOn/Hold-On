using UnityEngine;
using System.Collections;

public class EnemySphereRotator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (45, 45, 0) * Time.deltaTime);

	
	}
}
