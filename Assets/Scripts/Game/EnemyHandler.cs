using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class EnemyHandler {

	public static List<Fighter> enemies = new List<Fighter>();
	public static List<Fighter> deadEnemies = new List<Fighter>();
	
	static float lastTimeEnemySpawned = 0;
	
	static GameController game = GameObject.Find ("Application").GetComponent<GameController>();
	
	// Spawning //
	
	public static void spawnEnemy () {
		if (Time.time - lastTimeEnemySpawned > GameConstants.levelSpawnRate[game.level]) {
			Fighter enemy = FighterFactory.createBasicEnemy(generateEnemySpawnPosition());
			enemies.Add(enemy);
			lastTimeEnemySpawned = Time.time;
		}
	}
	
	static Vector2 generateEnemySpawnPosition () {
		return Vector2.zero;
	}
	
	// Handle Death //
	
	public static void removeEnemies () {
		foreach (Fighter fighter in deadEnemies) {
			ScoreHandler.addScore(fighter.type);
			enemies.Remove(fighter);
			GameObject.Destroy(fighter.gameObject);
		}
		deadEnemies.Clear();
	}
	
	
}
