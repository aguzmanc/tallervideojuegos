using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClones : MonoBehaviour
{
    public GameObject Enemy;
    int limiteX=15;
    int limiteY=14;
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
        Vector2 RandomPosition;
        if (Random.Range(0, 2) == 1)
        {
            RandomPosition.x = Random.Range(-limiteX, limiteX+1);
            //if (Random.Range(0, 2) == 1)
            //{
                RandomPosition.y = -limiteY;
            //}
            //else { RandomPosition.y = limiteY; }

        }
        else
        {
            RandomPosition.y = Random.Range(-limiteY, limiteY+1);
            if (Random.Range(0, 2) == 1)
            {
                RandomPosition.x = -limiteX;
            }
            else { RandomPosition.x = limiteX; }
        }

        Instantiate(Enemy, RandomPosition,Quaternion.identity);
    }
}
