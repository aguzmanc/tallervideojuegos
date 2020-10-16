using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RRcontrolPlayer : MonoBehaviour
{
    Animator animator;
    
    void Start()
    {
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool ("izquierda", true);
        }
        else
        {
            animator.SetBool ("izquierda", false);
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool ("derecha", true);
        }
        else
        {
            animator.SetBool ("derecha", false);
        }
    }
}
