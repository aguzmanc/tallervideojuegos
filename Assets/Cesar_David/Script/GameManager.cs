using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    public Image fill;
    RectTransform barraDeVida;
    AudioSource AS;
    public AudioClip gameOverClip;
    public GameObject dongus;
    public GameObject[] generators;


    //PowerUPs
    public static int Escudo;
    public static bool EscudoEnabled;
    public static int Rafaga = 3;
    public static int PowerShot;
    public static bool PowerShotEnabled;
    public static int Fireball;
    public static bool FireballEnabled;

    //GameStats
    public static int dañoDeFlecha = 50;
    public static int dañoDeMelee = 15;
    public static int basesVivas = 3;
    public static bool gameOver = false;
    public Text gameOverText;

    //Contadores de Enemigos
    public static int DongusCounter = 100;
    int GroupCounter = 1;
    //Vida
    [Header("Vida")]
    public int Health = 500;

    //UI
    public Text RafagaCounterText;
    public Text DongusCounterText;


    void Start()
    {
        AS = GetComponent<AudioSource>();
        barraDeVida = fill.GetComponent<RectTransform>();
        //Primer Grupo de 20 Dongus
        StartCoroutine(Grupo(dongus,20,2f));
        
    }

    private void Update()
    {//Actualiza los contadores de items
        RafagaCounterText.text = "" + Rafaga;
        if (basesVivas < 1 || Health<1)
        {
            gameOver = true;
        }
    //Verifica si el juego ha terminado
        if (gameOver)
        {
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
        Debug.Log(health);
        barraDeVida.anchorMax = new Vector2(health / 360, 1);
    }

    //Generador de Grupos de Enemigos
    IEnumerator Grupo(GameObject Enemy, int numero, float intervalo)
    {
        yield return new WaitForSeconds(5);
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
            StartCoroutine(Grupo(dongus, 20, 2f));
        }

        if (GroupCounter == 2 && DongusCounter == 60)
        {
            GroupCounter = 3;
            StartCoroutine(Grupo(dongus, 20, 2f));
        }

        if (GroupCounter == 3 && DongusCounter == 40)
        {
            GroupCounter = 4;
            StartCoroutine(Grupo(dongus, 40, 2f));
        }
    }
}
