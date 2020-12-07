using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;
    //public Light spotLight;

    //Luz al correr
    public float rangeSpeed = 1.0f;
    //public float sprintRange = 27f;

    Vector2 movement;
    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        //Correr o Caminar

        if (Input.GetKey(KeyCode.LeftShift))
        {
            //spotLight.spotAngle = sprintRange;
            moveSpeed = 10f;
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            //spotLight.spotAngle = 35;
            moveSpeed = 5f;
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }


        //Posición del personaje donde está el puntero del mouse en base al MainCamera

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }


    //Posición y rotación del rigidbody en base al puntero
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}