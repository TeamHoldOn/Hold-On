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
            deathHex = true;
            Debug.Log("Hit the hex");

            if (hexHit == true)
            {
                hexagon = this.gameObject.transform.FindChild("Hexagon").gameObject;
                Destroy(hexagon);

                GameObject hex_obj2 = (GameObject)Instantiate(hexagon2, new Vector3(0, 0, 0), Quaternion.EulerAngles(4.712f, 0, 0));
                hex_obj2.transform.SetParent(this.transform, worldPositionStays: false);

                nearestHexFinder = this.GetComponent<NearestHexFinder>();
                toChange = nearestHexFinder.nearestHexes;

                for (int i = 0; i < toChange.Length; i++)
                {

                    otherHexes = toChange[i].gameObject;
                    GameObject otherChild = otherHexes.transform.GetChild(1).gameObject;
                    GameObject newHex = hexagon3;
                    
                    if (otherHexes.GetComponent<TileSwapScript>().hexHit == false)
                    {


                        Destroy(otherChild);

                        GameObject hex_obj3 = (GameObject)Instantiate(newHex, new Vector3(0, 0, 0), Quaternion.EulerAngles(4.712f, 0, 0));
                        hex_obj3.transform.SetParent(otherHexes.transform, worldPositionStays: false);
                    }

                }
            }
        }
    }
}