using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{ 
    public GameObject enemy;
    public GameObject[] Generador;
    void Start()
    {
        StartCoroutine("Hordas");
        
    }

    
    void FixedUpdate()
    {
        
    }
    IEnumerator Hordas()
    {
        for (int i = 1; i < 100; i++)
        {
            int aleatorio = Random.Range(2, 5);
            StartCoroutine(Spawner(aleatorio, 0.5f));
            yield return new WaitForSeconds(aleatorio*1);
        }
    }

    IEnumerator Spawner(int Rowsize, float wait)
    {
        Vector3 posicion = Generador[1].transform.position;
        for (int i = 1; i <= Rowsize; i++)
        { if (Random.Range(1, 3) == 1)
            {
                Instantiate(enemy, Generador[0].transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(enemy, posicion, Quaternion.Euler(0,180,0));
            }
            

            yield return new WaitForSeconds(wait);
        }

    }
}
