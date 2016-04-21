using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform lookAt;
	public Transform camTransform;

//	private Camera cam;

	private float distance = 10.0f;
	private float currentX = 0f;

	private void Start(){
		camTransform = transform;
//		cam = Camera.main;
	}

	private void Update(){
		currentX -= Input.GetAxis ("RightJoystickX");
	}

	private void LateUpdate(){
		Vector3 dir = new Vector3 (0, 12f, -distance);
		Quaternion rotation = Quaternion.Euler (lookAt.transform.position.y, currentX, 0);
		camTransform.position = lookAt.position + rotation * dir;
		camTransform.LookAt (lookAt.position);
	}
}
