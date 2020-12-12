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
    public float DamageDognis;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        vidaPlayer = Mathf.Clamp(vidaPlayer, 0, vidmax);
        barraDeVida.fillAmount = vidaPlayer / vidmax;
        vidaSlider.value = vidaPlayer / vidmax;
    }
  
    void OncollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="enemigo")
        {
            // SoundSystem.instance.PlayGolpe();
           
            barraDeVida.fillAmount = vidaPlayer -= DamageDognis;
           vidaSlider.value -= DamageDognis;
           // Destroy(collision.gameObject);
     
            Debug.Log("perdiendo vida");
        }
    }
  void ataqueDongus ()
    {
        
        if (vidaPlayer == 0)
        {
            Destroy(gameObject);
        }
    }
}
