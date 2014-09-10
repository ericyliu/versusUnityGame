using UnityEngine;
using System.Collections;

// Creates player fighter + enemy fighters

public static class FighterFactory {

	static int fighterID = 1;

	public static GameObject createPlayerFighter (Vector2 position) {
		GameObject fighter = GameObject.CreatePrimitive(PrimitiveType.Cube);
		Fighter playerFighter = fighter.AddComponent("Fighter") as Fighter;
		playerFighter.id = 0;
		playerFighter.health = (int) CharacterConstants.playerFighter["health"];
		playerFighter.maxHealth = (int) CharacterConstants.playerFighter["health"];
		playerFighter.speed = CharacterConstants.playerFighter["speed"];
		playerFighter.firingSpeed = CharacterConstants.playerFighter["firingSpeed"];
		playerFighter.weapon = "bullet";
		return fighter;
	}
	
	public static GameObject createBasicEnemy (Vector2 position) {
		GameObject fighter = GameObject.CreatePrimitive(PrimitiveType.Cube);
		Fighter enemy = fighter.AddComponent("Fighter") as Fighter;
		enemy.id = fighterID;
		fighterID++;
		enemy.health = (int) CharacterConstants.basicEnemy["health"];
		enemy.maxHealth = (int) CharacterConstants.basicEnemy["health"];
		enemy.speed = CharacterConstants.basicEnemy["speed"];
		enemy.firingSpeed = CharacterConstants.basicEnemy["firingSpeed"];
		enemy.weapon = "energyBall";
		return fighter;
	}
	
	
}
