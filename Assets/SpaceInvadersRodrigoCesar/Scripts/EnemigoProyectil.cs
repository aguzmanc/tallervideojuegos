using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoProyectil : MonoBehaviour
{
    private Transform balaenemiga;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        balaenemiga = GetComponent<Transform>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        balaenemiga.position += Vector3.up * -speed;
        if (balaenemiga.position.y <= -10)
            Destroy(balaenemiga.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag =="Player")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameOver.isPlayerDead = true;
        }
        else if (other.tag == "Base")
        {
            //GameObject 
        }
    }
}
