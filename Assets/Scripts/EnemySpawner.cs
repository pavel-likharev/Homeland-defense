using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] WaveConfigSO currentWave;

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }


    void Start()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        Instantiate(currentWave.GetEnemyPrefab(0), currentWave.GetStartingWaypoint().position, Quaternion.identity); 
    }
}
