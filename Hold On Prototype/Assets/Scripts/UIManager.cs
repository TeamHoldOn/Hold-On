using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIManager : MonoBehaviour {

	public GameObject pauseCanvas;
	bool pauseToggleOn = false;
	bool isPaused = false;
	int verticalInput = 0;

	void Update(){
		
		PauseGame ();

		//if the game is paused, start taking input from the controller to control button selection
		if (isPaused) {
			verticalInput = (int)Input.GetAxis ("Vertical");
		}

		if (verticalInput != 0) {

		}
	
	}

	//the following two functions are attached to buttons on the PausePanel
	public void RestartGame(){
		MainMenu.playedOnce = true;
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

	/////////////////
	/////////////////

//	IEnumerator ButtonChange(int input)
//	{
//		if (input < 0 && Selected < pauseCanvas.Length - 1)
//			Selected++;
//		else if (input > 0 && Selected > 0)
//			Selected--;
//
//		yield return new WaitForSeconds(1f);
//		StopCoroutine(MenuChange(0));
//	}

}
