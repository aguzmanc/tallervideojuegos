using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModificandoTransform : MonoBehaviour
{
    public int parametroY;
    public float velocidad;



    public float rotacion;


    void Start()
    {
        rotacion = 0;

        transform.position = new Vector3(1, parametroY, 3);

        GetComponent<Rigidbody>().velocity = new Vector3(0,0,5);
        
    }


    void Update()
    {
        //transform.rotation = Quaternion.Euler(rotacion,50,30);
        //rotacion = rotacion + velocidad;
        //      3 + 7.8
        //          10.8
        
    }
}
