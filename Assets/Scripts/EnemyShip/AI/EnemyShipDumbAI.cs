using UnityEngine;
using System.Collections;

public class EnemyShipDumbAI : EnemyShipBaseAI {

	#region functions to be implemented/overriden
	// should we think this step
	protected override bool ShouldThink() {
		return false;
	}
	
	// should we shoot this step
	protected override bool ShouldShoot() {
		return false;
	}
	
	// do any thinking and calculations about how to act this step
	protected override void Think() {

	}
	
	// do any movement after thinking this step
	protected override void Move() {
		// simply move to the left at a constant speed
		transform.Translate(Vector3.left * ship.baseStats.speed * Time.deltaTime);
	}
	
	// do any shooting after thinking this step
	protected override void Shoot() {

	}
	#endregion functions to be implemented/overriden
}