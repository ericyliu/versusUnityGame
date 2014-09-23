using UnityEngine;
using System.Collections;

public static class BulletFactory {

	public static Bullet createBullet (string weapon, GameObject fighter) {
		Bullet bullet = null;
		if (weapon == "BasicBullet") bullet = createBasicBullet (fighter);
		else Debug.LogError ("No such weapon exists");
		return bullet;
	}

	public static Bullet createBasicBullet (GameObject fighter) {
		Vector3 position = calculatePosition(fighter, 1f);
		GameObject bulletObject = loadMesh (position);
		loadMaterial (bulletObject, "Materials/BasicBullet");
		bulletObject.name = "basicBullet";
		
		Bullet bullet = bulletObject.AddComponent<BasicBullet>();
		bullet.direction = (position - fighter.transform.position).normalized;
		return bullet;
	}

	static Vector3 calculatePosition (GameObject fighter, float bulletSize) {
		Vector3 position = fighter.transform.position 
						+ (Vector3.Scale (fighter.transform.forward, 
										  fighter.collider.bounds.extents + 
										  new Vector3(bulletSize,bulletSize,bulletSize)));
		return position;
	}
	
	static GameObject loadMesh (Vector3 position) {
		GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Cube);
		bullet.transform.localScale /= 2;
		bullet.transform.position = position;
		return bullet;
	}
	
	static void loadMaterial (GameObject bullet, string source) {
		MeshRenderer bulletRenderer = bullet.GetComponent<MeshRenderer>();
		bulletRenderer.material = Resources.Load (source,typeof(Material)) as Material;
	}
			
}
