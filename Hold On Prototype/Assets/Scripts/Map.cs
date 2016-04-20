using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {
    //hex group object empty container with hex model inside
    public GameObject hexPrefab;
    // size of map
    public int width = 50;
    public int depth = 40;
    // offset of hexes to account for even hex rows (z) needing to be offset for tesselation 
    float offset = .89f;

    //instantiates initial map
    void Awake() {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                float xPos = 1.70f*x;

                if ( z % 2 == 1) {
                    xPos = xPos+offset;
                }
                //sets rotation for each hex object
               Quaternion rotation = this.HexRotation();   
              
               //instantiates hex object, creates grid naming convention and set map as parent  
              GameObject hex_obj =(GameObject)Instantiate(hexPrefab, new Vector3(xPos, 0, 1.5f*z), rotation);
                hex_obj.name = "Hex_#_" + x + "_" + z;

                //hex objects will move as parent is moved
                hex_obj.transform.SetParent(this.transform, worldPositionStays:false);
              }
        }
        //Once loops are complete declares map to be done and allows each hex to create an array with it's nearest neighbors
        NearestHexFinder.allInstantiated = true;
    }

    //establishes rotation of initial hexes in 60 degree increments all rotations equally likley
   private Quaternion HexRotation()
    {

        Quaternion hexOrientation;

        int rotationSelect = Random.Range(1, 7);


        if (rotationSelect == 1)
        {
            hexOrientation = Quaternion.identity;
            return hexOrientation;

        }
        if (rotationSelect == 2)
        {
            hexOrientation = Quaternion.Euler(0f, 60f, 0f);
            return hexOrientation;
        }
        if (rotationSelect == 3)
        {
            hexOrientation = Quaternion.Euler(0f, 120f, 0f);
            return hexOrientation;
        }
        if (rotationSelect == 4)
        {
            hexOrientation = Quaternion.Euler(0f, 180f, 0f);
            return hexOrientation;
        }
        if (rotationSelect == 5)
        {
            hexOrientation = Quaternion.Euler(0f, 240f, 0f);
            return hexOrientation;
        }
        if (rotationSelect == 6)
        {
            hexOrientation = Quaternion.Euler(0f, 300f, 0f);
            return hexOrientation;
        }
        else
        {
            return Quaternion.identity;
        }
    }


}
