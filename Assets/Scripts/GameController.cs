using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Controller for a single instance of the game

public class GameController : MonoBehaviour {

	Fighter playerFighter;
	List<Fighter> enemies = new List<Fighter>();
	List<Bullet> bullets = new List<Bullet>();

	List<Fighter> deadEnemies = new List<Fighter>();
	List<Bullet> deadBullets = new List<Bullet>();
	
	

	public bool running = false;
	int level = 1;
	int playerLives = 0;

	float lastTimeEnemySpawned = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (running) runGameMethods ();
	}
	
	void runGameMethods () {
		spawnEnemy ();
		checkHits ();
		removeBullets ();
		removeEnemies ();
	}
	
	// Spawning //
	
	void spawnPlayer () {
		playerFighter = FighterFactory.createPlayerFighter(Vector2.zero);
	}

	void spawnEnemy () {
		if (Time.time - lastTimeEnemySpawned > CharacterConstants.levelSpawnRate[level]) {
			Fighter enemy = FighterFactory.createBasicEnemy(generateEnemySpawnPosition());
			enemies.Add(enemy);
			lastTimeEnemySpawned = Time.time;
		}
	}
	
	Vector2 generateEnemySpawnPosition () {
		return Vector2.zero;
	}
	
	// Combat and Movement //
	public void setPlayerMovement (string direction, bool setting) {
		playerFighter.setMovement(direction,setting);
	}
	
	public void setPlayerFiring (bool setting) {
		playerFighter.setFiring(setting);
	}
	
	public void bulletFired (Bullet bullet) {
		bullets.Add(bullet);
	}
	
	void checkHits () {
		foreach (Bullet bullet in bullets) {
			checkHitFighter (bullet, playerFighter);
			foreach (Fighter enemy in enemies) {
				checkHitFighter(bullet, enemy);
			}
		}
	}
	
	void checkHitFighter (Bullet bullet, Fighter fighter) {
		if (bullet.collider.bounds.Intersects(fighter.collider.bounds)) {
			fighter.takeHit (bullet);
			bullet.hitTarget();
		}
	}
	
	// Handle Death //
	
	public void bulletDied (Bullet bullet) {
		deadBullets.Add (bullet);
	}
	
	public void fighterDied (Fighter fighter) {
		if (fighter.isPlayer) playerDied ();
		else deadEnemies.Add (fighter);
	}
	
	public void playerDied () {
		playerLives--;
		GameObject.Destroy(playerFighter.gameObject);
		if (playerLives < 0) endGame ();
		else playerFighter = FighterFactory.createPlayerFighter (Vector2.zero);
	}
	
	public void removeBullets () {
		foreach (Bullet bullet in deadBullets) {
			bullets.Remove(bullet);
			GameObject.Destroy(bullet.gameObject);
		}
		deadBullets.Clear();
	}
	
	public void removeEnemies () {
		foreach (Fighter fighter in deadEnemies) {
			enemies.Remove(fighter);
			GameObject.Destroy(fighter.gameObject);
		}
		deadEnemies.Clear();
	}
	
	// Game State //
	
	public void startGame () {
		spawnPlayer();
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
		enemies = new List<Fighter>();
		
		running = false;
	}
	
	// Utility //
	
	Fighter getFighterInfo (GameObject fighterObject) {
		return fighterObject.GetComponent("Fighter") as Fighter;
	}
	
}
