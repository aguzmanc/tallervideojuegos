using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dongus : MonoBehaviour
{
    GameObject Player;
    GameManager gameManager;
    [Header ("Movimiento")]
    public float velocity = 3f;

    [Header("Vida")]
    public int HP=95;

    [Header("Ataque")]
    public int daño = 30;
    public float velAttk=0.7f;
    
    [Header("Objetivos")]
    public float probabilidadJugador=80;
    public float probabilidadBases=90;

    [Header("Spawneo de Objetos")]
    public GameObject[] items;
    public int[] probabilidad;

   
    void Start()
    {
        Player = GameObject.Find("Jugador");
        gameManager = GameObject.Find("GameControl").GetComponent<GameManager>();
    }

    
    void Update()
    {
        transform.LookAt(Player.transform);
        transform.Translate(Vector3.forward*velocity*Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("colision");
        //Colision con flecha
        if (other.gameObject.name=="Flecha")
        {

            HP -= GameManager.dañoDeFlecha;
            if (HP <= 0)
            {
                Destroy(this.gameObject);
                //ItemSpawner();
            }
        }
   
        

        //if (collision.gameObject.CompareTag("jugador"))
        //{
        //    gameManager.Health -= daño;
        //    gameManager.SetHealth(gameManager.Health);
        //}
    }

    //private void OnTriggerEnter2D(Collider collision)
    //{
    //    if (collision.CompareTag("playerBullet"))
    //    {
    //        Destroy(this.gameObject);
    //        ItemSpawner();
    //    }
    //}

    void ItemSpawner()
    {
        int azar = Random.Range(1, 101);
        //1-10
       if (azar>0 && azar <= probabilidad[0])
        {
            Instantiate(items[0],transform.position,Quaternion.identity);
           
        }
       //11-20
        if(azar>probabilidad[0] && azar <= probabilidad[0] + probabilidad[1])
        {
            Instantiate(items[1], transform.position, Quaternion.identity);
           
        }
        //21-30
        if (azar > probabilidad[0]+probabilidad[1] && azar <= probabilidad[0] + probabilidad[1]+probabilidad[2])
        {
            Instantiate(items[2], transform.position, Quaternion.identity);
           
        }
        //31-45
        if (azar > probabilidad[0] + probabilidad[1]+probabilidad[2] && azar <= probabilidad[0] + probabilidad[1] + probabilidad[2]+probabilidad[3])
        {
            Instantiate(items[3], transform.position, Quaternion.identity);
           
        }
        //46-50
        if (azar > probabilidad[0] + probabilidad[1] + probabilidad[2]+probabilidad[3] && azar <= probabilidad[0] + probabilidad[1] + probabilidad[2] + probabilidad[3]+probabilidad[4])
        {
            Instantiate(items[4], transform.position, Quaternion.identity);
            
        }
    }
}
