using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour {

	string behavior = "none";
	bool behavioralUpdate = false;
	string[] actions = null;
	int currentActionIndex;
	
	string currentPrimaryAction;
	string currentSecondaryAction;
	string currentPrimaryActionArgs;
	string currentSecondaryActionArgs;
	
	Fighter thisFighter;
	
	//Parameters
	Vector2 destination;
	

	// Use this for initialization
	void Start () {
		thisFighter = gameObject.GetComponent<Fighter>();
	}
	
	// Update is called once per frame
	void Update () {
		updateActions ();
		doAction ();
	}
	
	void updateActions () {
		if (behavioralUpdate) {
			reset ();
		}
	}
	
	void startAction () {
		string action = actions[currentActionIndex];
		string[] actionArray = action.Split(' ');
		currentPrimaryAction = actionArray[0].Split(':')[0];
		currentPrimaryActionArgs = actionArray[0].Split(':')[1];
		
		// Primary Actions
		switch (currentPrimaryAction) {
			case "GoTo":
				destination.x = float.Parse(currentPrimaryActionArgs.Split(',')[0]);
				destination.y = float.Parse(currentPrimaryActionArgs.Split(',')[1]);
				break;
			case "Fire":
				if (currentPrimaryActionArgs == "True") thisFighter.setFiring(true);
				else thisFighter.setFiring(false);
				nextAction ();
				break; 
			case "Face":
				thisFighter.faceTowards(currentPrimaryActionArgs);
				nextAction ();
				break;
		}
		
	}
	
	void doAction () {
		// Primary Actions
		switch (currentPrimaryAction) {
			case "GoTo":
				bool arrived = thisFighter.moveTo(destination);
				if (arrived) nextAction ();
				break;
			case "Fire":
				break;
			case "Face":
				break;
		}
	}
	
	void nextAction () {
		currentActionIndex++;
		if (currentActionIndex == actions.Length) currentActionIndex = 0;
		startAction ();
	}
	
	public void reset () {
		thisFighter.setFiring(false);
		actions = AIDefinitions.behaviors[behavior];
		currentActionIndex = 0;
		behavioralUpdate = false;
		startAction ();
	}
	
	public void tagBehavioralUpdate (string updateBehaviorTo) {
		//Update behavior name
		behavior = updateBehaviorTo;
		
		behavioralUpdate = true;
		
	}
	
	
}
