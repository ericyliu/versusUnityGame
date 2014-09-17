using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class CharacterConstants {  

	static Dictionary<string,string> playerFighter = new Dictionary<string,string>() {
		{"health","100"},
		{"speed","10"},
		{"weapon","MachineGun"}
	};
	
	static Dictionary<string,string> basicEnemy = new Dictionary<string,string>() {
		{"health","10"},
		{"speed","5"},
		{"worth","10"},
		{"weapon","MachineGun"}
	};
	
	public static Dictionary<string,Dictionary<string,string>> fighters = new Dictionary<string,Dictionary<string,string>>() {
		{"PlayerFighter",playerFighter},
		{"BasicEnemy",basicEnemy}	
	};
	
	public static float[] levelSpawnRate = new float[] {6,5,4.5f,4,3.5f,3,2.5f,2,1,.8f,.5f};
	
	static Dictionary<string,string> machineGun = new Dictionary<string, string>() {
		{"firingSpeed",".5"},
		{"bullet","BasicBullet"}
	};
	
	public static Dictionary<string,Dictionary<string,string>> weapons = new Dictionary<string,Dictionary<string,string>>() {
		{"MachineGun",machineGun}
	};
	
}
