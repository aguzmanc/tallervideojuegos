using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimation : MonoBehaviour
{
    public SpriteRenderer player;
    public Animator MoveAnim;
    public Sprite cuadro1;
    public Sprite cuadro2;
    public int acumulador;
    public int n;
    void Start()
    {

        player = GetComponent<SpriteRenderer>();
        player.sprite = cuadro1;
        n = 0;
        acumulador = 0;

        MoveAnim = GetComponent<Animator>();


    }
    void Update()
    {

        acumulador = acumulador + 1;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {


            MoveAnim.SetBool("mover", true);

        }
        else
        {
            MoveAnim.SetBool("mover", false);
        }




        //MoveAnim.SetBool("mover-Derecha",true);
        //MoveAnim.SetBool("estatico-Derecha", false);

    }



        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
       





}


