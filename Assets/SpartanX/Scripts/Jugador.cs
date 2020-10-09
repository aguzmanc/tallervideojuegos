using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    bool atacado = false;
    Game gm;
    public GameObject control;
   
    void Start()
    {
        gm = control.GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        if (atacado)
        {
            gm.health -= 0.001f;
           
        }
    }


}
