using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 0.9f;

    public Transform GetStartingWaypoint()
    {
        if (pathPrefab != null && pathPrefab.childCount > 0)
        {
            return pathPrefab.GetChild(0);
        }
        else
        {
            Debug.LogError("Path prefab is not set or has no children.");
            return null;
        }
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        if (pathPrefab != null)
        {
            foreach (Transform child in pathPrefab)
            {
                waypoints.Add(child);
            }
        }
        else
        {
            Debug.LogError("Path prefab is not assigned.");
        }
        return waypoints;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        if (index >= 0 && index < enemyPrefabs.Count)
        {
            return enemyPrefabs[index];
        }
        else
        {
            Debug.LogError("Index out of range");
            return null;
        }
    }
}
