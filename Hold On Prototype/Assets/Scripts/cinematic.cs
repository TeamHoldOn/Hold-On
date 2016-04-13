using UnityEngine;
using System.Collections;

public class cinematic : MonoBehaviour {

    public GameObject firstProtester;
    public GameObject SafeArea;
    GameObject[] firstProtesters;

	void Awake () {
        
        firstProtesters = GameObject.FindGameObjectsWithTag("firstProtester");
        Rigidbody fpRB = firstProtester.GetComponent<Rigidbody>();
	}
	
	void Update () {
        if (firstProtesters.Length <= 4) {
            foreach (GameObject firstProtester in firstProtesters) {
                Vector3 fleeTo = SafeArea.transform.position - transform.position;
                Rigidbody flee = firstProtester.GetComponent<Rigidbody>();
                flee.velocity += fleeTo.normalized;
           
                float speedLimit = flee.velocity.sqrMagnitude;
                if (speedLimit > 1f) {
                    flee.velocity += -(flee.velocity.normalized);
                }
            }
        }
    }
}                  