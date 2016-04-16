using UnityEngine;
using System.Collections;

public class TileSwapScript : MonoBehaviour
{
    bool hexHit = false;
    bool deathHex = false;
    public GameObject hexagon2;
    public GameObject hexagon3;
    public GameObject hexagon4;
    GameObject hexagon;
    NearestHexFinder nearestHexFinder;
    Collider[] toChange;
    GameObject otherHexes;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dead")
        {
            hexHit = true;

            if (hexHit && !deathHex)
            {
                Quaternion rotate = this.HexRotation();
                
                hexagon = this.gameObject.transform.GetChild(0).gameObject;
                Destroy(hexagon);

                GameObject hex_obj2 = (GameObject)Instantiate(hexagon2, new Vector3(0, 0, 0), rotate);
                hex_obj2.transform.SetParent(this.transform, worldPositionStays: false);

                deathHex = true;

                nearestHexFinder = this.GetComponent<NearestHexFinder>();
                toChange = nearestHexFinder.nearestHexes;
                
                int howBig = this.SizeEffect();
               

                for (int i = 0; i < 7; i++)
                {

                    otherHexes = toChange[i].gameObject;
                    GameObject otherChild = otherHexes.transform.GetChild(0).gameObject;
                    GameObject newHex = hexagon3;

                    if (!otherHexes.GetComponent<TileSwapScript>().deathHex)
                    {
                        Quaternion rotate2 = this.HexRotation();
                        
                        Destroy(otherChild);

                        GameObject hex_obj3 = (GameObject)Instantiate(newHex, new Vector3(0, 0, 0), rotate2);
                        hex_obj3.transform.SetParent(otherHexes.transform, worldPositionStays: false);
                    }

                }

                if ((howBig > 0) && (howBig < 4)) {
                    for (int i = 0; 7 < toChange.Length; i++)
                    {
                        otherHexes = toChange[i].gameObject;
                        GameObject otherChild = otherHexes.transform.GetChild(0).gameObject;
                        GameObject newHex = hexagon4;

                        if (!otherHexes.GetComponent<TileSwapScript>().deathHex)
                        {
                            Quaternion rotate2 = this.HexRotation();
                           
                             Destroy(otherChild);

                            GameObject hex_obj3 = (GameObject)Instantiate(newHex, new Vector3(0, 0, 0), rotate2);
                            hex_obj3.transform.SetParent(otherHexes.transform, worldPositionStays: false);
                        }

                    }
                }
            }
        }
    }
    
   private int SizeEffect(){
        int sizeEffect = Random.Range(1, 5);
            return sizeEffect;
   }
   private Quaternion HexRotation()
    {

        Quaternion hexOrientation;
         
        int rotationSelect = Random.Range(1, 6);
        

        if(rotationSelect <= 3) {
         hexOrientation = Quaternion.identity;
            return hexOrientation;

        }
        if(rotationSelect >= 4) {
            hexOrientation = Quaternion.Euler(0f, 180f, 0f);
            return hexOrientation;
        }
        else
        {
            return Quaternion.identity;
        }
    }
}