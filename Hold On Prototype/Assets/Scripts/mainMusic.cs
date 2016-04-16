using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class mainMusic : MonoBehaviour {

	public AudioClip Music;
	AudioSource audio;
    public GameObject trigger;
    
    void Awake() {
	    audio = GetComponent<AudioSource>();
	}
    
    void OnTriggerExit(Collider player) {
        if (player.gameObject.CompareTag("Player")) {
            audio.PlayOneShot(Music, 1);
        }
    }
}