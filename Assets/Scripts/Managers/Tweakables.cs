using UnityEngine;
using System.Collections;
using System;

public class Tweakables : Singleton<Tweakables> {

	public PlayerTweaks player;

	[Serializable]
	public class PlayerTweaks {
		public float speed;
		public int hp;
		public int lives;
		public int bulletSpeed;
	}
	
}
