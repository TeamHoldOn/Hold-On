using UnityEngine;
using System.Collections;

public class FriendlyColorChange : MonoBehaviour {
	public Color colorOne = new Color();
	public Color colorTwo = new Color();
	public Color colorThree = new Color();
	public Color colorFour = new Color();
	public Renderer rend;
	HP hp;


	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
	}

	void Awake (){
		hp = GetComponent<HP> ();
	}


	void Update() {
		if (hp.hitpoints >= 3) {
			rend.material.color = colorOne;
		}
		else if(hp.hitpoints >= 2 && hp.hitpoints <3) {
			rend.material.color = colorTwo;
		}
		else if(hp.hitpoints >= 1 && hp.hitpoints <2) {
			rend.material.color = colorThree;
		}
		else {
			rend.material.color = colorFour;
		}
	}
}