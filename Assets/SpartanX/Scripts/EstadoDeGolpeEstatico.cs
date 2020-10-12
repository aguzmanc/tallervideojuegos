using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoDeGolpeEstatico : MonoBehaviour
{



    public SpriteRenderer jugador;
    public Animator golpeEstado;
    void Start()
    {
        golpeEstado = GetComponent<Animator>();
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            //golpeEstado.SetTrigger("golpeEstado");
            golpeEstado.SetBool("golpe", true);

        }
        else
        {
          
                golpeEstado.SetBool("golpe", false);
            
           
              
        }


         if (Input.GetKey(KeyCode.S))
            {
                //golpeEstado.SetTrigger("golpeEstado");
                golpeEstado.SetBool("patada", true);

            }
            else
            {
               
                   golpeEstado.SetBool("patada", false);
                


            }


    }
}
