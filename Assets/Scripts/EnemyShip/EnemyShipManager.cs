using UnityEngine;
using System.Collections;

public class EnemyShipManager : Singleton<EnemyShipManager> {
	
	public float startWaveFrequency = 6f;
	public int bossBattleFrequency = 20;
	public GameObject[] normalEnemyPrefabs;
	public GameObject[] bossEnemyPrefabs;

	private int enemyWaveCount = 0;
	private int enemySpawnedCount = 0;
	private WaitForSeconds waveFreqWait;
	private Collider spawnArea;


	public void Start() {
		waveFreqWait = new WaitForSeconds(startWaveFrequency);
		spawnArea = GetComponent<Collider> ();

		// start the enemy waves after a few second wait
		StartCoroutine (BeginEnemyWaves ());
	}

	private IEnumerator BeginEnemyWaves() {
		// don't being spawning enemies until the game has had a few seconds to start
		yield return new WaitForSeconds(3.0f);

		// while the player is still alive keep spawning enemies
		while (GameManager.Instance.playerShip.IsAlive()) {

			// if we should do a boss battle then spawn a random boss, otherwise spawn a new wave of normal enemies 
			if (enemySpawnedCount >= bossBattleFrequency) {
				SpawnNewBossEnemy();
			}
			else {
				SpawnNewNormalEnemyWave();
			}

			// yield/wait the spawn frequency time
			yield return waveFreqWait;
		}
	}


	private void SpawnNewNormalEnemyWave() {
		enemyWaveCount++;

		// spawn one enemy for every wave we've spawned so far
		GameObject prefab;
		Vector3 pos;
		for (int i=0; i<enemyWaveCount; i++) {
			prefab = normalEnemyPrefabs[Random.Range(0, normalEnemyPrefabs.Length)];
			pos = GetEnemySpawnPos();
			Instantiate (prefab, pos, Quaternion.identity);
		}
	}

	private void SpawnNewBossEnemy() {
		if (bossEnemyPrefabs.Length < 1) return;

		GameObject prefab = bossEnemyPrefabs[Random.Range(0, bossEnemyPrefabs.Length)];
		Vector3 pos = GetEnemySpawnPos();
		Instantiate (prefab, pos, Quaternion.identity);
	}

	private Vector3 GetEnemySpawnPos() {
		// randomly pick a valid enemy spawn position
		if (spawnArea == null) return Vector3.zero;

		float x = Random.Range (spawnArea.bounds.min.x, spawnArea.bounds.max.x);
		float y = Random.Range (spawnArea.bounds.min.y, spawnArea.bounds.max.y);

		return new Vector3 (x, y, 0f);
	}
	
}
