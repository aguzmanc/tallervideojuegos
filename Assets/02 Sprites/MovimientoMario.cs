using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoMario : MonoBehaviour
{
    [Header("Parametros de entrada")]
    public int numeroCuadros;
    public Sprite cuadro1;
    public Sprite cuadro2;


    [Header("Curioseando valores (no tocar)")]
    public int n;
    public int acumulador;
    public int segundos;
    public SpriteRenderer rend;

    

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();

        rend.sprite = cuadro1;

        n = 0;
        acumulador = 0;
        segundos = 0;
    }

    void Update()
    {
        acumulador = acumulador + 1;


        if(acumulador >= numeroCuadros)
        {
            acumulador = 0;

            // hacer algo cada segundo
            segundos = segundos + 1;

            // cambiar de cuadro (sprite)
            if(n==0){
                rend.sprite = cuadro2;
                n=1;
            } else {
                rend.sprite = cuadro1;
                n = 0;
            }
        }
    }
}
