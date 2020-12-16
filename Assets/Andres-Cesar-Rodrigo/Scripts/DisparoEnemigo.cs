using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    public float vx = -3f;
    public float vy = 0f;
    Rigidbody2D rb ;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(vx, vy);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);    
    }
}
