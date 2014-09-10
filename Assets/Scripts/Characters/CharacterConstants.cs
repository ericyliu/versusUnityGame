using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class CharacterConstants {

	public static Dictionary<string,float> playerFighter = new Dictionary<string,float>() {
		{"health",100},
		{"speed",5},
		{"firingSpeed", .500f},
		{"hitboxX",10},
		{"hitboxY",10}
	};
	
	public static Dictionary<string,float> basicEnemy = new Dictionary<string,float>() {
		{"health",10},
		{"speed",3},
		{"firingSpeed", 1},
		{"hitboxX",10},
		{"hitboxY",10}
	};
	
	public static Dictionary<string,int> weapons = new Dictionary<string,int>(){
		{"bullet",5},
		{"energyBall",5}
	};
	
	public static float[] levelSpawnRate = new float[] {6,5,4.5f,4,3.5f,3,2.5f,2,1,.8f,.5f};
	
}
