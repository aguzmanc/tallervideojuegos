using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClones : MonoBehaviour
{
    public GameObject Enemy;
    int limiteX=15;
    int limiteZ=14;
    void Start()
    {
        InvokeRepeating("EnemyClone", 2, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnemyClone()
    {
        Vector3 RandomPosition;
        RandomPosition.y = 0.5f;
        if (UnityEngine.Random.Range(0, 2) == 1)
        {
            RandomPosition.x = UnityEngine.Random.Range(-limiteX, limiteX+1);
            //if (Random.Range(0, 2) == 1)
            //{
                RandomPosition.z = -limiteZ;
            //}
            //else { RandomPosition.y = limiteY; }

        }
        else
        {
            RandomPosition.z = UnityEngine.Random.Range(-limiteZ, limiteZ+1);
            if (UnityEngine.Random.Range(0, 2) == 1)
            {
                RandomPosition.x = -limiteX;
            }
            else { RandomPosition.x = limiteX; }
        }

        Instantiate(Enemy, RandomPosition,Quaternion.identity);
    }
}
