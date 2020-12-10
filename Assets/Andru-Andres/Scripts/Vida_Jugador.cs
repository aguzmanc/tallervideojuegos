using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida_Jugador : MonoBehaviour
{
    public float vidaPlayer = 300;
    public float vidmax = 300;
    public float corazones = 3;
    public Image barraDeVida;
    public Slider vidaSlider;
    public float DañoDongunis;
    void Start()
    {
        
    }

    void Update()
    {
        ataqueDongus();
        
    }
  
    private void OncollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("enemigo"))
        {
            vidaSlider.value -= DañoDongunis;
           // Destroy(collision.gameObject);
            ataqueDongus();
            Debug.Log("perdiendo vida");
        }
    }
  void ataqueDongus ()
    {
        vidaPlayer = Mathf.Clamp(vidaPlayer, 0, vidmax);
        barraDeVida.fillAmount = vidaPlayer / vidmax;
        if (vidaPlayer == 0)
        {
            Destroy(gameObject);
        }
    }
}
