using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    void Awake()
    {
        // Ensure the enemySpawner is correctly found and referenced.
        enemySpawner = FindObjectOfType<EnemySpawner>();
        if (enemySpawner == null)
        {
            Debug.LogError("EnemySpawner not found in the scene.");
        }
    }

    void Start()
    {
        waveConfig = enemySpawner?.GetCurrentWave();
        if (waveConfig != null)
        {
            waypoints = waveConfig.GetWaypoints();
            if (waypoints != null && waypoints.Count > 0)
            {
                transform.position = waypoints[waypointIndex].position;
            }
            else
            {
                Debug.LogError("Waypoints not set up correctly.");
            }
        }
        else
        {
            Debug.LogError("Wave configuration is missing.");
        }
    }

    void Update()
    {
        if (waypoints != null && waypoints.Count > 0)
        {
            FollowPath();
        }
    }

    void FollowPath()
    {
        if (waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);

            if (Vector2.Distance(transform.position, targetPosition) < 0.01f)
            {
                waypointIndex++;
            }
        }
        else
        {
            // Safely destroy the object after reaching the final waypoint
            Destroy(gameObject);
        }
    }
}