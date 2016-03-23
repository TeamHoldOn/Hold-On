using UnityEngine;
using System.Collections;

public class Expel : MonoBehaviour {

	public float forceAmount;
	public GameObject player;
	public Rigidbody rb;

	void Awake ()

	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}
		
	void Update()
	{
		bool down = Input.GetKeyDown (KeyCode.Space);

		if (down) {
			forceAmount = 2;
		} else {
			forceAmount = 0;
		}	

		float distance = (rb.transform.position - player.transform.position).magnitude;
	
		if (distance <= 4) {
			Vector3 direction = (rb.transform.position - player.transform.position).normalized;
			rb.AddForce(direction * forceAmount);
		}
			
	}


		

}