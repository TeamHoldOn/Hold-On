using UnityEngine;
using System.Collections;

public class TileSwapScript : MonoBehaviour
{
    bool hexHit = false;
    public GameObject hexagon2;

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Friendly") {
            hexHit = true; 
        }
    }
    void Update() {
        if (hexHit == true) { 
            Destroy (transform.child="hexagon");
            Debug.Log("Hit the hex");
            Instantiate(hexagon2, new Vector3(0, 0, 0), Quaternion.identity);
            
            hexagon2.transform.SetParent(this.transform, worldPositionStays: true);
        }
    }

}