using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerProyectilEnemigo : MonoBehaviour
{
    private Transform proyectil;
    public float speed;

    void Start()
    {
        proyectil = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        proyectil.position += Vector3.up * -speed;
        if (proyectil.position.y <= -10)
            Destroy(proyectil.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameOver.isPlayerDead = true;
        }
        //else if (other.tag == "Base")
        //{
        //    GameObject playerBase = other.gameObject;
        //    BaseHealth baseHealth = playerBase.GetComponent<BaseHealth>();
        //    baseHealth.health -= 1;
        //    Destroy(gameObject);
        //}
    }
}
