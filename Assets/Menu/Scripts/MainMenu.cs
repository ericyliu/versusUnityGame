using UnityEngine;
using System.Collections;

public class MainMenu : Menu {

	GameMaster game;
	
	
	
	// Use this for initialization
	void Start () {
		game = GameObject.Find("GameMaster").GetComponent("GameMaster") as GameMaster;
		on = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//-----------------------------------------------------
	
	// OnGUI is called once per frame
	void OnGUI () {
		if (on) {
			if (GUI.Button(game.guiRects.menuRects["mainMenuSinglePlayer"],"Singe Player")) {
				singlePlayerInitiate ();
			}
			if (GUI.Button (game.guiRects.menuRects["mainMenuUseVersus"],"Use Versus")) {
				versusInitiate ();
			}
			if (GUI.Button (game.guiRects.menuRects["mainMenuExit"],"Quit")){
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
		game.control.startGame();
	}
	
	// Quit Game
	void quitGame () {
		Application.Quit();
	}
}
