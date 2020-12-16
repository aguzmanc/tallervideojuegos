using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ola1 : MonoBehaviour
{
    private float rangoGeneracion = 25f;
    private float rangoGeneracionZ = -17f;
    public GameObject prefabEnemigo;
    public GameObject OleadaDos;
    public GameObject OlaUnoImage;
    public int numeroOleada = 1;
    private float TimeInicio = 2f;
    public float intervaloGeneracion = 6f;
    public int numEnemigos;
    private float cont;

    public int contadorSimpleDongnus = 105; 
    public Text pts;
    void Start()
    {
        OlaUnoImage.SetActive(true);

        SoundSystem.instance.PlayOla();
        GeneradorEnemigos(numeroOleada); 
    }


    void Update()
    {
        numEnemigos = FindObjectsOfType<Enemigo_Dongnus>().Length;
        if (numeroOleada == 14)
        {
            OleadaDos.SetActive(true);
        }
        if (numeroOleada == 14) return;
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
            contadorSimpleDongnus--;
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
