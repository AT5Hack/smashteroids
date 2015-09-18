using UnityEngine;
using System.Collections;

public class EnemyShipKamakazeAI : EnemyShipBaseAI {

	private Vector3 playerPos;


	#region functions to be implemented/overriden
	// do any thinking and calculations about how to act this step
	protected override void Think() {
		// find the current player position
		playerPos = GameManager.Instance.playerShip.transform.position;
	}
	
	// do any movement after thinking this step
	protected override void Move() {
		// move towards the last remembered player position
		transform.position = Vector3.MoveTowards(transform.position, playerPos, ship.baseStats.speed * Time.deltaTime);
	}
	
	// do any shooting after thinking this step
	protected override void Shoot() {
		
	}
	#endregion functions to be implemented/overriden
}
