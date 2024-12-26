using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject applePrefab;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] float[] lanes = { -2.5f, 0f, 2.5f };
    [SerializeField] float appleSpawnChance = .3f;

    List<int> availableLanes = new List<int> { 0, 1, 2 };

    private void Start()
    {
        SpawnFences();
        SpawnApple();
        SpawnCoin();
    }

    void SpawnFences()
    {
        int fencesToSpawn = Random.Range(0, 3);

        for (int i = 0; i < fencesToSpawn; i++)
        {
            int selectedLane = SelectLane();
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }


    void SpawnApple()
    {
        if (Random.value > appleSpawnChance || availableLanes.Count <= 0) return;
        int selectedLane = SelectLane();

        Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
        Instantiate(applePrefab, spawnPosition, Quaternion.identity, this.transform);
    }

    void SpawnCoin()
    {
        if (Random.value > appleSpawnChance || availableLanes.Count <= 0) return;
        int selectedLane = SelectLane();

        Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity, this.transform);
    }

    int SelectLane()
    {
        int randomIndex = Random.Range(0, availableLanes.Count);
        int selectedLane = availableLanes[randomIndex];
        availableLanes.RemoveAt(randomIndex);
        return selectedLane;
    }
}
