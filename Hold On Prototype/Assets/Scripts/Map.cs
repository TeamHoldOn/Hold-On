using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

    public GameObject hexPrefab;
    public int width = 50;
    public int depth = 40;

    float offset = 0.89f;


    void Start() {
        for (int x = 0; x < width; x=(x+2)){
            for (int z = 0; z < depth; z++)
            {
                float xPos = x;

                if ( z % 2 == 1) {
                    xPos = xPos+offset;
                }

              GameObject hex_obj =(GameObject)Instantiate(hexPrefab, new Vector3(xPos, 0, z*2*offset), Quaternion.identity);
                hex_obj.name = "Hex_#_" + x + "_" + z;

                hex_obj.transform.SetParent(this.transform, worldPositionStays:false);
              }
        }

	}
	



	// Update is called once per frame
	void Update () {
	
	}
}
