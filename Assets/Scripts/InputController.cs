using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	GameMaster game;

	// Use this for initialization
	void Start () {
		game = GameObject.Find ("GameMaster").GetComponent("GameMaster") as GameMaster;
	}
	
	// Update is called once per frame
	void Update () {
		if (game.control.running) readGameInput ();
	}
	
	void readGameInput () {
		readMovementInput ();
	}
	
	void readMovementInput () {
		if (Input.GetKeyDown(KeyCode.UpArrow)) game.control.setPlayerMovement("up",true);
		if (Input.GetKeyDown(KeyCode.DownArrow)) game.control.setPlayerMovement("down",true); 
		if (Input.GetKeyDown(KeyCode.LeftArrow)) game.control.setPlayerMovement("left",true);
		if (Input.GetKeyDown(KeyCode.RightArrow)) game.control.setPlayerMovement("right",true);
		
		if (Input.GetKeyUp(KeyCode.UpArrow)) game.control.setPlayerMovement("up",false);
		if (Input.GetKeyUp(KeyCode.DownArrow)) game.control.setPlayerMovement("down",false); 
		if (Input.GetKeyUp(KeyCode.LeftArrow)) game.control.setPlayerMovement("left",false);
		if (Input.GetKeyUp(KeyCode.RightArrow)) game.control.setPlayerMovement("right",false);
	}
	
	
}
