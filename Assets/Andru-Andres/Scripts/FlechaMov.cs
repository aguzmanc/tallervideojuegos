using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaMov : MonoBehaviour
{

    public float velFlecha;
    

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
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }



}
