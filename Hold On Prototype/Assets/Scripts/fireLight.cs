using UnityEngine;
using System.Collections;

public class fireLight : MonoBehaviour {
    
    Light light;
    public float duration;
    public Color color1;
    public Color color2;
    
	void Start () {
	    light = GetComponent<Light>();
	}
	
	void Update () {
	    float x = Mathf.PingPong(Time.time, duration) / duration;
        light.color = Color.Lerp(color1, color2, x);
	}
}
