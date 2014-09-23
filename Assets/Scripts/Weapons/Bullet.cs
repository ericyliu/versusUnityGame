using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed;
	public int damage;
	public float decayTime;
	
	public bool dead = false;
	
	float startTime;
	
	public Vector3 direction = Vector3.forward;
	
	GameController game;
	
	// Use this for initialization
	protected void Start () {
		game = GameObject.Find("Application").GetComponent<GameController>();
		startTime = Time.time;
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
		removeBullet ();
	}
				
	void removeBullet () {
		CombatHandler.bulletDied(this);
	}
	
	// Movement
	void move () {
		transform.Translate(direction * speed * Time.deltaTime);
	}
}
