using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimation : MonoBehaviour
{
    public SpriteRenderer player;
    public Animator MoveAnim;
    //public Sprite cuadro1;
    //public Sprite cuadro2;
    

    void Start()
    {

        //player = GetComponent<SpriteRenderer>();
       
        MoveAnim = GetComponent<Animator>();


    }
    void Update()
    {
      
        if (Input.GetKey(KeyCode.RightArrow))
        {
         

            MoveAnim.SetBool("mover-Derecha",true);
               
         }
        else
        {
            MoveAnim.SetBool("mover-Derecha", false);
        }
        


        if (Input.GetKey(KeyCode.LeftArrow))
        {
           
            MoveAnim.SetBool("mover", true);

        }
        else
        {
            MoveAnim.SetBool("mover", false);
        }





    }

}
