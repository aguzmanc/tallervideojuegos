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

    //Vida
    [Header("Vida")]
    public int Health = 500;

    void Start()
    {
        barraDeVida = fill.GetComponent<RectTransform>();
        //slider = GameObject.Find("HealthBar").GetComponent<Slider>();
        //Fill.color=gradient.Evaluate(1);
        //SetHealth(Health);
       
    }

    private void Update()
    {
       
    }
    public void SetHealth(int health)
    {
        barraDeVida.anchorMin = new Vector2(health / 500, 1);
        

    }
}
