using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDisparo : MonoBehaviour
{
    private Transform proyectil;
    public float speed;
   
    void Start()
    {
        proyectil = GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        proyectil.position += Vector3.up * speed;
        if (proyectil.position.y >= 10)
            Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.tag == "Enemigo")
        {
            Destroy(otro.gameObject);
            Destroy(gameObject);
        }
        else if (otro.tag == "Base")
            Destroy(gameObject);
    }

}
