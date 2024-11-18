using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO currentWave;

    void Start()
    {
        if (currentWave != null)
        {
            StartCoroutine(SpawnEnemies());
        }
        else
        {
            Debug.LogError("Wave configuration not assigned.");
        }
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < currentWave.GetEnemyCount(); i++)
        {
            GameObject enemy = currentWave.GetEnemyPrefab(i);
            if (enemy != null)
            {
                Instantiate(enemy, currentWave.GetStartingWaypoint().position, Quaternion.identity, transform);
            }
            yield return new WaitForSeconds(1f); // Example delay between spawns
        }
    }
}