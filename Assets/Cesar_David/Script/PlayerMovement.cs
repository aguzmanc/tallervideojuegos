using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   //Componentes
    Rigidbody rb;
    Animator anim;

    //Movimiento
    [Header("Movimiento")]
    public float moveSpeed = 5f;
    public float sprintSpeed = 7f;
    float move;
    Vector3 movement;

    //Luz
    [Header("Luz")]
    public Light antorcha;
    public float antorchaRadio = 179;
    float decreaseLight;
    public float DisminuyeLuzNormal;
    public float DisminuyeLuzCorriendo;
    public float luzMinima;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        move = moveSpeed;
        decreaseLight = Time.deltaTime;
    }


    void Update()
    {
        //Entrada de movimiento
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        if (movement.x !=0 || movement.x != 0)
        {
            anim.SetBool("idle", false);
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
            anim.SetBool("idle", true);
        }
        //Sprint
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.Space))
        {
            move = sprintSpeed;

            decreaseLight = Time.deltaTime * DisminuyeLuzCorriendo;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKey(KeyCode.Space))
        {
            move = moveSpeed;
            decreaseLight = Time.deltaTime * DisminuyeLuzNormal;
        }

        //Disminuye la luz
        antorcha.spotAngle = antorchaRadio;
        if (antorchaRadio > luzMinima) { antorchaRadio -= decreaseLight; }

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
