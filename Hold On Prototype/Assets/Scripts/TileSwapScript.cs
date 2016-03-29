using UnityEngine;
using System.Collections;

public class TileSwapScript : MonoBehaviour
{
    bool hexHit = false;
    public GameObject hexagon2;
    GameObject hexagon;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Dead") {
            hexHit = true;
            Debug.Log("Hit the hex"); 
        }
    }
    void Update() {
        if (hexHit == true) {
            hexagon = this.gameObject.transform.FindChild("Hexagon").gameObject;
            Destroy (hexagon);

            GameObject hex_obj2 = (GameObject)Instantiate(hexagon2, new Vector3(0, 0, 0), Quaternion.EulerAngles(4.712f, 0, 0));
            hex_obj2.transform.SetParent(this.transform, worldPositionStays: false);
           
        }
    }

}