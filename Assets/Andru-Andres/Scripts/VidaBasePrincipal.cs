using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VidaBasePrincipal : MonoBehaviour
{
    public float vida = 250;
    public bool vbCatle = true;
    public Image barraDeVida;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        vida = Mathf.Clamp(vida, 0, 250);
        barraDeVida.fillAmount = vida / 250;


        if (vida == 0)
        {
            vbCatle = false;
            //Destroy(gameObject);
        
        }

    }
}