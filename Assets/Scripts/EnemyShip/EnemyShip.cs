using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour {

	private int hp;
	private int damageTaken;

	private EnemyShipBaseAI AI;


	// Use this for initialization
	void Start () {
		AI = GetComponent<EnemyShipBaseAI> ();
	}
	
	// Update is called once per frame
	void Update () {
		// check if we should die
		if (damageTaken >= hp) {
			Die();
		}

		// Do AI stuff
		if (AI != null) {
			AI.Brain();
		}
	}

	public bool IsAlive() {
		return (damageTaken < hp);
	}

	private void Die() {
		Dispatcher.FireEvent (this, new EnemyDeathEvent ());
	}
}
