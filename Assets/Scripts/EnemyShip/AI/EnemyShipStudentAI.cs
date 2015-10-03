using UnityEngine;
using System.Collections;

public class EnemyShipStudentAI : EnemyShipBaseAI {

	#region functions to be implemented/overriden
	// do any thinking and calculations about how to act this step
	protected override void Think() {

	}
	
	// do any movement after thinking this step
	protected override void Move() 
	{
		// simply move to the left at a constant speed
		transform.Translate(Vector3.left * ship.baseStats.moveSpeed * Time.deltaTime);
	}
	
	// do any shooting after thinking this step
	protected override void Shoot() {

		// load the bullet prefab
		var bulletPrefab = Resources.Load("EnemyBullet");

		// create an instance of that prefab as a game object in the scene.   
		// The ship.GetRandomGunPoint() gets a location in 3D world space where the bullet will spawn
		// The third parameter is the rotation of the object...don't wory about it
		var bulletGo = (GameObject) GameObject.Instantiate(bulletPrefab, ship.GetRandomGunPoint(), Quaternion.identity);

		// Obtain the Enemy Bullet script component of the new game object so we can interact with it
		var bullet = bulletGo.GetComponent<EnemyBullet>();

		if (bullet != null) {
			// Set the speed of the bullet to match the value configured for the ship in Tweakables
			bullet.speed = ship.baseStats.bulletSpeed;
		}
	}
	#endregion functions to be implemented/overriden
}