using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGenerador : MonoBehaviour
{
    private float rangoGeneracion = 25f;
    private float rangoGeneracionZ = -17f;
    public GameObject prefabEnemigo;
    public int numeroOleada = 2;
    public float TimeInicio = 2f;
    public float intervaloGeneracion = 6f;
    public float numEnemigos = 3f;
    private float cont;
    void Start()
    {
        InvokeRepeating("GeneradorEnemigos", TimeInicio, intervaloGeneracion);
      
      //  Debug.Log("contadir" + cont);
    }


    void Update()
    {

    }
    void GeneradorEnemigos()
    {
        if (cont == 5)
        {
            numEnemigos = 0;
        }
        else
        {
            for (int i = 0; i < numEnemigos; i++)
            {
               
                Instantiate(prefabEnemigo, DamePosicionGeneracion(), prefabEnemigo.transform.rotation);
                cont++;
            }
        }

       
    }

    Vector3 DamePosicionGeneracion()
    {
        float posXGeneracion = Random.Range(-23f, rangoGeneracion);
      


        Vector3 posAleatoria = new Vector3(posXGeneracion, 0, rangoGeneracionZ);
        return posAleatoria;
    }
}
