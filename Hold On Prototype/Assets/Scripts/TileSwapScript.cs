using UnityEngine;
using System.Collections;

public class TileSwapScript : MonoBehaviour
{
    bool hexhit = false;
    public GameObject Hex;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hex")
        { hexhit = true; }


    }

    void Update(){
        if (hexhit==true) 
        { 
         Destroy (Hex, 3f);
            Debug.Log("Hit the hex");
        }

    }
}