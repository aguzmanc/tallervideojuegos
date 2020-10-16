using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarEnemigo : MonoBehaviour
{
    public Animator Detect;
    void Start()
    {

        Detect = GetComponent<Animator>();



    }

    
    void Update()
    {
        
    }




    //private void OnCollision(Collision other)
    //{
    //    if(other.gameObject.tag=="Enemigo")
    //    {
    //        Debug.Log(other.gameObject.name);
    //        Detect.SetBool("golpeado",true);

    //    }

    //}


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.tag == "Enemigo")
        {
            //Debug.Log(other.gameObject.name);
            Detect.SetBool("golpeado", true);
        }
    }


   


}
