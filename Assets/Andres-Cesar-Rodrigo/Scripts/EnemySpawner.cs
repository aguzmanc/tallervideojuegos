using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnTime = 2f;
    public float spawnDealy = 3f;

    private int cont = 0;

    public GameObject enemyPrefab;

    private void Start()
    {
        InvokeRepeating("Spawn", spawnDealy, spawnTime);
    }

    void Spawn()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }

    /*void WaveOne()
    {
        for(int i = 0; i < 5; i++)
        {
            Spawn();
            StartCoroutine(Timer());
        }
        enabled = false;
    }*/

    IEnumerator Timer (int cont)
    {
        yield return new WaitForSeconds(5);
        cont++;
    }
}
