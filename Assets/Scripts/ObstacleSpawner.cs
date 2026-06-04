using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] float ObstacleSpawnInterval = 2f;
    [SerializeField] Transform ObstacleParent;
    [SerializeField] float SpawnWidth = 3f;

    void Start()
    {
        StartCoroutine(SpawnObstacleRoutin());
    }

    IEnumerator SpawnObstacleRoutin()
    {
        while (true)
        {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(-SpawnWidth, SpawnWidth), transform.position.y, transform.position.z);
            yield return new WaitForSeconds(ObstacleSpawnInterval);
            Instantiate(obstaclePrefab, spawnPosition, Random.rotation, ObstacleParent);
           
        }
    }
}
