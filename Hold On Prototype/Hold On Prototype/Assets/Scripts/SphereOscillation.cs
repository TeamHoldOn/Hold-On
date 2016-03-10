using UnityEngine;
using System.Collections;

public class SphereOscillation : MonoBehaviour {
	
	void Update () {
		this.transform.position = Vector3.up * Mathf.Cos(Time.time);
	
	}
}
