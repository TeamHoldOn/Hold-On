using UnityEngine;
using System.Collections;

public class NearestHexFinder : MonoBehaviour {

    public Collider[] nearestHexes;
    Vector3 hexLocation;
    public static bool allInstantiated = false;
    public static bool allNeighborsCollected = false;


    void Start() 
    {  
    }

    void Update()
    { if (allInstantiated && !allNeighborsCollected)
        {
            hexLocation = this.transform.position;
            this.nearestHexes = Physics.OverlapSphere(hexLocation, 4.0f, 1 << 8, QueryTriggerInteraction.Collide);
        }
    }

    void DelayedUpdate()
    {
        if (allInstantiated && !allNeighborsCollected)
        { allNeighborsCollected = true;
        }
    }
            
}
