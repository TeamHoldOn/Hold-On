using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

    int continueCounter = 0;
    public Image instruction;
    public Sprite englishInstruction;
    public Sprite arabicInstruction;
    public static bool playedOnce = false;

    public void PlayGame(){

        continueCounter = (continueCounter + 1);
        if(continueCounter==1) { 
        this.instruction.sprite = arabicInstruction; }
        if (continueCounter == 2) {
        this.instruction.sprite = englishInstruction; }
        if (continueCounter == 3)
        {
            SceneManager.LoadScene(1);
        }
	}

    public void ReplayGame()
    {
        playedOnce = true;
        SceneManager.LoadScene(1);
    }
    public void ExitGame(){
	
		Application.Quit ();
	
	}
}
