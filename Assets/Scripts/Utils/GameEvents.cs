using UnityEngine;
using System.Collections;
using System;

public class PlayerDeathEvent : EventArgs {

}

public class EnemyDeathEvent : EventArgs {

	public EnemyShip ship;

	public EnemyDeathEvent(EnemyShip s) {
		ship = s;
	}
}

