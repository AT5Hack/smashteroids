using UnityEngine;
using System.Collections;

public class EnemyShipManager : Singleton<EnemyShipManager> {
	
	public float startWaveFrequency = 5f;
	public int bossBattleFrequency = 20;
	public GameObject[] normalEnemyPrefabs;
	public GameObject[] bossEnemyPrefabs;

	private int enemyWaveCount = 0;
	private int enemySpawnedCount = 0;
	private WaitForSeconds waveFreqWait;


	public void Start() {
		// start the enemy waves after a few second wait
		StartCoroutine (BeginEnemyWaves ());
		waveFreqWait = new WaitForSeconds(startWaveFrequency);
	}

	private IEnumerator BeginEnemyWaves() {
		// don't being spawning enemies until the game has had a few seconds to start
		yield return new WaitForSeconds(3.0f);

		// while the player is still alive keep spawning enemies


		// if we should do a boss battle then spawn a random boss, otherwise spawn a new wave of normal enemies 
		if (enemySpawnedCount >= bossBattleFrequency) {
			SpawnNewBossEnemy();

		}

		// yield/wait the spawn frequency time
		yield return waveFreqWait;
	}


	private void SpawnNewNormalEnemyWave() {
		enemyWaveCount++;


	}

	private void SpawnNewBossEnemy() {
		
		
	}
	
}
