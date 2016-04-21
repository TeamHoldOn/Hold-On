using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

    int continueCounter = 0;
    public Image instruction;
    public Sprite englishInstruction;
    public Sprite arabicInstruction;

    public void PlayGame(){

        continueCounter = (continueCounter + 1);
        if(continueCounter==1) { 
        this.instruction.sprite = arabicInstruction; }
        if (continueCounter == 2) {
        this.instruction.sprite = englishInstruction; }
        if (continueCounter == 3)
        {
            Application.LoadLevel(1);
        }
	}

	public void ExitGame(){
	
		Application.Quit ();
	
	}
}
