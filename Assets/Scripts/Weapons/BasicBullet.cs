using UnityEngine;
using System.Collections;

public class BasicBullet : Bullet {

	// Use this for initialization
	new void Start () {
		base.Start();
		damage = 10;
		speed = 20;
		decayTime = 2;
	}
	
}
