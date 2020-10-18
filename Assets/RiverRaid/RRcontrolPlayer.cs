using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RRcontrolPlayer : MonoBehaviour
{
    Animator animator;
    float[] rrPlayerVelocCaja = {0.5f, 1f, 1.5f, 2f, 2.5f}; //la nave nunca se detiene, solo cambia de velocidad
    float rrPlayerVeloc = 0;
    int PlayerVelocCounter =0;
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
            PlayerVelocCounter++;
            rrPlayerVeloc = rrPlayerVelocCaja[PlayerVelocCounter];
            Debug.Log("velocidad = " + rrPlayerVelocCaja[PlayerVelocCounter]);
            }
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            if(PlayerVelocCounter >= 0)
            {
            PlayerVelocCounter--;
            rrPlayerVeloc = rrPlayerVelocCaja[PlayerVelocCounter];
            Debug.Log("velocidad = " + rrPlayerVelocCaja[PlayerVelocCounter]);
            }
            
        }
    }
}
