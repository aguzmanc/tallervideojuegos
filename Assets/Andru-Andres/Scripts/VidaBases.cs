using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaBases : MonoBehaviour
{
    public float vidas = 150;
    public bool vb = true;
    public Image barraDeVida;

    void Start()
    {
    }


    void Update()
    {
        vidas = Mathf.Clamp(vidas, 0, 150);
        barraDeVida.fillAmount = vidas / 150;



        if (vidas == 0)
        {
            vb = false;
           // Destroy(gameObject);
           
        }





    }
}