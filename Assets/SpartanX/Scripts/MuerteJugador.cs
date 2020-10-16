using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteJugador : MonoBehaviour
{

    private Rigidbody rb;
    public float velCaida;
    private Animator ju;
    void Start()
    {
        ju = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.T))//(other.tag=="Enemigo")
        {


           
            ju.SetBool("muerte", true);



        }
        else
        {
            ju.SetBool("muerte", false);
        }



    }



  
}
