using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGenerador : MonoBehaviour
{
    private float rangoGeneracion = 25f;
    private float rangoGeneracionZ = -17f;

    public GameObject prefabEnemigo;
    public GameObject prefabEnemigoExplosivo;

    public int numeroOleada = 1;
    private int numeroOleadaUno = 1;
    public float TimeInicio = 2f;
    public float intervaloGeneracion = 5f;
    public int numEnemigos;
    public int numEnemigosExplosivo;
    private float cont;

    public GameManager gameManager;
    private Enemigo_Dongnus enemigo;
    void Start()
    {
        GeneradorEnemigos(numeroOleadaUno);

        GeneradorEnemigos(numeroOleada);
        GeneradorEnemigosExplosivos(numeroOleada);
    }


    void Update()
    {
        numEnemigos = FindObjectsOfType<Enemigo_Dongnus>().Length;
        numEnemigosExplosivo = FindObjectsOfType<Enemigo_Explosivo>().Length;




        if (numeroOleada == 7) return;
        if (numEnemigos == 0)
        {
            numeroOleada++;
            GeneradorEnemigos(numeroOleada);
            Debug.Log("contadir" + numeroOleada);

        }
        if (numEnemigosExplosivo == 0)
        {
           
                GeneradorEnemigosExplosivos(numeroOleada);

            
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
    void GeneradorEnemigosExplosivos(int numEnemigosAGenerar)
    {
            for (int i = 0; i <numEnemigosAGenerar; i++)
            {            
                Instantiate(prefabEnemigoExplosivo, DamePosicionGeneracion(), prefabEnemigoExplosivo.transform.rotation);
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
