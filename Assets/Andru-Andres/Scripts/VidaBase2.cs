using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaBase2 : MonoBehaviour
{
    public float vida = 150;
    public bool vb2 = true;
    public Image barraDeVida;
 
    void Start()
    {
      
    }

    void Update()
    {

        vida = Mathf.Clamp(vida, 0, 150);
        barraDeVida.fillAmount = vida / 150;


        if (vida == 0)
        {
            vb2 = false;    
          //  Destroy(gameObject);

        }

    }
}
