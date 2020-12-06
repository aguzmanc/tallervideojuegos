using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadaIns : MonoBehaviour
{
    public GameObject espada;
    public Transform posicion;
    public float timepo;
    public float tiempoRot;
   
    void Start()
    {
        
    }

    
    void Update()
    {

        tiempoRot += Time.deltaTime; 
        if(Input.GetKeyDown(KeyCode.Mouse1) && tiempoRot>1.3)
        {
            espada.gameObject.SetActive(true);
            tiempoRot = 0;
           
        }
        timepo += Time.deltaTime;
        if (timepo > 1)
        {
            espada.gameObject.SetActive(false);
            timepo = 0;
        }


    }
}
