using UnityEngine;
using System.Collections;

public class EnemyShipKamakazeAI : EnemyShipBaseAI {

	private bool hasStartedKamakazeDive = false;


	#region abstract functions to be implemented
	// should we think this step
	protected override bool ShouldThink() {
		return true;
	}
	
	// should we move this step
	protected override bool ShouldMove() {
		return true;
	}
	
	// should we shoot this step
	protected override bool ShouldShoot() {
		return true;
	}
	
	// do any thinking and calculations about how to act this step
	protected override void Think() {
		
	}
	
	// do any movement after thinking this step
	protected override void Move() {
		
	}
	
	// do any shooting after thinking this step
	protected override void Shoot() {
		
	}
	#endregion abstract functions to be implemented
}
