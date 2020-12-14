using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaMov : MonoBehaviour
{

    public float velFlecha;
    public float contadorEnemigos;

    void Start()
    {
       
    }


    void Update()
    {

        transform.Translate(Vector3.up* velFlecha * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="enemigo")
        {
            contadorEnemigos++;

            Destroy(other.gameObject);
            Destroy(this.gameObject);

        }
        
        if (other.tag=="torre")
        {
            Destroy(this.gameObject);
        }
    }



}
