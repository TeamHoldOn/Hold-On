using UnityEngine;
using System.Collections;

public class Expel : MonoBehaviour {

	public GameObject player;
	public Rigidbody rb;
	public float distance;
	public float forceAmount = 0;

	void Awake ()

	{
		player = GameObject.FindWithTag("Player");
		rb = GetComponent<Rigidbody> ();
	}

	void Update()
	{
		distance = (rb.transform.position - player.transform.position).magnitude;
		Vector3 direction = (rb.transform.position - player.transform.position).normalized;

		if (Input.GetButtonDown("Jump"))
			forceAmount = 10;    
		else if (Input.GetButton("Jump"))
			forceAmount = 10;  
		else if (Input.GetButtonUp("Jump"))
			forceAmount = 0;   

		if (distance <= 4){
            rb.AddForce((direction * forceAmount));
		}

	}
  
}