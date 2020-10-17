using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoDeGolpeEstatico : MonoBehaviour
{



    public SpriteRenderer jugador;
    public Animator golpeEstado;
    public bool agachado;
    void Start()
    {
        golpeEstado = GetComponent<Animator>();
        
    }

    void Update()
    {
      

        //else
        //{
          
        //        golpeEstado.SetBool("golpe", false);
            
           
              
        //}


         //if (Input.GetKeyDown(KeyCode.X))
         //   {
         //       golpeEstado.SetTrigger("patada-Estado");
               

         //   }
            //else
            //{
               
            //       golpeEstado.SetBool("patada", false);
                


            //}


    }
}
