using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIManager : MonoBehaviour {

	public GameObject pauseCanvas;
	bool pauseToggleOn = false;
	bool isPaused = false;

	void Update(){
		
		PauseGame ();
	
	}

	//the following two functions are attached to buttons on the PausePanel
	public void RestartGame(){
		SceneManager.LoadScene (1);
	}

	public void GoToMainMenu(){
		SceneManager.LoadScene (0);
	}

	void PauseGame(){

		//first checks to see if the mouse has been clicked or Options/Start button pressed and makes it a toggle
		//I constructed it this way because simply having Unity read the same mouse button while only 
		//checking the isPaused bool didn't work for reasons I don't understand.

		if (Input.GetMouseButton(0) | Input.GetButton("PS4OptionsButton")){
			if (isPaused == false){
				pauseToggleOn = true;
			}

			if (isPaused == true) {
				pauseToggleOn = false;
			}
		}

		if ((pauseToggleOn == true) & (isPaused == false)) {
			isPaused = true;
			Time.timeScale = 0;
			pauseCanvas.SetActive (true);
		}

		if ((pauseToggleOn == false) & (isPaused == true)) {
			isPaused = false;
			Time.timeScale = 1;
			pauseCanvas.SetActive (false);
		}
	}
}
