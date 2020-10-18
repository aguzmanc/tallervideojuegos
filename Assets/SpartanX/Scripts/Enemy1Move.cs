using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy1Move : MonoBehaviour
{
    //Movimiento
    public float speed;
    float direccion;

    //Sprites
    public Sprite attacking;
    public Sprite[] walksprites;
    public Sprite[] attacksprites;
    public Sprite deadsprite;
    SpriteRenderer sp;
    public GameObject texto100;

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

    //Components
    Rigidbody2D rb;
    AudioSource AS;
    public AudioClip hit;
    Enemy1Move enem;
    



    void Start()
    {   //Referencias a componentes
        sp = gameObject.GetComponent<SpriteRenderer>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        AS= gameObject.GetComponent<AudioSource>();

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
            enem = other.gameObject.GetComponent<Enemy1Move>();
            if (enem.atacando)
            {
                canwalk = false;
                attackanim = false;
                sp.sprite = attacking;
                atacando = true;
            }
           
        }
        //Colision con el Cuerpo del jugador
        if (other.CompareTag ("cuerpo"))
        {
            canwalk = false;
            attackanim = false;
            sp.sprite = attacking;
            atacando = true;
        }

        //Preparacion para el ataque
        if (other.CompareTag("proximidad"))
        {
            walkanim = false;
            attackanim = true;
            
        }

        if (other.CompareTag("golpe"))
        {
            dead = true;
            atacando = false;
            AS.PlayOneShot(hit);
            vidas.score += 200;
        }

        if ( other.CompareTag("patada"))
        {
            dead = true;
            atacando = false;
            AS.PlayOneShot(hit);
            vidas.score += 100;
            Instantiate(texto100, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }




    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag ("Enemigo"))
        {
            attackanim = true;
            canwalk = true;
            atacando = false;
        }

       
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag ("cuerpo"))
        {
            direccion = other.gameObject.transform.rotation.y;
            atacando = true;
        }
    }
}