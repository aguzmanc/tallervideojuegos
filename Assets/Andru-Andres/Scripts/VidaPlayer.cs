using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    public float vida = 500;
    public int corazones;
    public Image barraDeVida;
    public Image corazon1;
    public Image corazon2;
    public Image corazon3;
  
    void Start()
    {
        corazones = 3;


    }
    void Update()
    {
        vida = Mathf.Clamp(vida, 0, 500);
        barraDeVida.fillAmount = vida / 500;
        if(vida==0)
        {
            DisminucionCorazones();
            SoundSystem.instance.PlayDeath();
            SoundSystem.instance.PlayGameOver();
        }




        if (corazones == 0)
        {
            corazon3.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }



    void DisminucionCorazones()
    {
        corazones -= 1;
        corazon1.gameObject.SetActive(false);
        vida = 500;

        if(corazones ==1)
        {
            corazon2.gameObject.SetActive(false);
        }
    }
}
