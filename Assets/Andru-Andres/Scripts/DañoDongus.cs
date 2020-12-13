using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoDongus : MonoBehaviour
{
    private VidaPlayer jugador;
    public int cantidad;
    void Start()
    {
        jugador = GameObject.Find("Jugador").GetComponent<VidaPlayer>();
    }

   
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jugador.vida -= cantidad;
        }
    }
}
