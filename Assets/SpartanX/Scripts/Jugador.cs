using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Jugador : MonoBehaviour
{   //Estados
    public bool atacado = false;
    public bool canwalk = true;
    public bool punching = false;
    public bool kicking = false;
    public bool agachado = false;

    //Collider Objects

    //Values
    public float speed;
    public float walkingspeed;
    public float hitcounter;
    public float hittime;
    public float walkingAnimSpeed;
    public int walkingAnimCounter;
    public float nextAnimTime;


    //Componentes
    private Game gm;
    public GameObject control;
    SpriteRenderer sp;

    //Sonido
    AudioSource AS;
    public AudioClip golpe;
    public AudioClip patada;
    public AudioClip muerte;

    //Sprites
    public Sprite[] walk;
    public Sprite punch;
    public Sprite kick;
    public Sprite enguardia;
    public Sprite agachadosp;
    public Sprite patadaagachada;


    void Start()
    {
        gm = control.GetComponent<Game>();
        sp = GetComponent<SpriteRenderer>();
        AS = GetComponent<AudioSource>();
    }

    
    void FixedUpdate()

    {   //Control de salud
        if (atacado)
        {
            gm.health -= 0.001f;           
        }


        //Control de movimiento y Rotacion
        
        
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                if (canwalk) { transform.Translate(speed * Time.deltaTime, 0, 0); }
                Walkinganimation();
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                if (canwalk) { transform.Translate(speed * Time.deltaTime, 0, 0); }
                Walkinganimation();
            }

        //Agachado
        if (Input.GetKey(KeyCode.DownArrow))
        {
            agachado = true;
            sp.sprite = agachadosp;
            canwalk = false;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            agachado = false;
            sp.sprite = walk[1];
            canwalk = true;
        }

        //Golpe
        if (Input.GetKeyDown(KeyCode.Z))
        {
            sp.sprite = punch;
            punching = true;
            hitcounter = 0;
            AS.PlayOneShot(golpe);
            canwalk = false;
            

        }
        if (punching)
        {
            if (hitcounter > hittime)
            {
                punching = false;
                if (agachado)
                {
                    sp.sprite = agachadosp;
                }
                else
                {
                    sp.sprite = enguardia;
                }
                
                canwalk = true;
            }
            hitcounter += Time.deltaTime;
        }


        //Patada
        if (Input.GetKeyDown(KeyCode.X))
        {
           
            if (agachado)
            {
                sp.sprite = patadaagachada;
            }
            else
            {
                sp.sprite = kick;
            }
            kicking = true;
            canwalk = false;
            hitcounter = 0;
            AS.PlayOneShot(patada);
        }
        if (kicking)
        {
            if (hitcounter > hittime)
            {
                kicking = false;
                canwalk = true;
                punching = false;
                if (agachado)
                {
                    sp.sprite = agachadosp;
                }
                else
                {
                    sp.sprite = enguardia;
                }
               
            }
            hitcounter += Time.deltaTime;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {if(!kicking || !punching)
        {
            atacado = true;
            canwalk = false;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!kicking || !punching)
        {
            atacado = false;
            canwalk = true;
        }
    }

    void Walkinganimation()
    {
        if (Time.time > nextAnimTime)
        {
            sp.sprite = walk[walkingAnimCounter];
            if (walkingAnimCounter == 0) { walkingAnimCounter = 1; } else {walkingAnimCounter = 0; }
            nextAnimTime = Time.time + walkingAnimSpeed * Time.deltaTime;
        }
    }

}
