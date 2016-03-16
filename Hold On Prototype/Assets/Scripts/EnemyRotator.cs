using UnityEngine;
using System.Collections;

public class EnemyRotator : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 90, 0) * Time.deltaTime);
	
	}
}
