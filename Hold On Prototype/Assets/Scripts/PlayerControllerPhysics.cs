using UnityEngine;
using System.Collections;

public class PlayerControllerPhysics : MonoBehaviour {

	public float speed;

	private Rigidbody rb;

	void Start(){

		rb = GetComponent<Rigidbody>();

	}

	void FixedUpdate(){

		Vector3 inputDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0.0f, Input.GetAxis ("Vertical"));

		//keeps the ball from accelerating too much
		if (inputDirection.sqrMagnitude > 1) {
			inputDirection = inputDirection.normalized;
		}

		rb.AddForce (inputDirection * speed);
	}

}
