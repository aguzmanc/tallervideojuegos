using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   //Componentes
    public Image fill;
    RectTransform barraDeVida;
    public GameObject dongus;
    public GameObject[] generators;




    //Audio
    AudioSource AS;
    public AudioSource ASmusic;
    public AudioClip gameOverClip;
    public AudioClip RoundOne;
    public AudioClip EvilLaugh;
    public AudioClip YouWin;
    public AudioClip PlayerDead;

    //PowerUPs
    public static int Escudo;
    public static bool EscudoEnabled;
    public static int Rafaga = 3;
    public static int PowerShot = 3;
    public static bool PowerShotEnabled = true;
    public static int Fireball;
    public static bool FireballEnabled;

    //GameStats
    public static int dañoDeFlecha = 50;
    public static int dañoDeMelee = 15;
    public static int dañoDePowerShot = 200;
    public static int basesVivas = 3;
    public static bool gameOver = false;
    

    //Contadores de Enemigos
    public static int DongusCounter = 100;
    int GroupCounter = 1;
    //Vida
    [Header("Vida")]
    public int Health = 500;

    //UI
    public Text gameOverText;
    public Text RafagaCounterText;
    public Text PowerShotCounterText;
    public Text DongusCounterText;
    public Text WaveText;
    public Text WinText;

    void Start()
    {
        AS = GetComponent<AudioSource>();
        barraDeVida = fill.GetComponent<RectTransform>();
        //Primer Grupo de 20 Dongus
        StartCoroutine ("ShowRoundOne");
        AS.PlayOneShot(RoundOne, 0.3f);
        ASmusic.PlayDelayed(3);
        StartCoroutine(Grupo(dongus,20,2f));
        
    }

    private void FixedUpdate()
    {//Actualiza los contadores de items
        RafagaCounterText.text = "" + Rafaga;
        PowerShotCounterText.text = "" + PowerShot;

        //GAME OVER
        if (basesVivas < 1 || Health<1)
        {
            gameOver = true;
        }
    
        if (gameOver)
        {
            if (Health < 1)
            {
                AS.PlayOneShot(PlayerDead);
            }
            gameOverText.gameObject.SetActive(true);
            
            if (!AS.isPlaying)
            {
                AS.PlayOneShot(gameOverClip, 0.5f);
                Time.timeScale = 0;
            }           
        }
        //Control de grupos
        VerificaGrupos();
        DongusCounterText.text =""+ DongusCounter;
    }

    //Metodo para actualizar la barra de vida
    public void SetHealth(float health)
    {
        
        barraDeVida.anchorMax = new Vector2(health / 360, 1);
    }

    //Generador de Grupos de Enemigos
    IEnumerator Grupo(GameObject Enemy, int numero, float intervalo)
    {
        yield return new WaitForSeconds(7);
        for (int i = 0; i < numero; i++)
        {
            GameObject generator = generators[Random.Range(0, 3)];
            Instantiate(Enemy, generator.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(intervalo);
        }      
    }    


    void VerificaGrupos()
    {
        if (GroupCounter==1 && DongusCounter == 80)
        {
            GroupCounter = 2;
            StartCoroutine ("ShowWave");
                     
            StartCoroutine(Grupo(dongus, 20, 2f));
        }

        if (GroupCounter == 2 && DongusCounter == 60)
        {
            GroupCounter = 3;
            StartCoroutine("ShowWave");
            
            StartCoroutine(Grupo(dongus, 20, 2f));
        }

        if (GroupCounter == 3 && DongusCounter == 40)
        {
            GroupCounter = 4;
            StartCoroutine("ShowWave");
                     
            StartCoroutine(Grupo(dongus, 40, 1.5f));
        }

        //Condicion de victoria
        if (GroupCounter == 4 && DongusCounter < 1)
        {
            WinText.gameObject.SetActive(true);
            AS.PlayOneShot(YouWin);
            GameObject.Find("Jugador").GetComponent<Animator>().SetBool("win", true);
            
        }
    }

    IEnumerator ShowWave()
    {
        yield return new WaitForSeconds(3f);
        AS.PlayOneShot(EvilLaugh,4);
        WaveText.text = "WAVE "+ GroupCounter;
        WaveText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        WaveText.gameObject.SetActive(false);
    }

    IEnumerator ShowRoundOne()
    {
       
        WaveText.text = "WAVE " + GroupCounter;
        WaveText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        WaveText.gameObject.SetActive(false);
    }
}
