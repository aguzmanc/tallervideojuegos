using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RRcontrolPlayer : MonoBehaviour
{
    Animator animator;
    float[] rrPlayerVelocCaja = {0.2f, 1f, 1.5f, 2f, 2.5f}; //la nave nunca se detiene, solo cambia de velocidad
    float rrPlayerVeloc = 0;
    int PlayerVelocCounter =0;
    // banderas
    bool rrPlayerAlive = true;
    void Start()
    {
        animator= GetComponent<Animator>();
        rrPlayerVeloc= rrPlayerVelocCaja[0];

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * rrPlayerVeloc * Time.deltaTime);
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool ("izquierda", true);
            transform.Translate(Vector3.right * Time.deltaTime);
        }
        else
        {
            animator.SetBool ("izquierda", false);

        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool ("derecha", true);
            transform.Translate(Vector3.left * Time.deltaTime);
        }
        else
        {
            animator.SetBool ("derecha", false);
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            if(PlayerVelocCounter <= 4)
            {
            PlayerVelocCounter = PlayerVelocCounter +1 ;
            rrPlayerVeloc = rrPlayerVelocCaja[PlayerVelocCounter];
            Debug.Log("velocidad = " + rrPlayerVelocCaja[PlayerVelocCounter]);
            }
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            if(PlayerVelocCounter >= 0)
            {
            PlayerVelocCounter = PlayerVelocCounter -1;
            rrPlayerVeloc = rrPlayerVelocCaja[PlayerVelocCounter];
            Debug.Log("velocidad = " + rrPlayerVelocCaja[PlayerVelocCounter]);
            }
            
        }

    }
    private void OnTriggerEnter2D (Collider2D other)
    {
    
    if (other.gameObject.CompareTag("rrborde") || other.gameObject.CompareTag("rrEnemigo"))
        {
        //nave explota
        Debug.Log("chocaste, nave destruida");
        animator.SetBool ("Estrellado", true);
        }
    else if (other.gameObject.CompareTag("rrCombustible"))
    {
    
        Debug.Log("recargando combustible"); //aumentaria al combustible una unidad por decima de segundo
    }



    }

}
