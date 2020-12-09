using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Slider slider;
    //public Gradient gradient;
    //public Image Fill;
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
        //slider = GameObject.Find("HealthBar").GetComponent<Slider>();
        //Fill.color=gradient.Evaluate(1);
        //SetHealth(Health);
       
    }

    private void Update()
    {
       
    }
    //public void SetHealth(int health)
    //{
    //    slider.value = health;
    //    Fill.color = gradient.Evaluate(slider.normalizedValue);
       
    //}
}
