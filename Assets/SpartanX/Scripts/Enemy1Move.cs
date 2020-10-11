using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy1Move : MonoBehaviour
{
    //Movimiento
    public float speed;

    //Sprites
    public Sprite attacking;
    public Sprite[] walksprites;
    public Sprite[] attacksprites;
    public Sprite deadsprite;
    SpriteRenderer sp;

    //Walkin Animation
    int walkanimcount;
    public float animspeed;
    float nextanimtime;

    //States
    bool walkanim = true;
    bool attackanim = false;
    bool canwalk = true;
    bool dead = false;
   public bool atacando = false;

    //Attack
    public float damage = 0.001f;

    //Rigidbody
    Rigidbody2D rb;

    float direccion;
    



    void Start()
    {   //Referencias a componentes
        sp = gameObject.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
       
    }
    void FixedUpdate()

    {   
        if (canwalk)
        {
            //Traslacion
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        //Animacion de caminar
        if (walkanim)
        {
            if (Time.time > nextanimtime)
            {
                sp.sprite = walksprites[walkanimcount];
                if (walkanimcount == 0) { walkanimcount = 1; } else { walkanimcount = 0; }
                nextanimtime = Time.time + animspeed * Time.deltaTime;
            }
        }

        //Animacion de Ataque
        if (attackanim)
        {
            if (Time.time > nextanimtime)
            {
                sp.sprite = attacksprites[walkanimcount];
                if (walkanimcount == 0) { walkanimcount = 1; } else { walkanimcount = 0; }
                nextanimtime = Time.time + animspeed * Time.deltaTime;
            }
        }

        if (atacando)
        {
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X))
            {
                if ((transform.rotation.y == 0 && direccion<0) ||(transform.rotation.y < 0 && direccion ==0))
                {
                    dead = true;
                    atacando = false;
                }
                
            }
        }

        if (dead)
        {
            rb.simulated = false;
            sp.sprite = deadsprite;
            transform.Translate(-speed * Time.deltaTime, -speed * Time.deltaTime, 0, Space.Self);
            Destroy(this.gameObject, 2f);
        }





    }
    //Evento de colision
    private void OnTriggerEnter2D(Collider2D other)
    {   //Colision con otro enemigo
        if (other.CompareTag("Enemigo"))
        {
            canwalk = false;
            attackanim = false;
        }
        //Colision con el jugador
        if (other.name == "Jugador" )
        {
            canwalk = false;
            attackanim = false;
            sp.sprite = attacking;
        }

        //Preparacion para el ataque
        if (other.CompareTag("proximidad"))
        {
            walkanim = false;
            attackanim = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name != "Jugador")
        {
            attackanim = true;
            canwalk = true;
        }

       
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Jugador")
        {
            direccion = other.gameObject.transform.rotation.y;
            atacando = true;
        }
    }
}