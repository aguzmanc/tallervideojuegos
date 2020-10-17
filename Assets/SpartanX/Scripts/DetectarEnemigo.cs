using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarEnemigo : MonoBehaviour
{
    public Animator Detect;
    public GameObject en;
    void Start()
    {

        Detect = GetComponent<Animator>();



    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(en);
        }
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
        en = other.gameObject;


        if (other.tag == "Enemigo")
        {
         
            Detect.SetBool("golpeado",true);
            
        }

       


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Detect.SetBool("golpeado",false);
       

    }









}
