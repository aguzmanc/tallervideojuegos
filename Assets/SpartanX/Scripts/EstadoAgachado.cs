using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoAgachado : MonoBehaviour
{
    public SpriteRenderer jugador;
    public Animator golpeEstado;
   



    void Start()
    {

        golpeEstado = GetComponent<Animator>();


    }

    
    void Update()
    {

        if (Input.GetKey(KeyCode.DownArrow))
        {

            golpeEstado.SetBool("agachado", true);

            if (Input.GetKeyDown(KeyCode.Z))
            {
                golpeEstado.SetTrigger("golpeAgachado");
               
              
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                
                golpeEstado.SetTrigger("patadaAgachado");

            }

        }
        else
        {

            golpeEstado.SetBool("agachado", false);
            if (Input.GetKeyDown(KeyCode.Z))
            {

                golpeEstado.SetTrigger("golpeEstado");

            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                golpeEstado.SetTrigger("patada-Estado");
                

            }



        }



       


        

    }





    private void OnTriggerEnter2D(Collider2D other)
    {
       


        if (other.tag == "Enemigo")
        {

            golpeEstado.SetTrigger("agachadoGol");

        }


    }




}

