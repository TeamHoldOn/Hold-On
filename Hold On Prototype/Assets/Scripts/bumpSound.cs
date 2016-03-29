using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class bumpSound : MonoBehaviour {

    public AudioClip bump;
    AudioSource audio;

	void Start () {
        audio = GetComponent<AudioSource>();
    }
    
    void OnCollisionEnter (Collision collision) {
	    audio.PlayOneShot(bump, 1f);
	}
}
