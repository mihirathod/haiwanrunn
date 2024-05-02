using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclesSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float spawnpos;
    public float Delay;
    public float spwnInterval;

    void Start()
    {
        InvokeRepeating("Spawner", Delay, spwnInterval);
    }
    public void Spawner()
    {
        Vector3 Spwnpos = new Vector3(0, 0, spawnpos);
        int ObstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        Instantiate(obstaclePrefabs[ObstacleIndex], Spwnpos,obstaclePrefabs[ObstacleIndex].transform.rotation);
    }
}
