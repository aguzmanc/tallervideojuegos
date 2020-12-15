using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Dongus : MonoBehaviour
{
    public Animator anim;
    GameObject Player;
    public GameObject dongus;
    GameManager gameManager;
    Rigidbody rb;
    AudioSource AS;
    public AudioClip Enemysound;
   
    [Header ("Movimiento")]
    public float velocity = 3f;

    [Header("Vida")]
    public int HP=95;

    [Header("Ataque")]
    public int damage = 30;
    public float velAttk=2f;

    [Header("Objetivos")]
    GameObject objetivo;
    public GameObject[] objetivos;
    public float probabilidadJugador=80;
    public float probabilidadBases=20;
    int indiceObjetivo;
 
    [Header("Spawneo de Objetos")]
    public GameObject[] items;
    public int[] probabilidad;

    //Estados
    public bool caminando = true;
    public bool atacando = false;
    public bool dead = false;
    private void Awake()
    {
        EligeObjetivo();
    }
    void Start()
    {//Referencia al objeto jugador y al GameManager
        Player = GameObject.Find("Jugador");
        gameManager = GameObject.Find("GameControl").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        AS = GetComponent<AudioSource>();
    }

    
    void Update()
        //Camina hacia el objetivo
    {  if (caminando && !dead)
        {   //Desactiva la animacion de atacar y activa la animacion de caminar
            anim.SetBool("atacando", false);
            anim.SetBool("caminando", true);
            
            transform.LookAt(objetivo.transform); //Mira siempre hacia el objetivo
            transform.Translate(Vector3.forward * velocity * Time.deltaTime);//Avanza siempre hacia adelante
        }
        
        //Si su objetivo muere, cambia de objetivo
        if (objetivo != null && objetivo.name !="Jugador")//Si tiene como objetivo una base
        {
            Base scriptBase;
            scriptBase = objetivo.GetComponent<Base>();
            if (!scriptBase.alive)//si esta base no esta viva
            {//Disminuye el contador de bases vivas del Game Manager
                GameManager.basesVivas -= 1;
                //deja de atacar
                atacando = false;
                //hace que el Dongus ya no tenga objetivo
                objetivo = null;
               
                //Si aun hay bases vivas
                if (GameManager.basesVivas > 0)
                {   //Hace que el dongus camine
                    caminando = true;
                    //Elige un nuevo objetivo
                    EligeObjetivo();

                }
                else
                {   //Si ya no hay bases vivas entonces cambia el booleano de gameOver del Game Manager
                    GameManager.gameOver = true;
                }                
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {       
            //Colision con flecha
        if (other.gameObject.CompareTag("Flecha"))
        {
            if (!dead)
            {
                AS.PlayOneShot(Enemysound, 0.2f);
            }
           
            //caminando = false;
            HP -= GameManager.dañoDeFlecha;

            //Muerte del Dongus
            if (HP <= 0)
            {   //Cambia los booleanos de estado
                caminando = false;
                atacando = false;
                dead = true;

                //Cambia las animaciones
                anim.SetBool("caminando", false);
                anim.SetBool("atacando", false);
                anim.SetBool("muerte", true);
               
                //Destruye el objeto
                Destroy(this.gameObject, 3f);
               
                ItemSpawner();
            }
        }  

        //Colision con el jugador y Ataque
        if (other.gameObject.CompareTag("jugador"))
        {if (!atacando && !dead)
            {
                objetivo = objetivos[0];
                caminando = false;
                
                anim.SetBool("atacando", true);
                anim.SetBool("caminando", false);               
            }                    
        }

        //Colision con Bases
        if (!other.gameObject.CompareTag("jugador"))
        {   
            //Si la base es su objetivo
            if (other.gameObject == objetivo)
            {
                caminando = false;
                rb.isKinematic = true;
                anim.SetBool("atacando", true);
                anim.SetBool("caminando", false);         
            }
        }           
    }

    private void OnTriggerExit(Collider other)
        //Si deja de tocar al jugador
    {if (other.tag == "jugador")
        {
            //Hace que el Dongus camine
        caminando = true;
        
        anim.SetBool("caminando", true);
        anim.SetBool("atacando", false);
        
        }
        
    }
    void ItemSpawner()
    {
        int azar = Random.Range(1, 101);
        Debug.Log(azar);
        //1-15
       if (azar>0 && azar <= probabilidad[0])
        {
            Instantiate(items[0],transform.position,Quaternion.identity);
           
        }
       //16-25
        if(azar>probabilidad[0] && azar <= probabilidad[0] + probabilidad[1])
        {
            Instantiate(items[1], transform.position, Quaternion.identity);
           
        }
        //26-35
        if (azar > probabilidad[0]+probabilidad[1] && azar <= probabilidad[0] + probabilidad[1]+probabilidad[2])
        {
            if (GameManager.PowerShotEnabled)
            {
                Instantiate(items[2], transform.position, Quaternion.identity);
            }           
        }
        //36-45
        if (azar > probabilidad[0] + probabilidad[1]+probabilidad[2] && azar <= probabilidad[0] + probabilidad[1] + probabilidad[2]+probabilidad[3])
        {
            if (GameManager.FireballEnabled)
            {
                Instantiate(items[3], transform.position, Quaternion.identity);
            }                          
        }
        
    }

    void EligeObjetivo()
    {
        //probalidad al azar
        indiceObjetivo = Random.Range(1, 11);
        //Si el numero obtenido es menor a la probabilidad de Jugador
        if (indiceObjetivo < probabilidadJugador / 10)
        {
            //Hace que el nuevo objetivo sea el jugador
            objetivo = objetivos[0];
        }
        else
        {//Si el numero obtenido es mayor a la probabilidad del Jugador
         //y mientras no haya un objetivo elegido
            while (objetivo == null)
            {   //elige una base al azar
               indiceObjetivo = Random.Range(1, 4);
               Base scriptBase;
                scriptBase = objetivos[indiceObjetivo].GetComponent<Base>();
                //Si la base esta viva
               if (scriptBase.alive)
                {//hace que esta base sea el nuevo objetivo
                 //si la base no esta viva el objetivo seguira siendo null y se repetira el ciclo.
                    objetivo = objetivos[indiceObjetivo];
                }               
            }
        }
        Debug.Log(objetivo);
    }

    void AtacarInicio()
    {
        atacando = true;
    }
    void AtacarFin()
    {        
        atacando = false;
    }
}
