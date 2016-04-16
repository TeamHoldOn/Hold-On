using UnityEngine;
using System.Collections;

public class ParticlePlay : MonoBehaviour {
	

	public int checkCurrentHealth;
	public PlayerHealth hp;

	// Use this for initialization
	void Start () {
		ParticleSystem ps = GetComponent<ParticleSystem>();
		ParticleSystem.EmissionModule em = ps.emission;
		em.enabled = false;
	}
		
	// Update is called once per frame
	void Update () {
		checkCurrentHealth = hp.currentHealth;

		if (checkCurrentHealth <= 0) {
			ParticleSystem ps = GetComponent<ParticleSystem> ();
			ParticleSystem.EmissionModule em = ps.emission;
			em.enabled = true;


			}

		else {
			ParticleSystem ps = GetComponent<ParticleSystem> ();
			ParticleSystem.EmissionModule em = ps.emission;
			em.enabled = false;
		}

	}

}