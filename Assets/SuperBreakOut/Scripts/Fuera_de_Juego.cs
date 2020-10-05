using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuera_de_Juego : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<Bola>().Reset();
        FindObjectOfType<Pad>().Reset();
    }
}

