using UnityEngine;
using System.Collections;
using System;

// Creates player fighter + enemy fighters

public static class FighterFactory {

	public static Fighter createPlayerFighter (Vector2 position) {
		GameObject fighterObject = loadMesh(position);
		loadMaterial(fighterObject,"Materials/PlayerFighterMaterial");
		fighterObject.name = "PlayerFighter";
		
		Fighter fighter = loadFighterStats ("PlayerFighter", position, fighterObject);
		
		fighter.isPlayer = true;
		return fighter;
	}
	
	public static Fighter createBasicEnemy (Vector2 position) {
	
		GameObject fighterObject = loadMesh (position);
		fighterObject.name = "BasicEnemy";
		
		Fighter fighter = loadFighterStats ("BasicEnemy", position, fighterObject);
		loadAI ("BackAndForth", fighterObject);
		
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
	
	static Fighter loadFighterStats (string type, Vector2 position, GameObject fighterObject) {
		Fighter fighter = fighterObject.AddComponent("Fighter") as Fighter;
		fighter.health = Int32.Parse(CharacterConstants.fighters[type]["health"]);
		fighter.maxHealth = Int32.Parse(CharacterConstants.fighters[type]["health"]);
		fighter.speed = Int32.Parse(CharacterConstants.fighters[type]["speed"]);
		fighter.weapon = CharacterConstants.fighters[type]["weapon"];
		fighter.firingSpeed = float.Parse(CharacterConstants.weapons[fighter.weapon]["firingSpeed"]);
		fighter.type = type;
		fighter.position = position;
		return fighter;
	}
	
	static void loadAI (string type, GameObject fighterObject) {
		EnemyAI ai = fighterObject.AddComponent<EnemyAI>();
		ai.tagBehavioralUpdate(type);
	}
	
}
