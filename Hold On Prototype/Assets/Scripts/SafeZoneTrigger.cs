using UnityEngine;
using System.Collections;

public class SafeZoneTrigger : MonoBehaviour {

   public static bool safeOut = true;
   public GameObject player;
    public static bool endGame = false;
   
   void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            safeOut = false;
           Invoke("HaveILeft", 5);
        }
    }

    void OnTriggerExit(Collider other){
            if (other.gameObject.tag == "Player") {
                safeOut = true;
            }
        }

  
    void HaveILeft()
    {
     
            if (!safeOut)
            {
                Debug.Log("Taking Control");

                this.player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ |
                RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

            endGame = true;
       
            }
     }
}