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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		updateActions();
	}
	
	void updateActions () {
		if (behavior != "none") {
			
		}
	}
	
	public void tagBehavioralUpdate (string updateBehaviorTo) {
		//Update behavior name
		behavior = updateBehaviorTo;
		
		behavioralUpdate = true;
		
	}
	
	
}
