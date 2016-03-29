using UnityEngine;
using System.Collections;

public class TileSwapScript : MonoBehaviour
{
    bool hexHit = false;
    public GameObject hexagon2;
    GameObject hexagon;

    void OnTriggerEnter(Collision trigger) {
        if (trigger.gameObject.tag == "Dead") {
            hexHit = true;
            Debug.Log("Hit the hex"); 
        }
    }
    void Update() {
        if (hexHit == true) {
            hexagon = this.gameObject.transform.FindChild("Hexagon").gameObject;
            Destroy (hexagon);
            
            GameObject.Instantiate(hexagon2, new Vector3(0, 0, 0), Quaternion.identity);
            hexagon2.transform.SetParent(this.transform, worldPositionStays: true);
        }
    }

}