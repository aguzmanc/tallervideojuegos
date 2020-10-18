using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidadelJugador : MonoBehaviour
{   bool atacado;
    public GameObject control;
    Game gm;
    private Animator jugador;

    void Start()
    {
        gm = control.GetComponent<Game>();
        jugador = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (atacado)
        {
            gm.health -= 0.004f;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
        
    {
       
        if (collision.gameObject.GetComponent<Enemy1Move>().atacando)
        {
            atacado = true;
            jugador.SetBool("mover", false);
        }
        
    }   
    private void OnTriggerExit2D(Collider2D collision)
    {

        atacado = false;       
    }
}
