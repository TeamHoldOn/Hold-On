using UnityEngine;
using System.Collections;

public class SafeZoneTrigger : MonoBehaviour
{

    public static bool safeOut = true;
    public GameObject player;
    GameObject theFled;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            safeOut = false;
            Invoke("HaveILeft", 5);
        }
        if (other.gameObject.tag == "Friendly" | other.gameObject.tag == "Protester")
        {
            other.gameObject.tag = "Fled";
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            safeOut = true;
        }
        if (other.gameObject.tag == "Fled")
        {
            theFled = other.gameObject;
            Invoke("LeftTheField", 5);
        }
    }


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

    void LeftTheField()
    {
        this.theFled.gameObject.SetActive(false);
    }
}