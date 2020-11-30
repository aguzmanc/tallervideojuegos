using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemdeLuz : MonoBehaviour
{
    PlayerControl jugador;
    public int duracion;
    public int aumentodeLuz=20;
    void Start()
    {
        jugador = GameObject.Find("Jugador").GetComponent<PlayerControl>();
        Destroy(gameObject, duracion);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.name == "Jugador")
        {
            jugador.linternaRadio += aumentodeLuz;
            Destroy(gameObject);
           
        }
    }
}
