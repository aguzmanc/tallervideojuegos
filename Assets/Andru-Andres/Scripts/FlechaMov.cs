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

        transform.Translate(Vector3.forward * velFlecha * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="enemigo")
        {
            contadorEnemigos++;

            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Debug.Log("muertes " + contadorEnemigos);
        }
        
        if (other.tag=="torre")
        {
            Destroy(this.gameObject);
        }
    }



}
