using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    GameObject jugador;
    public float velocity;
    public float time;
   
    void Start()
    {
        Destroy(this.gameObject, time);
        jugador = GameObject.Find("Jugador");
    }

    
    void Update()
    {
        transform.position = jugador.transform.position;
        transform.Rotate(0,0, velocity * Time.deltaTime); 
    }
}
