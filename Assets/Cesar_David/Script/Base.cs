using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    GameManager gameManager;
    Dongus Dongusscript;
    public float HPmax;
    float HP;
    public bool alive = true;
    public Image fill;
    RectTransform barraDeVida;
    
    void Start()
    {
        barraDeVida = fill.GetComponent<RectTransform>();
        HP = HPmax;
        
    }

    
    void Update()
    {
        if (alive && HP < 1)
        {           
            alive = false;
            
            GameManager.basesVivas -= 1;
           
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Dongus"))
        {
            Dongusscript = other.gameObject.GetComponent<Dongus>();

            if (Dongusscript.atacando)
            {

                HP -= Dongusscript.damage;
                SetHealth(HP);
                Debug.Log(HP);
                Dongusscript.atacando = false;
            }

        }
    }

    public void SetHealth(float health)
    {
       barraDeVida.anchorMax = new Vector2(health / HPmax, 1);
    }


}
