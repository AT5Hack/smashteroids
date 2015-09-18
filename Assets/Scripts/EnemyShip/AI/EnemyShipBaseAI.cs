using UnityEngine;
using System.Collections;

// this gameobject requires a component of type EnemyShip
[RequireComponent (typeof (EnemyShip))]
public abstract class EnemyShipBaseAI : MonoBehaviour {

	protected float lastThinkTime;
	protected float lastMoveTime;
	protected float lastShootTime;

	protected EnemyShip ship;


	public virtual void Start() {
		ship = GetComponent<EnemyShip> ();
	}

	public void Brain() {
		if (ShouldThink()) Think ();
		if (ShouldMove()) Move ();
		if (ShouldShoot()) Shoot ();
	}


	#region functions to be implemented/overriden
	// should we move this step
	protected virtual bool ShouldMove() {
		bool result = (ship.baseStats.moveRate >= 0 && (lastMoveTime + ship.baseStats.moveRate) <= Time.time);
		if (result) lastMoveTime = Time.time;
		return result;
	}
	
	// should we shoot this step
	protected virtual bool ShouldShoot() {
		bool result = (ship.baseStats.firingRate >= 0 && (lastShootTime + ship.baseStats.firingRate) <= Time.time);
		if (result) lastShootTime = Time.time;
		return result;
	}
	
	// do any thinking and calculations about how to act this step
	protected virtual bool ShouldThink() {
		bool result = (ship.baseStats.thinkRate >= 0 && (lastThinkTime + ship.baseStats.thinkRate) <= Time.time);
		if (result) lastThinkTime = Time.time;
		return result;
	}

	// do any thinking about how to act this step
	protected abstract void Think();

	// do any movement after thinking this step
	protected abstract void Move();

	// do any shooting after thinking this step
	protected abstract void Shoot();
	#endregion functions to be implemented/overriden
}
