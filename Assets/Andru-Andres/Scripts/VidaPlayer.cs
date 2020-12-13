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
        if(vida==0)
        {
            Destroy(gameObject);
            SoundSystem.instance.PlayDeath();
            SoundSystem.instance.PlayGameOver();
        }
    }
}
