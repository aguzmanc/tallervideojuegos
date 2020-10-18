using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    //Variables de juego
    public float health = 1;
    int lifes;
    int timer = 1500;

    //Referencia a objetos
    public GameObject HealthBar;
    public GameObject jugador;
    public GameObject background;
    
    
    //Componentes
    EnemyGenerator generator;
    MuerteJugador mj;
  
    

    //Audio
    public AudioClip gameStart;
    public AudioClip backgroundMusic;
    public AudioClip muerte;
    public AudioClip gameover;
    public AudioClip nivelcompletado;
    AudioSource Asource;

    //Textos
    public Text lifetext;
    public Text timertext;
    public Text readytext;
    public Text gameovertext;
    public Text floorcleartext;
    public Text scoretext;

    //Variables de control
    float contador;
    bool timerenabled=false;
    bool playonce = true;
    bool reinicianivel;
    
    void Start()
    {
        mj = jugador.GetComponent<MuerteJugador>();
        gameovertext.enabled = false;
        floorcleartext.enabled = false;
        lifes = vidas.lifes;
        readytext.text = "READY FLOOR " + vidas.floor;
        //Deshabilita al jugador
        jugador.SetActive(false);
       
        //Crea el nivel de juego repitiendo el background
        for (int i = 1; i < 5; i++)
        {
            Instantiate(background, new Vector3(-21.8f*i, 2.4f, 1), Quaternion.identity);
        }

        //Referencias a los Componentes
        generator = gameObject.GetComponent<EnemyGenerator>();
        Asource = gameObject.GetComponent<AudioSource>();

        //Musica de inicio
        if (vidas.lifes > 0)
        {
            Asource.PlayOneShot(gameStart, 0.2f);
        }
        else
        {
            readytext.enabled = false;
            gameovertext.enabled = true;
            
            Asource.PlayOneShot(gameover,0.2f);
        }
        
        
        //Wait5seconds();

       
    }

   
    void Update()
    {
        if (vidas.lifes > 0)
        {
            //Comienza el juego
            if (Time.timeSinceLevelLoad > 5 && Time.timeSinceLevelLoad < 6)//Despues de 5 segundos
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

        //Si la vida o el timer es 0 o menos pierde una vida y reinicia el juego
        if (health < 0 || timer<0)
        {if (playonce)
            {
                Asource.Stop();
                Asource.PlayOneShot(muerte);
                mj.muerte = true;
                playonce = false;
                vidas.lifes--;
                lifes--;
            }
            Destroy(GameObject.FindWithTag("Enemigo"));
            if (!reinicianivel) { StartCoroutine("Reinicia"); }
        }

        //Si el jugador llega al final del nivel reproduce musica y reinicia el juego
        if (jugador.transform.position.x<-90)
        {
            if (playonce)
            {
                timerenabled = false;
                Asource.Stop();
                Asource.PlayOneShot(nivelcompletado);

                playonce = false;
                floorcleartext.enabled = true;
                reinicianivel = true;
                vidas.enemyspeed++;
                vidas.floor++;
                
            }
            Destroy(GameObject.FindWithTag("Enemigo"));
            if (reinicianivel) { StartCoroutine("ReiniciaNivel"); }
            TimeraPuntos();
            VidaaPuntos();
        }
    
        //Actualiza los valores de UI
        if (vidas.lifes > 0)
        {
            lifetext.text = "-" + (vidas.lifes - 1);
        }
        
        if (timer >= 0 )
        {
            timertext.text = "" + timer;
        }

        scoretext.text = "SCORE - "+vidas.score;
    }

    IEnumerator Wait5seconds()
    {
        
        yield return new WaitForSeconds(5);
       
    }

    IEnumerator Reinicia()
    {

        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator ReiniciaNivel()
    {

        yield return new WaitForSeconds(6);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void TimeraPuntos()
    {if (timer > 0)
        {
            timer -= 2;
            vidas.score += 200;
        }
        
   
    }

    void VidaaPuntos()
    {if (health > 0)
        {
            health -= 0.01f;
            vidas.score += 100;
        }
       
    }
}
