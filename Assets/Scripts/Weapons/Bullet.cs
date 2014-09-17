using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed;
	public int damage;
	public float decayTime;
	
	public bool dead = false;
	
	float startTime;
	
	public Vector3 direction;
	
	GameController game;
	
	// Use this for initialization
	protected void Start () {
		game = GameObject.Find("Application").GetComponent<GameController>();
		startTime = Time.time;
		
		// Default values
		direction = Vector3.forward;
	}
	
	// Update is called once per frame
	void Update () {
		if (game.running) {
			move();
			checkDecay();
		} 
	}
	
	// Combat
	void checkDecay () {
		if (Time.time - startTime >= decayTime) removeBullet();
	}
	
	public void hitTarget () {
		Debug.Log("Hit target");
		removeBullet ();
	}
				
	void removeBullet () {
		game.bulletDied(this);
	}
	
	// Movement
	void move () {
		transform.Translate(direction * speed * Time.deltaTime);
	}
}
