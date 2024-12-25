using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int startingChunksAmount = 12;
    [SerializeField] Transform chunkParent;
    [SerializeField] float chunkLength = 10f;
    [SerializeField] float moveSpeed = 10f;

    List<GameObject> chunks = new List<GameObject>();

    private void Update()
    {
        ChunkMovement();
    }


    private void Start()
    {
        ChunkGenerator();
    }

    private void ChunkGenerator()
    {
        for (int i = 0; i < startingChunksAmount; i++)
        {
            GameObject newChunk = Instantiate(chunkPrefab, new Vector3(transform.position.x, transform.position.y, i * chunkLength), quaternion.identity, chunkParent);
            chunks.Add(newChunk);
        }
    }

    private void ChunkMovement()
    {
        float lastChunkPos = chunks[^1].transform.position.z;

        for (int i = 0; i < chunks.Count; i++)
        {
            GameObject chunk = chunks[i];
            chunks[i].transform.Translate(-transform.forward * (moveSpeed * Time.deltaTime));

            if (chunk.transform.position.z < -9)
            {
                chunks.Remove(chunk);
                Destroy(chunk);

                GameObject newChunk = Instantiate(chunkPrefab, new Vector3(transform.position.x, transform.position.y, lastChunkPos + 10), quaternion.identity, chunkParent);
                chunks.Add(newChunk);
            };
        }
    }
}
