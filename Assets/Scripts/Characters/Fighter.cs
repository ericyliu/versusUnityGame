using UnityEngine;
using System.Collections;

public class Fighter : MonoBehaviour {
	public int id;
	//Stats
	public int health = 0;
	public int maxHealth = 0;
	public float speed = 0;
	public float firingSpeed = 0; //ms
	public string weapon = "";
	//Movement
	Vector2 position;
	int rotation = 0;
	bool left = false, right = false, up = false, down = false;
	//Combat
	bool firing = false;
	float lastTimeFired = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) callDeath ();
		move ();
		tryToFire ();
	}
	
	// Movement //
	
	void move () {
		if (left) position.x -= speed * Time.deltaTime;
		if (right) position.x += speed * Time.deltaTime;
		if (up) position.y += speed * Time.deltaTime;
		if (down) position.y -= speed * Time.deltaTime;
		
		transform.position = new Vector3(position.x,position.y,transform.position.z);
	}
	
	// Combat //
	
	void tryToFire () {
		if (firing && Time.time - lastTimeFired > firingSpeed) {
			fire ();
		}
	}
	
	void fire () {
		lastTimeFired = Time.time;
		//Create bullet
	}
	
	void takeDamage(int damage) {
		health -= damage;
	}
	
	void callDeath () {
		//Play death animation
		
		//Report death
		(GameObject.Find("GameMaster").GetComponent("GameController") as GameController).fighterDied (id);
	}
	
	// Public Functions//
	
	public void setMovement(string direction, bool truth) {
		if (direction == "up") up = truth;
		if (direction == "down") down = truth;
		if (direction == "left") left = truth;
		if (direction == "right") right = truth;
	}
}
