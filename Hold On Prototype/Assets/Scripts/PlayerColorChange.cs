using UnityEngine;
using System.Collections;

public class PlayerColorChange : MonoBehaviour {
	public Color colorOne = new Color(73,129,178,255);
	public Color colorTwo = new Color(48,104,153,255);
	public Color colorThree = new Color(38,83,122,255);
	public Color colorFour = new Color(23,42,59,255);
	public Renderer rend;
	PlayerHealth hp;


	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
	}

	void Awake (){
		hp = GetComponent<PlayerHealth> ();
	}


	void Update() {
		if (hp.currentHealth > hp.startHealth*0.5 && hp.currentHealth <= hp.startHealth) {
			rend.material.color = colorOne;
		}
		else if(hp.currentHealth > hp.startHealth*0.25 && hp.currentHealth <= hp.startHealth*0.5) {
			rend.material.color = colorTwo;
		}
		else if(hp.currentHealth > 0 && hp.currentHealth <= hp.startHealth*0.25) {
			rend.material.color = colorThree;
		}
		else {
			rend.material.color = colorFour;
		}
	}
}
