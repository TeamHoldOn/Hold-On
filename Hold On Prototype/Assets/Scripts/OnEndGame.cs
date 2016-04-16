using UnityEngine;
using System.Collections;

public class OnEndGame : MonoBehaviour {
   
 public float transitionDuration = 8f;
 public Transform target;
    public static bool cameraPanned = false;   
    
    
    public IEnumerator Transition()
    {
        float timeInitial = 0.0f;
        Vector3 startingPos = this.gameObject.transform.position;
        Quaternion startingRot = this.gameObject.transform.rotation;
        while (timeInitial < 10.0f)
        {
            timeInitial += Time.deltaTime * (Time.timeScale / transitionDuration);

            transform.position = Vector3.Lerp(startingPos, target.position, timeInitial);
            transform.rotation = Quaternion.Lerp(startingRot, target.rotation, timeInitial);
            yield return 0;
        }

        cameraPanned = true;
    }


}
