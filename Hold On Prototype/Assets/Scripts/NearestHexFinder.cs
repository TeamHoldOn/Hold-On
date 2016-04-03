using UnityEngine;
using System.Collections;

public class NearestHexFinder : MonoBehaviour {

    public GameObject[] nearestHexes;
    public Transform hexLocation = this.GetComponent<Transform>.transform;

    // Use this for initialization

    private GameObject FindClosestHexes(Vector3 hexLocation)
    {
        GameObject nearestHex = null;

        float nearestHexDistance =
       GameObject[] nearestHexes = GameObject.FindGameObjectsWithTag("Hex");

        foreach (GameObject hex in nearestHexes)
        {
            float tempDistance = Vector3.Distance(hexLocation, hex.transform.position);

            if (tempDistance < nearestHexDistance)
            {
                nearestHex = hex;
                nearestHexDistance = tempDistance;
            }
        }

        return nearestHex;
    }
}

    
	
