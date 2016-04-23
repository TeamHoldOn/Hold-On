using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class sfx : MonoBehaviour {

    public AudioClip bump;
    AudioSource audio;
    
	void Start() {
	    audio = GetComponent<AudioSource>();
	}
	
	void OnCollisionEnter() {
	    audio.PlayOneShot(bump, 3f);
	}
}
