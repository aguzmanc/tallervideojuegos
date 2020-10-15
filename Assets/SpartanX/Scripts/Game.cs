using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    //Variables de juego
    public float health = 1;
    int lifes;
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
    public AudioClip muerte;
    public AudioClip gameover;
    AudioSource Asource;

    //Textos
    public Text lifetext;
    public Text timertext;
    public Text readytext;
    public Text gameovertext;

    //Variables de control
    float contador;
    bool timerenabled=false;
    bool playonce = true;
    
    void Start()
    {
        gameovertext.enabled = false;
        lifes = vidas.lifes;
        //Deshabilita al jugador
        jugador.SetActive(false);
       
        //Crea el nivel de juego repitiendo el background
        for (int i = 1; i < 8; i++)
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

        //Si la vida es 0 o menos reinicia el juego
        if (health <= 0 || timer<=0)
        {if (playonce)
            {
                Asource.Stop();
                Asource.PlayOneShot(muerte);
               
                playonce = false;
                vidas.lifes--;
                lifes--;
            }
            Destroy(GameObject.FindWithTag("Enemigo"));
            StartCoroutine("Reinicia");
        }

        //Actualiza los valores de UI
        if (vidas.lifes > 0)
        {
            lifetext.text = "-" + (vidas.lifes - 1);
        }
        
        if (timer >= 0)
        {
            timertext.text = "" + timer;
        }
        
    }

    IEnumerator Wait5seconds()
    {
        
        yield return new WaitForSeconds(5);
       
    }

    IEnumerator Reinicia()
    {
        
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
