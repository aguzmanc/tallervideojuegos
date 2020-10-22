using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class rrplayercontroller : MonoBehaviour  
{
 
    public float velocidad;
    
    
 
    Rigidbody2D rb2D;
    Vector2 movimiento;
    bool estaVivo;
 
    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
 
    void Update()
    {
        movimiento = new Vector2( Input.GetAxis("Horizontal") , Input.GetAxis("Vertical")  );
    }
 
    void FixUpdate()
    {
        transform.Translate(movimiento * velocidad);
    }
}
