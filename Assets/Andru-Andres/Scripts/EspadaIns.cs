﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadaIns : MonoBehaviour
{
    
    public Transform posicion;
    public GameObject espada;
    
    
    public float tiempoRot;

    void Start()
    {
    }
    

   
   


    void Update()
    {

        tiempoRot += Time.deltaTime;

        if (Input.GetMouseButtonDown(1) && tiempoRot>5)
        {
            espada.gameObject.SetActive(true);
            tiempoRot = 0;
           
        }
        

       
    }



}


