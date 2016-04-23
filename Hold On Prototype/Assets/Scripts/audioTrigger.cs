using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class audioTrigger : MonoBehaviour {

    public AudioClip sound;
    AudioSource audio;
    public float volume = 1;
    bool boom = false;
    
	void Start() {
	    audio = GetComponent<AudioSource>();
	}
    
    void Update() {
        if (boom == true) {
            Destroy (this.gameObject, 15);
        }
    }
    
	void OnTriggerEnter(Collider player) {
	    if (player.gameObject.CompareTag("Player")) {
            audio.PlayOneShot(sound, volume);
            boom = true;
        }
	}
}