using UnityEngine;
using System.Collections;

public class NearestHexFinder : MonoBehaviour {

    public Collider[] nearestHexes;
    Vector3 hexLocation;

        void Start() {

            hexLocation = this.transform.position;    
            Collider[] nearestHexes = Physics.OverlapSphere(hexLocation, 3.0f, 8, QueryTriggerInteraction.Collide);
        }
}
