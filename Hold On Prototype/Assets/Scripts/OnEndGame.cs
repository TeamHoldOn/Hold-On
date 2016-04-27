using UnityEngine;
using System.Collections;

public class OnEndGame : MonoBehaviour {
 //end scene takes control of camera pan out begins, runs and ends camera pan then allows to move to next scene.  
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

            //movement plus smoothing for both position and rotation of main camera
            transform.position = Vector3.Lerp(startingPos, target.position, timeInitial);
            transform.rotation = Quaternion.Lerp(startingRot, target.rotation, timeInitial);
            yield return 0;
        }
        //camera move has executed triggers other end game functions in GameStateManager
        cameraPanned = true;
    }
}
