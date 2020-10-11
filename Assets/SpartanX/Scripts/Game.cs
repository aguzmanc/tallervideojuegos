using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    //Variables de juego
    public float health = 1;
    public int lifes = 2;
    int timer = 2000;

    //Referencia a objetos
    public GameObject HealthBar;
    public GameObject jugador;
    public GameObject background;
    
    //Componentes
    EnemyGenerator generator;

    //Audio
    public AudioClip gameStart;
    public AudioClip backgroundMusic;
    AudioSource Asource;

    //Textos
    public Text lifetext;
    public Text timertext;
    public Text readytext;

    //Variables de control
    float contador;
    bool timerenabled=false;
    
    void Start()
    {   //Deshabilita al jugador
        jugador.SetActive(false);
       
        //Crea el nivel de juego repitiendo el background
        for (int i = 1; i < 10; i++)
        {
            Instantiate(background, new Vector3(-21.8f*i, 2.4f, 1), Quaternion.identity);
        }

        //Referencias a los Componentes
        generator = gameObject.GetComponent<EnemyGenerator>();
        Asource = gameObject.GetComponent<AudioSource>();

        //Musica de inicio
        Asource.PlayOneShot(gameStart,0.2f);
        
        Wait5seconds();

       
    }

   
    void Update()
    {
     //Comienza el juego
        if (Time.time > 5 && Time.time<6)//Despues de 5 segundos
        {
            generator.enabled = true;//activa el generador de enemigos
           if (!Asource.isPlaying)//Si no se reproduce ningun sonido
            {
                Asource.Play(0);//Reproduce el bucle de musica de fondo
            }

            jugador.SetActive(true);//activa el jugador
            timerenabled = true;//activa el temporizador
            readytext.enabled = false;//Desactiva el texto de Ready
        }

        //Contador
        if (timerenabled)
        {
            contador += Time.deltaTime;
            if (contador > 0.05)
            {
                timer -= 1;
                contador = 0;
            }
        }
        
        //Actualiza la barra de vida
        if (health > 0)
        {
            HealthBar.transform.localScale = new Vector3(health, 1, 1);
        }
        
        //Actualiza los valores de UI
        lifetext.text = "-" + lifes;
        timertext.text =""+ timer;
    }

    IEnumerator Wait5seconds()
    {
        
        yield return new WaitForSeconds(5);
       
    }
}
