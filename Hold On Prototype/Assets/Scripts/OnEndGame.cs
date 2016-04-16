using UnityEngine;
using System.Collections;

public class OnEndGame : MonoBehaviour {
   
 public float transitionDuration = 3.5f;
 public Transform target;
    public static bool cameraPanned = false;   
    
    
    public IEnumerator Transition()
    {
        float timeInitial = 0.0f;
        Vector3 startingPos = transform.position;
        while (timeInitial < 1.0f)
        {
            timeInitial += Time.deltaTime * (Time.timeScale / transitionDuration);

            transform.position = Vector3.Lerp(startingPos, target.position, timeInitial);
            yield return 0;
        }

        cameraPanned = true;
    }


}
