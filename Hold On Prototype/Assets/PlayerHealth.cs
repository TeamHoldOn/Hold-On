using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public int startHealth = 4;
	public int currentHealth;

	PlayerController playerMovement;
	public GameObject Enemy;

	void Awake ()
	{
		playerMovement = GetComponent<PlayerController> ();
		currentHealth = startHealth;
	}

	void OnCollisionEnter(Collision collision){
		if ("Enemy" == collision.gameObject.tag) {
			currentHealth--;
		}
	}

	void Update(){
		if (currentHealth <= 0) {
			playerMovement.enabled = false;
		}
	}
}