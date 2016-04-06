using UnityEngine;
using System.Collections;

public class randomAudio : MonoBehaviour {

	public GameObject player;
    private Vector3 offset;
    
    public AudioSource audio1;
    public AudioSource audio2;
    public AudioSource audio3;
	
	void Start () {
		offset = transform.position - player.transform.position;
	
	}
	
    void Update () {
        float randomFloat = Random.Range(1f, 4f);
        if (randomFloat == 1) {
            audio1.Play();
        }
        
         if (randomFloat == 2) {
            audio2.Play();
        }
        
         if (randomFloat == 3) {
            audio3.Play();
        }
    }
    
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	
	}
}
