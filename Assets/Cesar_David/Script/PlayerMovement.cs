using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   //Componentes
    Rigidbody rb;

    //Movimiento
    [Header("Movimiento")]
    public float moveSpeed = 5f;
    public float sprintSpeed = 7f;
    float move;
    Vector3 movement;

    //Luz
    [Header("Luz")]
    public Light linterna;
    public float linternaRadio = 179;
    float decreaseLight;
    public float DisminuyeLuzNormal;
    public float DisminuyeLuzCorriendo;
    public float luzMinima;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        move = moveSpeed;
        decreaseLight = Time.deltaTime;
    }


    void Update()
    {
        //Entrada de movimiento
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        //Sprint
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.CapsLock))
        {
            move = sprintSpeed;

            decreaseLight = Time.deltaTime * DisminuyeLuzCorriendo;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKey(KeyCode.CapsLock))
        {
            move = moveSpeed;
            decreaseLight = Time.deltaTime * DisminuyeLuzNormal;
        }

        //Disminuye la luz
        linterna.spotAngle = linternaRadio;
        if (linternaRadio > luzMinima) { linternaRadio -= decreaseLight; }

        //Apuntar con el mouse
        Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.down);

    }

    void FixedUpdate()
    {//Mueve al jugador
        rb.MovePosition(rb.position + movement * move * Time.fixedDeltaTime);
    }
}
