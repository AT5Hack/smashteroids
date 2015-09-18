using UnityEngine;
using System.Collections;
using System;

public class Tweakables : Singleton<Tweakables> {
	
	public PlayerTweaks player;
	public EnemyTweaks enemies;


	#region player stuff
	[Serializable]
	public class PlayerTweaks {
		public float speed;
		public int hp;
		public int lives;
		public int bulletSpeed;
	}
	#endregion


	#region enemy stuff
	public enum EnemyType {
		NONE,
		DUMB,
		SWOOP,
		KAMAKAZE
	}

	[Serializable]
	public class EnemyTweaks
	{
		public DumbEnemyShip dumb;
		public SwoopEnemyShip swoop;
		public KamakazeEnemyShip kamakaze;
	}

	[Serializable]
	public abstract class BaseEnemyStats {
		public float speed;
		public int hp;
		public float firingRate;

	}

	[Serializable] public class DumbEnemyShip : BaseEnemyStats {}
	[Serializable] public class SwoopEnemyShip : BaseEnemyStats {}
	[Serializable] public class KamakazeEnemyShip : BaseEnemyStats {}

	public BaseEnemyStats GetEnemyStatsForEnemy(EnemyType et) {
		switch (et) {
		case EnemyType.SWOOP:
			return enemies.swoop;
		case EnemyType.KAMAKAZE:
			return enemies.kamakaze;
		case EnemyType.NONE:
		case EnemyType.DUMB:
		default:
			return enemies.dumb;
		}
	}
	#endregion enemy stuff
	
}
