using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyShipManager : Singleton<EnemyShipManager> {
	
	public float waveCheckFreq = 1f;
	public float minWaveFreqWait = 5f;
	public int bossBattleFrequency = 20;
	public GameObject[] normalEnemyPrefabs;
	public GameObject[] bossEnemyPrefabs;

	private float lastSpawnTime;
	private int enemyWaveCount = 0;
	private int enemySpawnedCount = 0;
	private bool isWaveComplete = true;
	private WaitForSeconds waveFreqWait;
	private Collider spawnArea;

	private List<EnemyShip> currentWaveEnemies = new List<EnemyShip>();


	public void Start() {
		waveFreqWait = new WaitForSeconds(waveCheckFreq);
		spawnArea = GetComponent<Collider> ();

		Dispatcher.Subscribe<EnemyDeathEvent>(OnEnemyDeath);

		// start the enemy waves after a few second wait
		StartCoroutine (BeginEnemyWaves ());
	}

	private IEnumerator BeginEnemyWaves() {
		// don't being spawning enemies until the game has had a few seconds to start
		yield return new WaitForSeconds(3.0f);

		// while the player is still alive keep spawning enemies
		while (GameManager.Instance.playerShip.IsAlive()) {

			if (ShouldBeginNewWave()) {

				// if we should do a boss battle then spawn a random boss, otherwise spawn a new wave of normal enemies 
				if (enemySpawnedCount >= bossBattleFrequency) {
					enemySpawnedCount = 0;
					SpawnNewBossEnemy();
				}
				else {

					if (Tweakables.Instance.useAllEnemies) {
						// for progressively harder and bigger waves
						SpawnNewNormalEnemyWave();
					}
					else {
						// spawn one simple enemy for now
						SpawnSimpleNormalEnemyWave();
					}
				}
			}

			// yield/wait the spawn frequency time
			yield return waveFreqWait;
		}
	}

	private bool ShouldBeginNewWave() {
		// start a new wave if we are stil alive and if we the last wave is complete or the min wait time as elapsed
		return (GameManager.Instance.playerShip.IsAlive() && (isWaveComplete || (Time.time-lastSpawnTime) >= minWaveFreqWait));
	}

	private void SpawnSimpleNormalEnemyWave() {
		isWaveComplete = false;
		lastSpawnTime = Time.time;
		enemyWaveCount++;
		currentWaveEnemies.Clear ();
		
		// spawn one simple enemy
		GameObject prefab;
		GameObject clone;
		Vector3 pos;
		prefab = normalEnemyPrefabs[0];
		pos = GetEnemySpawnPos();
		clone = Instantiate (prefab, pos, Quaternion.identity) as GameObject;
		currentWaveEnemies.Add (clone.GetComponent<EnemyShip>());
	}

	private void SpawnNewNormalEnemyWave() {
		isWaveComplete = false;
		lastSpawnTime = Time.time;
		enemyWaveCount++;
		currentWaveEnemies.Clear ();

		// spawn one enemy for every wave we've spawned so far
		GameObject prefab;
		GameObject clone;
		Vector3 pos;
		for (int i=0; i<enemyWaveCount; i++) {
			prefab = normalEnemyPrefabs[Random.Range(0, normalEnemyPrefabs.Length)];
			pos = GetEnemySpawnPos();
			clone = Instantiate (prefab, pos, Quaternion.identity) as GameObject;
			currentWaveEnemies.Add (clone.GetComponent<EnemyShip>());
		}
	}

	private void SpawnNewBossEnemy() {
		if (bossEnemyPrefabs.Length < 1) return;

		isWaveComplete = false;
		lastSpawnTime = Time.time;

		GameObject prefab = bossEnemyPrefabs[Random.Range(0, bossEnemyPrefabs.Length)];
		Vector3 pos = GetEnemySpawnPos();
		Instantiate (prefab, pos, Quaternion.identity);

		// make it require more spawns before doing the next boss battle
		bossBattleFrequency += 10;
	}

	private Vector3 GetEnemySpawnPos() {
		// randomly pick a valid enemy spawn position
		if (spawnArea == null) return Vector3.zero;

		float x = Random.Range (spawnArea.bounds.min.x, spawnArea.bounds.max.x);
		float y = Random.Range (spawnArea.bounds.min.y, spawnArea.bounds.max.y);

		return new Vector3 (x, y, 0f);
	}

	public void OnEnemyDeath (object sender, EnemyDeathEvent ev) {
		if (currentWaveEnemies.Contains (ev.ship)) {
			currentWaveEnemies.Remove (ev.ship);
		}

		if (currentWaveEnemies.Count < 1) {
			isWaveComplete = true;
		}
	}
	
}
