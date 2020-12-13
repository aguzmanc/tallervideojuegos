using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ola1 : MonoBehaviour
{
    private float rangoGeneracion = 25f;
    private float rangoGeneracionZ = -17f;
    public GameObject prefabEnemigo;
    public GameObject OleadaDos;
    public int numeroOleada = 1;
    private float TimeInicio = 2f;
    public float intervaloGeneracion = 6f;
    public int numEnemigos;
    private float cont;

    void Start()
    {
        GeneradorEnemigos(numeroOleada); 
    }


    void Update()
    {
        numEnemigos = FindObjectsOfType<Enemigo_Dongnus>().Length;
        if (numeroOleada == 7)
        {
            SoundSystem.instance.PlayOla();
            OleadaDos.SetActive(true);
        }
        if (numeroOleada == 7) return;
        if (numEnemigos == 0)
        {
            numeroOleada++;
            GeneradorEnemigos(numeroOleada);
            Debug.Log("contadir" + numeroOleada);

        }
    

    }
    void GeneradorEnemigos(int numEnemigosAGenerar)
    {
        for (int i = 0; i < numEnemigosAGenerar; i++)
        {

            Instantiate(prefabEnemigo, DamePosicionGeneracion(), prefabEnemigo.transform.rotation);
            cont++;
        }
    }
 

    Vector3 DamePosicionGeneracion()
    {
        float posXGeneracion = Random.Range(-23f, rangoGeneracion);


        Vector3 posAleatoria = new Vector3(posXGeneracion, 0, rangoGeneracionZ);
        return posAleatoria;
    }
}
