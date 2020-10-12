using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float vel;
   

    void Start()
    {

       

    }
    void Update()
    {

       if(Input.GetKey(KeyCode.RightArrow))
       {
            transform.Translate(Vector3.right * vel);
           
        
        
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * vel);
         


        }















    }



}




