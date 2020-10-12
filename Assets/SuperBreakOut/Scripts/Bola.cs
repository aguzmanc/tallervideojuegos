using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    float pad0ffsetY = 0.4f;
    float velocidad = 6;
    Rigidbody2D rb;
    bool lanzada = false;
    public GameObject soundball;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!lanzada)
        {
            PosicionSobrePad();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Lanzar();
            }
        }
     
    }
    void PosicionSobrePad()
    {
        var pad = FindObjectOfType<Pad>();
        var padPos = pad.transform.position;
        transform.position = padPos + new Vector3(0, pad0ffsetY, 0);
    }
    void Lanzar()
    {
        var dir = new Vector2(1, 1);
        rb.velocity = dir.normalized * velocidad;
        lanzada = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var contacto = collision.GetContact(0);
        Instantiate(soundball);
        rb.velocity = Vector2.Reflect(rb.velocity, contacto.normal);
        velocidad = velocidad + 0.05f;
    }
    public void Reset()
    {
        rb.velocity = new Vector2(0, 0);
        PosicionSobrePad();
        lanzada = false;
    }
}
