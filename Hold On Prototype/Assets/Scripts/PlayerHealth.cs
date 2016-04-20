using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public int startHealth = 10;
	public int currentHealth;

	PlayerControllerPhysics playerMovement;
	public GameObject Enemy;

	void Awake ()
	{
		playerMovement = GetComponent<PlayerControllerPhysics> ();
		currentHealth = startHealth;
	}

	void OnCollisionEnter(Collision collision){
		if ("Enemy" == collision.gameObject.tag) {
			currentHealth--;
		}
	}

    
	void Update(){
	// if player is dead frezzes player and sets end condition true triggering end scene.
    	if (currentHealth <= 0) {
			playerMovement.enabled = false;
            GameStateManager.died = true;
        }
	}
}