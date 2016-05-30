using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    // three different end conditions
    public static bool fled = false;
    public static bool died = false;
    public static bool lost = false;
    public static bool ending = false;
    public OnEndGame onEndGame;
    public Camera mainCamera;
    public Canvas canvas;
    public Camera protestCamera;
    public GameObject protestSceneManager;
    public GameObject player;
    public GameObject enemySpawner;
    public GameObject protesters;

    void Start()
    {   
        GameObject.DontDestroyOnLoad(gameObject);

        if (MainMenu.playedOnce)
        {
            canvas.enabled = false;
            protestCamera.enabled = false;
            protestSceneManager.SetActive(false);
            player.GetComponent<FirstEnemySpawn>().enabled = false;
            enemySpawner.SetActive(true);
            protesters.SetActive(true);
            canvas.GetComponent<AudioSource>().enabled = false;
            protestSceneManager.GetComponent<ProtestScene>().enabled = false;
            protestCamera.GetComponent<AudioSource>().enabled = false;
            protestCamera.GetComponent<chant>().enabled = false;
        }
    }
    void Update()
    {

        if ((fled | died | lost) && !ending)
        {
            // each frame if game has ended camera zooms out to show field damage and ongoing chaos begins the transition to final scene
            mainCamera.GetComponent<CameraController>().enabled =false;
            StartCoroutine(onEndGame.Transition());

            if (OnEndGame.cameraPanned)
            {
                ending = true;
                Invoke("InitiateEnding", 3);
            }
        }

    }

    // resets end variables so game is not constantly trying to load the last scene
    public void ResetEndVariables()
    {
        fled = false;
        died = false;
        lost = false;

    }

    // function to load final scene separate from current scene and then resets the variables
    void InitiateEnding() {
        SceneManager.LoadScene("Ending", LoadSceneMode.Single);
        Debug.Log("Loaded Scene");
     //ResetEndVariables();
     
    }
}
