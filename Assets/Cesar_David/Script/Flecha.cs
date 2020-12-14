using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha: MonoBehaviour
{
    public float velocity;
    void Start()
    {
        Destroy(this.gameObject, 3f);
    }

    
    void Update()
    {
        transform.Translate(0,0,velocity);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("jugador"))
        {
            Destroy(this.gameObject);
        }
    }

}
