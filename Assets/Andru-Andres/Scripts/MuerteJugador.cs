using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuerteJugador : MonoBehaviour
{
    private VidaPlayer vida;
    public Image elimando;
    public GameObject gameOver;

   
    void Start()
    {
       vida = GameObject.Find("Jugador").GetComponent<VidaPlayer>();
    }

  
    void Update()
    {
        if(vida.vida==0)
        {
            gameOver.SetActive(true);
            
            elimando.gameObject.SetActive(true);
        }
    }
}
