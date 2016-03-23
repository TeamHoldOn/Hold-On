using UnityEngine;
using System.Collections;

public class globalFlock : MonoBehaviour {

    public GameObject Friendly;
    public static Vector3 goalPos = Vector3.zero;
    
    static int numFriendlies = 8;
    public static GameObject[] allFriendlies = new GameObject[numFriendlies];
 }
