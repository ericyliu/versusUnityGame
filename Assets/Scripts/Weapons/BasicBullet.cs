using UnityEngine;
using System.Collections;

public class BasicBullet : Bullet {

	// Use this for initialization
	new void Start () {
		damage = 5;
		speed = 20;
		decayTime = 2;
		base.Start();
	}
	
}
