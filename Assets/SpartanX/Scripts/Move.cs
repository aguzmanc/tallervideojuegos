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
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(Vector3.right * vel);
             
        
        
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(Vector3.right * vel);
            


        }















    }



}




