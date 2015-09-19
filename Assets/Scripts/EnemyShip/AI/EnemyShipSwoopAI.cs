using UnityEngine;
using System.Collections;

public class EnemyShipSwoopAI : EnemyShipBaseAI {

	public float swoopFreq = 2f;
	public float swoopMagnitude = 3f;

	private Vector3 movePos;
	private float randomRadians;

	public override void Start () {
		base.Start ();
	
		movePos = transform.position;
		// we'll add a random amount to the value that we'll take the Sin() of, so that all ships don't follow
		// the exact same sine wave.
		randomRadians = Random.value * 6.28318531f;
	}

	#region functions to be implemented/overriden
	// do any thinking and calculations about how to act this step
	protected override void Think() {

	}
	
	// do any movement after thinking this step
	protected override void Move() {
		movePos += Vector3.left * Time.deltaTime * ship.baseStats.moveSpeed;
		transform.position = movePos + Vector3.up * Mathf.Sin ((Time.time + randomRadians) * swoopFreq) * swoopMagnitude;
	}
	
	// do any shooting after thinking this step
	protected override void Shoot() {
		// load and instantiate the bullet
		var bulletPrefab = Resources.Load("EnemyBullet");
		var bulletGo = (GameObject) GameObject.Instantiate(bulletPrefab, ship.GetRandomGunPoint(), Quaternion.identity);
		var bullet = bulletGo.GetComponent<EnemyBullet>();
		
		if (bullet != null) {
			bullet.speed = ship.baseStats.bulletSpeed;
		}
	}
	#endregion functions to be implemented/overriden
}
