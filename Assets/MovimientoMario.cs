using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoMario : MonoBehaviour
{
    public SpriteRenderer rend;

    public Sprite cuadro1;
    public Sprite cuadro2;

    public int n;


    void Start()
    {
        rend = GetComponent<SpriteRenderer>();

        rend.sprite = cuadro1;

        n = 0;
    }

    void Update()
    {
        if(n==0){
            rend.sprite = cuadro2;
            n=1;
        } else {
            rend.sprite = cuadro1;
            n = 0;
        }
        
        
    }
}
