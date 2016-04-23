using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class mainMusic : MonoBehaviour {

	public AudioClip Music;
	AudioSource audio;
    float startOnce = 0;
    public static bool startMusic = false;    
    
    void Start() {
        audio = GetComponent<AudioSource>();
    }

    void Update() {
        if (startMusic == true && startOnce == 0) {
            audio.PlayOneShot(Music, 1);
            startOnce++;
        }
    }
}