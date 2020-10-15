using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidadelJugador : MonoBehaviour
{   bool atacado;
    public GameObject control;
    Game gm;

    void Start()
    {
        gm = control.GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        if (atacado)
        {
            gm.health -= 0.0025f;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        atacado = true;
    }   
    private void OnTriggerExit2D(Collider2D collision)
    {
        atacado = false;       
    }
}
