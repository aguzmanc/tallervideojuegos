using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    public Image fill;
    RectTransform barraDeVida;
    public int Escudo;
    public int Metralla;
    public int Misil;
    public int Granada;
    public static int dañoDeFlecha = 50;
    public static int basesVivas = 3;
    public static bool gameOver = false;
    public Text gameOverText;

    //Vida
    [Header("Vida")]
    public int Health = 500;

    void Start()
    {
        barraDeVida = fill.GetComponent<RectTransform>();


    }

    private void Update()
    {
       if (gameOver)
        {
            gameOverText.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void SetHealth(float health)
    {
        
        barraDeVida.anchorMax = new Vector2(health / 500, 1);
        

    }
}
