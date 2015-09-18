using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour {

	public Tweakables.EnemyType enemyType = Tweakables.EnemyType.NONE;
	public GameObject gunPoint;

	private Tweakables.BaseEnemyStats mBaseStats;
	public Tweakables.BaseEnemyStats baseStats {
		get { return mBaseStats; }
	}
	
	private int damageTaken;
	private Transform[] gunPoints;
	private EnemyShipBaseAI AI;


	// Use this for initialization
	void Start () {
		mBaseStats = Tweakables.Instance.GetEnemyStatsForEnemy (enemyType);
		AI = GetComponent<EnemyShipBaseAI> ();
		if (gunPoint != null) {
			gunPoints = gunPoint.GetComponentsInChildren<Transform> ();
		}
	}
	
	// Update is called once per frame
	void Update () {

		// Do AI stuff
		if (AI != null) {
			AI.Brain();
		}
	}

	public bool IsAlive() {
		return (damageTaken < baseStats.hp);
	}

	private void Die() {
		Dispatcher.FireEvent<EnemyDeathEvent> (this, new EnemyDeathEvent (this));
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		DamageEnemy hazard = collider.GetComponent<DamageEnemy> ();
		
		if (hazard != null) {
			damageTaken += hazard.damage;
			
			if (damageTaken >= baseStats.hp) {
				Die();
			}
		}
	}

	public Vector3 GetRandomGunPoint() {
		if (gunPoints == null) return transform.position;

		return gunPoints [Random.Range (0, gunPoints.Length)].position;
	}
}
