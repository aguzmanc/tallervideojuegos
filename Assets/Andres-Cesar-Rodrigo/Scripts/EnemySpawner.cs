using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnTime = 2f;
    public float spawnDealy = 3f;

    public GameObject enemyPrefab;

    private void Start()
    {
        InvokeRepeating("Spawn", spawnDealy, spawnTime);
    }


    void Spawn()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }
}
