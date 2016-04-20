using UnityEngine;
using System.Collections;

public class SafeZoneTrigger : MonoBehaviour
{

    public static bool safeOut = true;
    public GameObject player;
    GameObject theFled;

    // how safe zone trigger responds to collisions
    void OnTriggerEnter(Collider other)
    {
        // sets in motion check to see if player is still in the trigger 5 seconds later if they left nothing happens if they are still in the trigger one of three possible end states is set
        if (other.gameObject.tag == "Player")
        {
            safeOut = false;
            Invoke("HaveILeft", 5);
        }
       
        // sets friendlies and protestors to fled so that enemies will stop pursuing them
        if (other.gameObject.tag == "Friendly" | other.gameObject.tag == "Protester")
        {
            other.gameObject.tag = "Fled";
        }
    }
    //sets effects of exiting safezone 
    void OnTriggerExit(Collider other)
    {
        // if player has left zone before 5 seconds is up player won't be frozen
        if (other.gameObject.tag == "Player")
        {
            safeOut = true;
        }
        //once npcs are set fled they will be set inactive after 5 seconds
        if (other.gameObject.tag == "Fled")
        {
            theFled = other.gameObject;
            Invoke("LeftTheField", 5);
        }
    }

    // fucntion to freeze player and set end state true
    void HaveILeft()
    {

        if (!safeOut)
        {
            Debug.Log("Taking Control");

            this.player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ |
            RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            GameStateManager.fled = true;
        }
    }
    // function to deactivate fled NPCS
    void LeftTheField()
    {
        this.theFled.gameObject.SetActive(false);
    }
}