﻿using UnityEngine;
using System.Collections;

public class Fighter : MonoBehaviour {
	
	// Stats
	public int health = 0;
	public int maxHealth = 0;
	public float speed = 0;
	public string weapon = "";
	
	// Movement
	public Vector2 position;
	bool left = false, right = false, up = false, down = false;
	
	// Combat
	bool firing = false;
	float lastTimeFired = 0f;
	public bool dead = false;

	// Game Communication
	GameController game;
	public bool isPlayer = false;
	public string type = "";

	// Use this for initialization
	void Start () {
		game = GameObject.Find("Application").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	
	void Update () {
		if (game.running) {
			if (health <= 0) callDeath ();
			move ();
			tryToFire ();
		}
	}
	
	// Movement //
	
	void move () {
		if (left) position.x -= speed * Time.deltaTime;
		if (right) position.x += speed * Time.deltaTime;
		if (up) position.y += speed * Time.deltaTime;
		if (down) position.y -= speed * Time.deltaTime;
		
		changeRotation ();
		checkOutOfBounds ();
		
		transform.position = new Vector3(position.x,transform.position.y,position.y);
	}
	
	void changeRotation () {
		transform.rotation = Quaternion.identity;
		if (left) transform.Rotate (Vector3.forward * 30);
		if (right) transform.Rotate (Vector3.back * 30);
	}
	
	void checkOutOfBounds () {
		if (position.x < GameConstants.StageBoundingBox.x)
			position.x = GameConstants.StageBoundingBox.x;
		if (position.x > GameConstants.StageBoundingBox.z)
			position.x = GameConstants.StageBoundingBox.z;
		if (position.y < GameConstants.StageBoundingBox.y)
			position.y = GameConstants.StageBoundingBox.y;
		if (position.y > GameConstants.StageBoundingBox.w)
			position.y = GameConstants.StageBoundingBox.w;
			
	}	
	
	// Combat //
	void tryToFire () {
		float firingSpeed = float.Parse(CharacterConstants.weapons[weapon]["firingSpeed"]);
		if (firing && Time.time - lastTimeFired > firingSpeed) {
			fire ();
		}
	}
	
	void fire () {
		lastTimeFired = Time.time;
		//Create bullet
		string bulletType = CharacterConstants.weapons[weapon]["bullet"];
		Bullet bullet = BulletFactory.createBullet(bulletType,this.gameObject);
		CombatHandler.bullets.Add(bullet);
	}
	
	public void takeHit (Bullet bullet) {
		takeDamage (bullet.damage);
	}
	
	void takeDamage(int damage) {
		health -= damage;
	}
	
	void callDeath () {
		game.fighterDied (this);
	}
	
	// Public Functions//
	
	public void setMovement(string direction, bool truth) {
		if (direction == "up") up = truth;
		if (direction == "down") down = truth;
		if (direction == "left") left = truth;
		if (direction == "right") right = truth;
	}
	
	public void setFiring (bool setting) {
		firing = setting;
	}
}
