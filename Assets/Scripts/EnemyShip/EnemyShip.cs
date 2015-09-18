using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour {

	public float maxHealth = 100f;
	public float currentHealth = 100f;

	public EnemyShipBaseAI AI;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (AI != null) {
			AI.Brain();
		}
	}

	public bool IsAlive() {
		return (currentHealth > 0f);
	}
}
