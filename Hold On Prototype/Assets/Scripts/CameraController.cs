using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform lookAt;
	public Transform camTransform;

	public float distance = 8f;
	public float currentX = 0f;

	public void Start(){
		camTransform = transform;
	}

	public void Update(){
		currentX -= Input.GetAxis ("RightJoystickX");
	}

	public void LateUpdate(){
		Vector3 dir = new Vector3 (0, 8.5f, -distance);
		Quaternion rotation = Quaternion.Euler (lookAt.transform.position.y, currentX, 0);
		camTransform.position = lookAt.position + rotation * dir;
		camTransform.LookAt (lookAt.position);
	}
}
