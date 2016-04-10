using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class audioTrigger : MonoBehaviour {

    public AudioClip sound;
    AudioSource audio;
    public float volume = 1;
    
	void Start() {
	    audio = GetComponent<AudioSource>();
	}
    
	void OnTriggerEnter(Collider player) {
	    if (player.gameObject.CompareTag("Player")) {
            audio.PlayOneShot(sound, volume);
        }
	}
}