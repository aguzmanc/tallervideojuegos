using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosio_Enemigo : MonoBehaviour
{
    public GameObject explosion;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);       
        }
    }
}
