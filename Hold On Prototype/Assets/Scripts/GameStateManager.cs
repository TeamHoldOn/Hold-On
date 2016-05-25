using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    // three different end conditions
    public static bool fled = false;
    public static bool died = false;
    public static bool lost = false;
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
        if (MainMenu.playedOnce)
        {
            canvas.enabled = false;
            protestCamera.enabled = false;
            protestSceneManager.SetActive(false);
            player.GetComponent<FirstEnemySpawn>().enabled = false;
            enemySpawner.SetActive(true);
            protesters.SetActive(true);
            canvas.GetComponent<AudioSource>().enabled = false;
        }
    }
    void Update()
    {

        if (fled | died | lost)
        {
            // each frame if game has ended camera zooms out to show field damage and ongoing chaos begins the transition to final scene
            mainCamera.GetComponent<CameraController>().enabled =false;
            StartCoroutine(onEndGame.Transition());

            if (OnEndGame.cameraPanned)
            {
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
        ResetEndVariables();
    }
}
