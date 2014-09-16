using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Controller for a single instance of the game

public class GameController : MonoBehaviour {

	GameMaster game;

	GameObject playerFighter;
	Dictionary<int,GameObject> enemies = new Dictionary<int,GameObject>();

	public bool running = false;
	int level = 1;
	int playerLives = 0;

	float lastTimeEnemySpawned = 0;

	// Use this for initialization
	void Start () {
		game = GameObject.Find ("GameMaster").GetComponent("GameMaster") as GameMaster;
	}
	
	
	
	// Update is called once per frame
	void Update () {
		if (running) runningGameMethods ();
	}
	
	void runningGameMethods () {
		spawnEnemy ();
	}
	
	// Spawning //
	
	void spawnEnemy () {
		if (Time.time - lastTimeEnemySpawned > CharacterConstants.levelSpawnRate[1]) {
			GameObject enemy = FighterFactory.createBasicEnemy(generateEnemySpawnPosition());
			enemies.Add(getFighterInfo (enemy).id,enemy);
			lastTimeEnemySpawned = Time.time;
		}
	}
	
	Vector2 generateEnemySpawnPosition () {
		return Vector2.zero;
	}
	
	// Combat and Movement //
	
	public void setPlayerMovement (string direction, bool setting) {
		Fighter fighter = playerFighter.GetComponent("Fighter") as Fighter;
		fighter.setMovement(direction,setting);
	}
	
	public void fighterDied (int id) {
		if (id == 0) playerDied ();
		else {
			enemies.Remove(id);
		}
	}
	
	public void playerDied () {
		playerLives--;
		if (playerLives < 0) endGame ();
		else playerFighter = FighterFactory.createPlayerFighter (Vector2.zero);
	}
	
	// Game State //
	
	public void startGame () {
		playerFighter = FighterFactory.createPlayerFighter(Vector2.zero);
		playerLives = 3;
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
		enemies = new Dictionary<int,GameObject>();
		
		running = false;
	}
	
	// Utility //
	
	Fighter getFighterInfo (GameObject fighterObject) {
		return fighterObject.GetComponent("Fighter") as Fighter;
	}
	
}
