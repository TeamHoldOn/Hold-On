using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class audioTrigger : MonoBehaviour {

    AudioSource audio;

	void OnTriggerEnter(Collider player) {
	    if (player.gameObject.CompareTag("Player")) {
            GetComponentInChildren<AudioSource>().Play();
        }
	}
}