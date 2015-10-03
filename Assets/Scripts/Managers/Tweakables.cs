using UnityEngine;
using System.Collections;
using System;

public class Tweakables : Singleton<Tweakables> {
	
	public PlayerTweaks player;
	public EnemyTweaks enemies;

	public bool useAllEnemies = false;


	#region player stuff
	[Serializable]
	public class PlayerTweaks {
		public float speed;
		public int hp;
		public int bulletSpeed;
		public float fireSpeed;
	}
	#endregion


	#region enemy stuff
	public enum EnemyType {
		NONE,
		STUDENT,
		SWOOP,
		KAMAKAZE,
		ASTEROID
	}

	[Serializable]
	public class EnemyTweaks
	{
		public StudentEnemyShip student;
		public SwoopEnemyShip swoop;
		public KamakazeEnemyShip kamakaze;
		public AsteroidEnemy asteroid;
	}

	[Serializable]
	public abstract class BaseEnemyStats {
		public float moveSpeed;
		public float bulletSpeed;
		public int hp;
		public float firingRate;
		public float thinkRate;
		public float moveRate;
	}

	[Serializable] public class StudentEnemyShip : BaseEnemyStats {}
	[Serializable] public class SwoopEnemyShip : BaseEnemyStats {}
	[Serializable] public class KamakazeEnemyShip : BaseEnemyStats {}
	[Serializable] public class AsteroidEnemy : BaseEnemyStats {}

	public BaseEnemyStats GetEnemyStatsForEnemy(EnemyType et) {
		switch (et) {
		case EnemyType.SWOOP:
			return enemies.swoop;
		case EnemyType.KAMAKAZE:
			return enemies.kamakaze;
		case EnemyType.ASTEROID:
			return enemies.asteroid;
		case EnemyType.NONE:
		case EnemyType.STUDENT:
		default:
			return enemies.student;
		}
	}
	#endregion enemy stuff
	
}
