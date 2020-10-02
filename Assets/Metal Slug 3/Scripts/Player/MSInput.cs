using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSInput : MonoBehaviour
{
    public HorizontalInput inputStateX;
    public VerticalInput inputStateY;
    public float velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
        LogInput();
    }

    private void ReadInput()
    {
        inputStateX = HorizontalInput.NO_INPUT_X;
        inputStateY = VerticalInput.NO_INPUT_Y;

        if (Input.GetKey(KeyCode.D))
        {
            inputStateX = HorizontalInput.RIGHT;
        }


        if (Input.GetKey(KeyCode.A))
        {
            inputStateX = HorizontalInput.LEFT;
        }

        if (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.D)))
        {
            inputStateX = HorizontalInput.NO_INPUT_X;
        }


        if (Input.GetKey(KeyCode.W))
        {
            inputStateY = VerticalInput.UP;
        }


        if (Input.GetKey(KeyCode.S))
        {
            inputStateY = VerticalInput.DOWN;
        }

        if (Input.GetKey(KeyCode.W) && (Input.GetKey(KeyCode.S)))
        {
            inputStateY = VerticalInput.NO_INPUT_Y;
        }

    }

    private void LogInput()
    {
        Debug.Log(inputStateX +  "------" + inputStateY);
    }
}
