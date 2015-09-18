using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {

	public Collider2D boundary;

	private PlayerShip mPlayerShip;
	public PlayerShip playerShip {
		get { return mPlayerShip; }
	}


	// Use this for initialization
	void Start () {
		mPlayerShip = FindObjectOfType<PlayerShip> ();
	}

}
