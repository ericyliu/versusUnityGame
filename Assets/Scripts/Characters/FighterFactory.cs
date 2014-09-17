using UnityEngine;
using System.Collections;

// Creates player fighter + enemy fighters

public static class FighterFactory {

	static int fighterID = 1;

	public static Fighter createPlayerFighter (Vector2 position) {
		GameObject fighterObject = loadMesh(position);
		loadMaterial(fighterObject,"Materials/PlayerFighterMaterial");
		fighterObject.name = "PlayerFighter";
		
		Fighter fighter = fighterObject.AddComponent("Fighter") as Fighter;
		fighter.isPlayer = true;
		fighter.health = (int) CharacterConstants.playerFighter["health"];
		fighter.maxHealth = (int) CharacterConstants.playerFighter["health"];
		fighter.speed = CharacterConstants.playerFighter["speed"];
		fighter.firingSpeed = CharacterConstants.playerFighter["firingSpeed"];
		fighter.weapon = "bullet";
		fighter.position = position;
		
		return fighter;
	}
	
	public static Fighter createBasicEnemy (Vector2 position) {
		GameObject fighterObject = loadMesh (position);
		fighterObject.name = "BasicEnemy";
		
		Fighter fighter = fighterObject.AddComponent("Fighter") as Fighter;
		fighterID++;
		fighter.health = (int) CharacterConstants.basicEnemy["health"];
		fighter.maxHealth = (int) CharacterConstants.basicEnemy["health"];
		fighter.speed = CharacterConstants.basicEnemy["speed"];
		fighter.firingSpeed = CharacterConstants.basicEnemy["firingSpeed"];
		fighter.weapon = "energyBall";
		fighter.position = position;
		
		return fighter;
	}
	
	static GameObject loadMesh (Vector2 position) {
		Vector3 pos = new Vector3(position.x, 0, position.y);
		GameObject fighter = GameObject.CreatePrimitive(PrimitiveType.Cube);
		fighter.transform.position = pos;
		return fighter;
	}
	
	static void loadMaterial (GameObject fighter, string source) {
		MeshRenderer fighterRenderer = fighter.GetComponent<MeshRenderer>();
		fighterRenderer.material = Resources.Load (source,typeof(Material)) as Material;
	}
	
	
}
