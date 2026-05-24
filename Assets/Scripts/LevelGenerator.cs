using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int StartChunkAmount = 12;
    [SerializeField] Transform chunkParent;
    [SerializeField] float ChunkStartingLength = 10f;
    [SerializeField]  float ChunkMoveSpeed = 8f;


    List<GameObject> chunks = new List<GameObject>();

    void Start()
    {
        SpawnStartingChunks();

    }
    void Update()
    {
        MoveChunks();
    }
    void SpawnStartingChunks()
    {
        for (int i = 0; i < StartChunkAmount; i++)
        {
            IncreaseChunk();
        }
    }

    private void IncreaseChunk()
    {
        float spawnPositionZ = CalculateSpawnPositionZ();

        Vector3 ChunkSpawnPosition = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
        GameObject newChunks = Instantiate(chunkPrefab, ChunkSpawnPosition, Quaternion.identity, chunkParent);
        chunks.Add(newChunks);
    }

    float CalculateSpawnPositionZ()
    {
        float spawnPositionZ;
          
        if (chunks.Count == 0)
        {
            spawnPositionZ = transform.position.z;
        }
        else
        {
            spawnPositionZ = chunks[chunks.Count - 1].transform.position.z + ChunkStartingLength;
        }

        return spawnPositionZ;
    }

    void MoveChunks()
    {
        for (int i = 0; i < chunks.Count; i++)
        {
            GameObject chunk = chunks[i];
            chunk.transform.Translate(-transform.forward * (ChunkMoveSpeed * Time.deltaTime));

            if (chunks.Count > 0)
            {
                if (chunk.transform.position.z <= Camera.main.transform.position.z - ChunkStartingLength)
                {

                    chunks.Remove(chunk);
                    Destroy(chunk);
                    SpawnStartingChunks();

                }
            }
        }
       
    }

}
