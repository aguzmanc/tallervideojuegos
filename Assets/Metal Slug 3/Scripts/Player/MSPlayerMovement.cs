using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSPlayerMovement : MonoBehaviour
{
    
    [SerializeField] private MSInput msInput;
    [SerializeField] private float velocity;
    private Rigidbody rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (msInput.inputStateX == HorizontalInput.LEFT)
        {
            rb.velocity = new Vector2(-1f * velocity, 0f);
        }

        if (msInput.inputStateX == HorizontalInput.RIGHT)
        {
            rb.velocity = new Vector2(1f * velocity , 0f);
        }

        if (msInput.inputStateX == HorizontalInput.NO_INPUT_X)
        {
            rb.velocity = Vector2.zero;
        }
    }
    void Update()
    {
        
    }
}
