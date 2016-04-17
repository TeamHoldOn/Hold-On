using UnityEngine;
using System.Collections;

public class FriendlyParticlePlay : MonoBehaviour {

	public int checkCurrentHealth;
	public HP hp;

	// Use this for initialization
	void Start () {
		ParticleSystem ps = GetComponent<ParticleSystem>();
		ParticleSystem.EmissionModule em = ps.emission;
		em.enabled = false;

	}



	// Update is called once per frame
	void Update () {
		checkCurrentHealth = hp.hitpoints;

		if (checkCurrentHealth < 2) {
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