using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class mainMusic : MonoBehaviour {

	public AudioClip Music;
	AudioSource audio;
    
    void Start() {
        audio = GetComponent<AudioSource>();
    }

    void Update() {
        if (Time.time == 58) {
            audio.PlayOneShot(Music, 1);
        }  
    }
}