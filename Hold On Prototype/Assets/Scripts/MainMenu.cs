﻿using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public void PlayGame(){
		
		Application.LoadLevel (1);	

	}

	public void ExitGame(){
	
		Application.Quit ();
	
	}
}