using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class PlayMovie : MonoBehaviour
{

    public MovieTexture opening;
    public AudioSource openingAudio;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }
    // Use this for initialization
    void Start()
    {
        GetComponent<RawImage>().texture = opening as MovieTexture;
        openingAudio = GetComponent<AudioSource>();
        openingAudio.clip = opening.audioClip;
        opening.Play();
        openingAudio.Play();
    }
}