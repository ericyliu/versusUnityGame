﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ApplicationController : MonoBehaviour {

	string ip;
	string port;
	
	public bool usingVersus = false;
	public GUIRects guiRects;

	public Dictionary<string,Component> menus = new Dictionary<string, Component>(); 

	public GameController game;

	// Use this for initialization
	void Start () {
	
		// Initialize Menus
		guiRects = new GUIRects();
		menus.Add ("MainMenu",GameObject.Find("GUI").GetComponent("MainMenu"));
		menus.Add ("GameMenu",GameObject.Find("GUI").GetComponent("GameMenu"));
		menus.Add ("EndMenu", GameObject.Find("GUI").GetComponent("EndMenu"));
		
		game = GameObject.Find ("Application").GetComponent<GameController>();
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
