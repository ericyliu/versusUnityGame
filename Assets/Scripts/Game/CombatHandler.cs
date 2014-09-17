using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class CombatHandler {

	public static List<Bullet> bullets = new List<Bullet>();
	static List<Bullet> deadBullets = new List<Bullet>();
	
	static GameController game = GameObject.Find ("Application").GetComponent<GameController>();
	

	public static void checkHits () {
		foreach (Bullet bullet in bullets) {
			checkHitFighter (bullet, game.playerFighter);
			foreach (Fighter enemy in EnemyHandler.enemies) {
				checkHitFighter(bullet, enemy);
			}
		}
	}
	
	static void checkHitFighter (Bullet bullet, Fighter fighter) {
		if (bullet.collider.bounds.Intersects(fighter.collider.bounds)) {
			fighter.takeHit (bullet);
			bullet.hitTarget();
		}
	}
	
	// Handle Death //
	
	public static void bulletDied (Bullet bullet) {
		deadBullets.Add (bullet);
	}
	
	public static void removeBullets () {
		foreach (Bullet bullet in deadBullets) {
			bullets.Remove(bullet);
			GameObject.Destroy(bullet.gameObject);
		}
		deadBullets.Clear();
	}
	
}
