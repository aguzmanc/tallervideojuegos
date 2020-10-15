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
           

        }
        else
        {

            golpeEstado.SetBool("agachado", false);



        }

        if (Input.GetKey(KeyCode.Z))
        {

            golpeEstado.SetBool("golpe-agachado", true);
            //transform.Translate(new Vector3(0, 0, 0));

        }
        else
        {

            golpeEstado.SetBool("golpe-agachado", false);



        }


        if (Input.GetKey(KeyCode.X))
        {

            golpeEstado.SetBool("patada-agachado", true);

        }
        else
        {

            golpeEstado.SetBool("patada-agachado", false);



        }















    }


}
