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
    private void FixedUpdate()
    {
        proyectil.position += Vector3.up * speed;
        if (proyectil.position.y >= 100)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.tag == "Enemy")
        {
            Destroy(otro.gameObject);
            Destroy(gameObject);

        }
        else if (otro.tag == "Base")
            Destroy(gameObject);
    }

}
