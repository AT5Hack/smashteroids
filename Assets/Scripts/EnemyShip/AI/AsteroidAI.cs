using UnityEngine;
using System.Collections;

public class AsteroidAI : EnemyShipBaseAI {

	private bool reverse = false;
	
	public override void Start () {
		base.Start ();
		
		// Some asteroids will move in the opposite direction, coming in from behind the player
		reverse = Random.value < 0.1;
		if (reverse) transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
    }
    
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
		if (reverse) {
			transform.Translate(Vector3.right * ship.baseStats.speed * 0.5f * Time.deltaTime);
        }
		else {
			transform.Translate(Vector3.left * ship.baseStats.speed * Time.deltaTime);
		}
	}
	
	// do any shooting after thinking this step
	protected override void Shoot() {
		
	}
	#endregion functions to be implemented/overriden
}
