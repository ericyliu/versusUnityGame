using UnityEngine;
using System.Collections;

public class MainMenu : Menu {

	ApplicationController app;
	
	
	
	// Use this for initialization
	void Start () {
		app = GameObject.Find("Application").GetComponent<ApplicationController>();
		on = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//-----------------------------------------------------
	
	// OnGUI is called once per frame
	void OnGUI () {
		if (on) {
			if (GUI.Button(app.guiRects.menuRects["mainMenuSinglePlayer"],"Singe Player")) {
				singlePlayerInitiate ();
			}
			if (GUI.Button (app.guiRects.menuRects["mainMenuUseVersus"],"Use Versus")) {
				versusInitiate ();
			}
			if (GUI.Button (app.guiRects.menuRects["mainMenuExit"],"Quit")){
				quitGame (); 
			}
		}
	}
	
	// Connect with versus
	void versusInitiate () {
		
	}
	
	// Initiate Single Player
	void singlePlayerInitiate () {
		on = false;
		MenuController.changeMenuTo("GameMenu");
		app.game.startGame();
	}
	
	// Quit Game
	void quitGame () {
		Application.Quit();
	}
}
