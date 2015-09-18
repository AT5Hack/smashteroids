using UnityEngine;
using System.Collections;

public class EnemyShipSwoopAI : EnemyShipBaseAI {

	public float swoopFreq = 2f;
	public float swoopMagnitude = 3f;

	private Vector3 movePos;

	public override void Start () {
		base.Start ();
	
		movePos = transform.position;
	}

	#region functions to be implemented/overriden
	// do any thinking and calculations about how to act this step
	protected override void Think() {

	}
	
	// do any movement after thinking this step
	protected override void Move() {
		movePos += Vector3.left * Time.deltaTime * ship.baseStats.speed;
		transform.position = movePos + Vector3.up * Mathf.Sin (Time.time * swoopFreq) * swoopMagnitude;
	}
	
	// do any shooting after thinking this step
	protected override void Shoot() {

	}
	#endregion functions to be implemented/overriden
}
