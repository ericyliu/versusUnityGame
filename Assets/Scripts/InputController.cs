using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	GameController game;

	// Use this for initialization
	void Start () {
		game = GameObject.Find ("Application").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (game.running) readGameInput ();
	}
	
	void readGameInput () {
		readMovementInput ();
		readCombatInput ();
	}
	
	void readMovementInput () {
		if (Input.GetKeyDown(KeyCode.UpArrow)) game.setPlayerMovement("up",true);
		if (Input.GetKeyDown(KeyCode.DownArrow)) game.setPlayerMovement("down",true); 
		if (Input.GetKeyDown(KeyCode.LeftArrow)) game.setPlayerMovement("left",true);
		if (Input.GetKeyDown(KeyCode.RightArrow)) game.setPlayerMovement("right",true);
		
		if (Input.GetKeyUp(KeyCode.UpArrow)) game.setPlayerMovement("up",false);
		if (Input.GetKeyUp(KeyCode.DownArrow)) game.setPlayerMovement("down",false); 
		if (Input.GetKeyUp(KeyCode.LeftArrow)) game.setPlayerMovement("left",false);
		if (Input.GetKeyUp(KeyCode.RightArrow)) game.setPlayerMovement("right",false);
	}
	
	void readCombatInput () {
		if (Input.GetKeyDown (KeyCode.Space)) game.setPlayerFiring(true);
		if (Input.GetKeyUp (KeyCode.Space)) game.setPlayerFiring(false);
	}
	
	
}
