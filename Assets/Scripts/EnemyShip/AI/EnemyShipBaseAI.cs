using UnityEngine;
using System.Collections;

// this gameobject requires a component of type EnemyShip
[RequireComponent (typeof (EnemyShip))]
public abstract class EnemyShipBaseAI : MonoBehaviour {

	protected float lastThinkTime;
	protected float lastMoveTime;
	protected float lastShootTime;

	private EnemyShip ship;


	public virtual void Start() {
		ship = GetComponent<EnemyShip> ();
	}

	public void Brain() {
		if (ShouldThink()) Think ();
		if (ShouldMove()) Move ();
		if (ShouldShoot()) Shoot ();
	}


	#region abstract functions to be implemented
	// should we think this step
	protected abstract bool ShouldThink();
	
	// should we move this step
	protected abstract bool ShouldMove();
	
	// should we shoot this step
	protected abstract bool ShouldShoot();

	// do any thinking about how to act this step
	protected abstract void Think();

	// do any movement after thinking this step
	protected abstract void Move();

	// do any shooting after thinking this step
	protected abstract void Shoot();
	#endregion abstract functions to be implemented
}
