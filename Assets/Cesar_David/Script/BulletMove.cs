using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float velocity;
    void Start()
    {
        Destroy(this.gameObject, 5f);
    }

    
    void Update()
    {
        transform.Translate(0,velocity,0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("jugador"))
        {
            Destroy(this.gameObject);
        }
    }
   
}
