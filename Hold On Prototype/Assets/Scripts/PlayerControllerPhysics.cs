using UnityEngine;
using System.Collections;

public class PlayerControllerPhysics : MonoBehaviour {

	public Transform orientationReference;

	public float speed;

	private Rigidbody rb;

	void Start(){

		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate(){

		float moveX = Input.GetAxis("Horizontal");
		float moveZ = Input.GetAxis ("Vertical");

		rb.AddForce (moveX * orientationReference.right * speed);
		rb.AddForce (moveZ * orientationReference.forward * speed);

		//		rb.AddForce (inputDirection.normalized * speed);
	}
}
