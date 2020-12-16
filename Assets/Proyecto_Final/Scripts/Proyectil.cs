using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    private Transform Cuerpo;
    private Rigidbody2D Fuerza;
    public float FuerzaDeDisparo=400;
    private Vector2 direccion;

    // Start is called before the first frame update
    void Start()
    {
        Cuerpo = GetComponent<Transform>();
        Fuerza = GetComponent<Rigidbody2D>();

        Vector3 positionmouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Cuerpo.position = new Vector2(positionmouse.x, positionmouse.y);

        direccion = (positionmouse - Cuerpo.position).normalized;

    }

    // Update is called once per frame
    void Update()
    {
        Fuerza.velocity = new Vector2(direccion.x * 40f, direccion.y * 40f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
