using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 4f;
    [SerializeField] bool isLooping = true;
    
    WaveConfigSO currentWave;
    
    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    void Start()
    { 
        currentWave = waveConfigs[0];
        StartCoroutine(CallWaves());
    }

    

    IEnumerator SpawnEnemy(WaveConfigSO currentWave)
    {
        float spawnTime = currentWave.GetRandomSpawnTime();

        for (int i = 0; i < currentWave.GetEnemyCount(); i++)
        {
            Instantiate(currentWave.GetEnemyPrefab(0), currentWave.GetStartingWaypoint().position, Quaternion.identity, transform);
            
            yield return new WaitForSeconds(spawnTime);
        }
    }

    IEnumerator CallWaves()
    {
        do
        {
            for (int i = 0; i < waveConfigs.Count; i++)
            {
                currentWave = waveConfigs[i];
                StartCoroutine(SpawnEnemy(currentWave));

                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }
        while (isLooping);

    }

}
