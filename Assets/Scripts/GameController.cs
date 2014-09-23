using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Controller for a single instance of the game

public class GameController : MonoBehaviour {

	public Fighter playerFighter;
	
	public bool running = false;
	public int level = 1;
	int playerLives = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (running) runGameMethods ();
	}
	
	void runGameMethods () {
		EnemyHandler.spawnEnemy ();
		CombatHandler.checkHits ();
		CombatHandler.removeBullets ();
		EnemyHandler.removeEnemies ();
	}
	
	void spawnPlayer () {
		playerFighter = FighterFactory.createPlayerFighter(Vector2.zero);
	}
	
	public void playerDied () {
		playerLives--;
		GameObject.Destroy(playerFighter.gameObject);
		if (playerLives < 0) endGame ();
		else {
			spawnPlayer ();
			EnemyHandler.resetAI ();
		}
	}
	
	public void fighterDied (Fighter fighter) {
		if (fighter.isPlayer) playerDied ();
		else EnemyHandler.deadEnemies.Add (fighter);
	}
	
	// Input Methods //
	
	public void setPlayerMovement (string direction, bool setting) {
		playerFighter.setMovement(direction,setting);
	}
	
	public void setPlayerFiring (bool setting) {
		playerFighter.setFiring(setting);
	}
	
	// Game State //
	
	public void startGame () {
		spawnPlayer();
		playerLives = 3;
		ScoreHandler.score = 0;
		running = true;
	}
	
	void endGame () {
		resetGame ();
		MenuController.changeMenuTo("EndMenu");
	}
	
	void resetGame () {
		//Remove player fighter
		playerFighter = null;
		//Remove enemies
		EnemyHandler.enemies = new List<Fighter>();
		
		running = false;
	}
	
}
