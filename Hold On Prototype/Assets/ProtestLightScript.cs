using UnityEngine;
using System.Collections;

public class ProtestLightScript : MonoBehaviour {

	private Light protestLight; 
	float intensityRandomizer;
	float timer = 0;

	// Use this for initialization
	void Start () {

		protestLight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
				
		intensityRandomizer = Random.Range (0.5f, 3.5f);
		protestLight.intensity = intensityRandomizer;


	}
//
//	void changeIntensity(){
//		intensityRandomizer = Random.Range (0.5f, 8.5);
//	
//	}

}
