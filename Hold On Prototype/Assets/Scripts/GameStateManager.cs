using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{

    public static bool fled = false;
    public static bool died = false;
    public static bool lost = false;
    public OnEndGame onEndGame;
    public Camera mainCamera;
    // Update is called once per frame
    void Update()
    {

        if (fled | died | lost)
        {
            mainCamera.GetComponent<CameraController>().enabled =false;
            StartCoroutine(onEndGame.Transition());

            if (OnEndGame.cameraPanned)
            {
                Invoke("InitiateEnding", 3);
            }
        }

    }


    public void ResetEndVariables()
    {
        fled = false;
        died = false;
        lost = false;

    }

    void InitiateEnding() {
        SceneManager.LoadScene("Ending", LoadSceneMode.Single);
        ResetEndVariables();
    }
}
