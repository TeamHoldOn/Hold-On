using UnityEngine;
using System.Collections;

public class NearestHexFinder : MonoBehaviour {

    public Collider[] nearestHexes;
    Vector3 hexLocation;
    //timing bools for map instantiation
    public static bool allInstantiated = false;
    public static bool allNeighborsCollected = false;


    void Start() 
    {  
    }

    void Update()
    //if map is created and neighbors not yet gathered
    { if (allInstantiated && !allNeighborsCollected)
        {
            // use OverLap sphere to find all colliders within world unit 4 radius and store them. Accessed by HexSwap Script 
            hexLocation = this.transform.position;
            this.nearestHexes = Physics.OverlapSphere(hexLocation, 4.0f, 1 << 8, QueryTriggerInteraction.Collide);
        }
    }

    // after update if all neighbors collected bool set that will stop gathering from being continuous.
    void DelayedUpdate()
    {
        if (allInstantiated && !allNeighborsCollected)
        { allNeighborsCollected = true;
        }
    }
            
}
