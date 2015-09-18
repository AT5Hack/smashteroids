using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {

	private PlayerShip mPlayerShip;
	public PlayerShip playerShip {
		get { return mPlayerShip; }
	}


	// Use this for initialization
	void Start () {
		mPlayerShip = FindObjectOfType<PlayerShip> ();
	}

}
