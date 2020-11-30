using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerControl : MonoBehaviour
{//Componentes
    Rigidbody2D rb;

    //Objetos
    [Header("Objetos")]
    public GameObject bullet;
    public GameObject sword;

    //Movimiento
    [Header("Movimiento")]
    public float moveSpeed = 5f;
    public float sprintSpeed = 7f;
    float move;
    Vector2 movement;

    

    //Shot
    [Header("Disparo")]
    public float shotRate = 1f;
    float shotcounter;

    //Melee
    [Header("Objetos")]
    public float meleeCooldown = 0.5f;
    float meleecounter;

    //Luz
    [Header("Luz")]
    public Light linterna;
    [NonSerializedAttribute] public float  linternaRadio=179;
    float decreaseLight;
    public float DisminuyeLuzNormal;
    public float DisminuyeLuzCorriendo;
    public float luzMinima;


    private void Start()
    {//Asignaciones iniciales
        shotcounter = shotRate;
        meleecounter = meleeCooldown;
        move = moveSpeed;
        decreaseLight = Time.deltaTime;
        rb = gameObject.GetComponent<Rigidbody2D>();
               
    }
    void Update()
    {//Entrada de movimiento
       movement.x= Input.GetAxisRaw("Horizontal");
       movement.y= Input.GetAxisRaw("Vertical");
     
     //Disparo normal 
        if (Input.GetMouseButton(0) && shotcounter>shotRate)
        {
            Instantiate(bullet,transform.position,transform.rotation);
            shotcounter = 0f;
        }
     //Melee
        if (Input.GetMouseButtonDown(1) && meleecounter > meleeCooldown)
        {
            Instantiate(sword, transform.position, transform.rotation);
            meleecounter = 0f;
        }
     //Sprint
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.CapsLock))
        {
            move = sprintSpeed;

            decreaseLight = Time.deltaTime * DisminuyeLuzCorriendo;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKey(KeyCode.CapsLock))
        {
            move = moveSpeed;
            decreaseLight = Time.deltaTime*DisminuyeLuzNormal;
        }
     
     //Apuntar con el mouse
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
     
     //Actualizar contadores
        shotcounter += Time.deltaTime;
        meleecounter+= Time.deltaTime;

        //Disminuye la luz

        linterna.spotAngle = linternaRadio;
        if (linternaRadio > luzMinima) { linternaRadio -= decreaseLight; }
        
    }

    void FixedUpdate()
    {//Mueve al jugador
        rb.MovePosition(rb.position + movement * move * Time.fixedDeltaTime);
    }
}
