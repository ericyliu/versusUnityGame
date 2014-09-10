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
		if (game.control.pl
		if (Input.GetKeyDown(KeyCode.UpArrow)) 
	}
	
	
}
