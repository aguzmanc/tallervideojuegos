﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida_Jugador : MonoBehaviour
{
    public float vidaPlayer = 300;
    public float vidmax = 300;
    public float corazones = 3;
    public Image barraDeVida;
    void Start()
    {

    }

    void Update()
    {
        

    }
  
    private void OncollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("enemigo"))
        {
            vidaPlayer = Mathf.Clamp(vidaPlayer, 0, vidmax);
            barraDeVida.fillAmount = vidaPlayer / vidmax;
            Debug.Log("perdiendo vida");
        }
    }
  void ataqueDongus ()
    {
       
    }
}
