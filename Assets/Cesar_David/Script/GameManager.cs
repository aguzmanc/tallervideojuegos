using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    public Image fill;
    RectTransform barraDeVida;
    AudioSource AS;
    AudioClip gameOverClip;

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
    public static int basesVivas = 3;
    public static bool gameOver = false;
    public Text gameOverText;

    //Vida
    [Header("Vida")]
    public int Health = 500;

    //UI
    public Text RafagaCounterText;

    void Start()
    {
       
        barraDeVida = fill.GetComponent<RectTransform>();


    }

    private void Update()
    {
        RafagaCounterText.text = "" + Rafaga;
        if (gameOver)
        {
            gameOverText.gameObject.SetActive(true);
            
            if (!AS.isPlaying)
            {
                AS.PlayOneShot(gameOverClip, 0.5f);
                Time.timeScale = 0;
            }
           
        }
    }
    public void SetHealth(float health)
    {
        
        barraDeVida.anchorMax = new Vector2(health / 500, 1);
        

    }
}
