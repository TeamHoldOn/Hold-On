using UnityEngine;
using System.Collections;

public class PlayerSpeed : MonoBehaviour
{

    //PlayerControllerPhysics playerControllerPhysics;
    HexSpeed hexSpeed;
    public Rigidbody playerRigidbody;
    //public int checkedSpeed;
    public float checkedDrag;

    // this script checks which type of hex the player is on and changes the speed applied to the player as a result

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hex")
        {
             hexSpeed = other.gameObject.GetComponentInChildren<HexSpeed>();
            // checkedSpeed = hexSpeed.envtSpeed;
            // playerControllerPhysics = GetComponent<PlayerControllerPhysics>();
            // playerControllerPhysics.speed = checkedSpeed;

            checkedDrag = hexSpeed.envtDrag;
            this.playerRigidbody.drag = checkedDrag;
        }
    }
}