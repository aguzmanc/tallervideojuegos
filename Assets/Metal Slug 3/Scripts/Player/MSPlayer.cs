using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSPlayer : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private Rigidbody2D rb;
    private float direction;
    
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    private void ReadInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            direction = 90f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction = 270;
        }
    }

    private void Movement()
    {

    }
}
