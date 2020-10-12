using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimation : MonoBehaviour
{
    public SpriteRenderer player;
    public Animator MoveAnim;
    //public Sprite cuadro1;
    //public Sprite cuadro2;
    //public int cint;

    void Start()
    {

        //player = GetComponent<SpriteRenderer>();
        //cint = 0;
        MoveAnim = GetComponent<Animator>();


    }
    void Update()
    {
       
        //if(cint==0)
        //{
        if (Input.GetKey(KeyCode.RightArrow))
        {
        //        cint = cint + 1;
                //player.sprite = cuadro2;
         MoveAnim.SetBool("mover",true);
               
         }
        else
        {
            MoveAnim.SetBool("mover", false);
        }
        //}

       






    }

}
