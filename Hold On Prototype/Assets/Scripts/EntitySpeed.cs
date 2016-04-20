using UnityEngine;
using System.Collections;

public class EntitySpeed : MonoBehaviour
{

   
    HexSpeed hexSpeed;
    public Rigidbody playerRigidbody; // note not just player refers to rigid body of entity (player, friendly, protestor, enemy) script is attached to.

    public float checkedDrag;

    // this script checks which type of hex the entity is on and changes the drag applied to the entity as a result

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hex")
        {
             hexSpeed = other.gameObject.GetComponentInChildren<HexSpeed>();
         
            checkedDrag = hexSpeed.envtDrag;
            this.playerRigidbody.drag = checkedDrag;
        }
    }
}