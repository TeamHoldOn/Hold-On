using UnityEngine;
using System.Collections;

public class TileSwapScript : MonoBehaviour
{
    //bools establishing if this hex has been hit already 
    bool hexHit = false;
    bool deathHex = false;
    // hex types switched to around hex collided with
    public GameObject hexagon2;
    public GameObject hexagon3;
    public GameObject hexagon4;
    GameObject hexagon;
   // references to script and variables that collect and stores the 18 hexes closest to the hex collided with
    NearestHexFinder nearestHexFinder;
    Collider[] toChange;
    GameObject otherHexes;

    // the main function of this script is to handle collisions with "Dead" objects and the resulting environmental damage.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dead")
        {
            hexHit = true;

            if (hexHit && !deathHex)
            {
                Quaternion rotate = this.HexRotation();
                
                // destroys existing child of hex object
                hexagon = this.gameObject.transform.GetChild(0).gameObject;
                Destroy(hexagon);

                //instantiates death hex and sets rotation and parent
                GameObject hex_obj2 = (GameObject)Instantiate(hexagon2, new Vector3(0, 0, 0), rotate);
                hex_obj2.transform.SetParent(this.transform, worldPositionStays: false);

                // keeps hex from getting changed once it is already the slowest type
                deathHex = true;

                //gathers the 19 nearest neighbors including self and establishes that they are to be changed
                nearestHexFinder = this.GetComponent<NearestHexFinder>();
                toChange = nearestHexFinder.nearestHexes;
                
                // sets impact size for whole or half of array
                int howBig = this.SizeEffect();
               
                //loop for 2nd slowest hexes
                for (int i = 0; i < 7; i++)
                {

                    otherHexes = toChange[i].gameObject;
                    //establishes underlying hex models of nearest neighbors to replace
                    GameObject otherChild = otherHexes.transform.GetChild(0).gameObject;
                    
                    //establishes they are changing to 2nd slowest hex type
                    GameObject newHex = hexagon3;

                    //excludes self from change
                    if (!otherHexes.GetComponent<TileSwapScript>().deathHex)
                    {
                        Quaternion rotate2 = this.HexRotation();
                        Destroy(otherChild);

                        GameObject hex_obj3 = (GameObject)Instantiate(newHex, new Vector3(0, 0, 0), rotate2);
                        hex_obj3.transform.SetParent(otherHexes.transform, worldPositionStays: false);
                    }

                }

                //loop for 3rd slowest hexes
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
    
    // establishes a 1/4 chance of smaller effect size
   private int SizeEffect(){
        int sizeEffect = Random.Range(1, 5);
            return sizeEffect;
   }

   // establishes random rotation for newly instantiated hexes from options 0, 180
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