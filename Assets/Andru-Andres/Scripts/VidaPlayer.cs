using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    public float vida = 500;

    public Image barraDeVida;
    void Start()
    {   
    }
    void Update()
    {
        vida = Mathf.Clamp(vida, 0, 500);
        barraDeVida.fillAmount = vida / 500;

    }
}
