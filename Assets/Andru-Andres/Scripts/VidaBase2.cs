using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaBase2 : MonoBehaviour
{
    public float vida = 150;

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
            Destroy(gameObject);
            SoundSystem.instance.PlayDeath();
            SoundSystem.instance.PlayGameOver();
        }

    }
}
