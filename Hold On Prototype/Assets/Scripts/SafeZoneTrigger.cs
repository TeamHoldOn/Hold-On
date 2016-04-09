using UnityEngine;
using System.Collections;

public class SafeZoneTrigger : MonoBehaviour {

   public static bool safeOut = true;
   public GameObject player;
   
   void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            safeOut = false;
           Invoke("HaveILeft", 10);
        }
    }

    void OnTriggerExit(Collider other){
            if (other.gameObject.tag == "Player") {
                safeOut = true;
            }
        }

    // Update is called once per frame
    void HaveILeft()
    {
     
            if (!safeOut)
            {
                Debug.Log("Taking Control");

                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ |
                RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
              
            }
     }
}