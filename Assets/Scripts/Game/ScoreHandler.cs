using UnityEngine;
using System.Collections;
using System;

public static class ScoreHandler {

	public static int score = 0;
	
	static int combo = 1;
	static int comboLimit = 5;
	static float comboTimer = .5f;
	static float lastHitTime = 0f;
	
	public static void addScore (string type) {
		int worth = Int32.Parse(CharacterConstants.fighters[type]["worth"]);
		if (Time.time - lastHitTime <= comboTimer) combo++;
		else combo = 1;
		if (combo > comboLimit) combo = comboLimit;
		lastHitTime = Time.time;
		score += combo * worth;
		displayCombo();
	}
	
	static void displayCombo () {
		if (combo >= 2) Debug.Log ("Combo!!! -- " + combo);
	}
	
}
