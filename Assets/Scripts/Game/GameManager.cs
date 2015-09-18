using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {

	private PlayerShip playerShip;


	// Use this for initialization
	void Start () {
		playerShip = FindObjectOfType<PlayerShip> ();
	}

}
