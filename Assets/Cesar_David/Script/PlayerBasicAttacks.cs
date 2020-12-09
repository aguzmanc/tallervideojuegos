using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerBasicAttacks : MonoBehaviour
{

    //Objetos
    [Header("Armas")]
    public GameObject bullet;
    public GameObject sword;

    //Shot
    [Header("Shot")]
    public float shotRate = 1f;
    float shotcounter;

    //Melee
    [Header("Melee")]
    public float meleeCooldown = 0.5f;
    float meleecounter;

   

    private void Start()
    {//Asignaciones iniciales
        shotcounter = shotRate;
        meleecounter = meleeCooldown;
       
               
    }
    void Update()
    {
     
     //Disparo normal 
        if (Input.GetMouseButton(0) && shotcounter>shotRate)
        {
            Instantiate(bullet,transform.position,transform.rotation);
            shotcounter = 0f;
        }
     //Melee
        if (Input.GetMouseButtonDown(1) && meleecounter > meleeCooldown)
        {
            Instantiate(sword, transform.position, Quaternion.Euler(90,0,0));
            meleecounter = 0f;
        }
     
     
     
     
     //Actualizar contadores
        shotcounter += Time.deltaTime;
        meleecounter+= Time.deltaTime;
        
    }

   
}
