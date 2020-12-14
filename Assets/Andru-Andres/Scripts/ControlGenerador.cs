﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public GameObject oleadan1;

    static int contadorIgnis=55;
    static int contadorDog=55;
    public Text contDognus;
    public Text contIgnis;
 
    private Enemigo_Dongnus enemigo;
    void Start()
    {
        oleadan1.SetActive(true);
        GeneradorEnemigos(numeroOleadaUno);
        SoundSystem.instance.PlayOla();
        GeneradorEnemigos(numeroOleada);
        GeneradorEnemigosExplosivos(numeroOleada);
    }


    void Update()
    {
        numEnemigos = FindObjectsOfType<Enemigo_Dongnus>().Length;
        numEnemigosExplosivo = FindObjectsOfType<Enemigo_Explosivo>().Length;

        if (numeroOleada == 10) return;
        if (numEnemigos == 0)
        {
            numeroOleada++;
            GeneradorEnemigos(numeroOleada);

            if (numEnemigosExplosivo == 0)
            {
            
                GeneradorEnemigosExplosivos(numeroOleada);
            }
        }
        contDognus.text = contadorDog.ToString();
        contIgnis.text = contadorIgnis.ToString();
    }
    void GeneradorEnemigos(int numEnemigosAGenerar)
    { 
            for (int i = 0; i < numEnemigosAGenerar; i++)
            {
                Instantiate(prefabEnemigo, DamePosicionGeneracion(), prefabEnemigo.transform.rotation);
                cont++;
            contadorDog--;
            }
    }
    void GeneradorEnemigosExplosivos(int numEnemigosAGenerar)
    {
            for (int i = 0; i <numEnemigosAGenerar; i++)
            {            
                Instantiate(prefabEnemigoExplosivo, DamePosicionGeneracion(), prefabEnemigoExplosivo.transform.rotation);
                cont++;
            contadorIgnis--;
            }
    }
    Vector3 DamePosicionGeneracion()
    {
        float posXGeneracion = Random.Range(-23f, rangoGeneracion);
        Vector3 posAleatoria = new Vector3(posXGeneracion, 0, rangoGeneracionZ);
        return posAleatoria;
    }
}