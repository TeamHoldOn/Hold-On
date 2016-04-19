using UnityEngine;
using System.Collections;

public class chant : MonoBehaviour {

	public AudioClip boom;
    AudioSource audio;
    public float volume = 1;
    public static bool startChant = false;
    float stopYelling = 0;
    
	void Start() {
	    audio = GetComponent<AudioSource>();
	}
    
    void Update() {
        if (startChant == true && stopYelling == 0) {
            audio.PlayOneShot(boom, volume);
            stopYelling++;
        }
    
    
    }
}