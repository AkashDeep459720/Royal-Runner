using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float ObstacleSpawnInterval = 2f;

    int ObstacleSpawned = 0;
    void Start()
    {
        StartCoroutine(SpawnObstacleRoutin());
    }

    IEnumerator SpawnObstacleRoutin()
    {
        while (ObstacleSpawned < 5)
        {
            yield return new WaitForSeconds(ObstacleSpawnInterval);
            Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
            ObstacleSpawned++;
        }
    }
}
