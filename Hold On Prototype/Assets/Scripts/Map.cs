using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

    public GameObject hexPrefab;
    public int width = 50;
    public int depth = 40;
    float offset = .89f;


    void Awake() {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                float xPos = 1.70f*x;

                if ( z % 2 == 1) {
                    xPos = xPos+offset;
                }

               Quaternion rotation = this.HexRotation();   
                
              GameObject hex_obj =(GameObject)Instantiate(hexPrefab, new Vector3(xPos, 0, 1.5f*z), rotation);
                hex_obj.name = "Hex_#_" + x + "_" + z;

                hex_obj.transform.SetParent(this.transform, worldPositionStays:false);
              }
        }
        NearestHexFinder.allInstantiated = true;
    }


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
