using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacked : MonoBehaviour
{
    GameManager gameManager;
    Dongus Dongusscript;

    void Start()
    {
        gameManager = GameObject.Find("GameControl").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.CompareTag("Dongus"))
        { Dongusscript = other.gameObject.GetComponent<Dongus>();
           
            if (Dongusscript.atacando)
            {

            gameManager.Health -= Dongusscript.Damage;
            gameManager.SetHealth(gameManager.Health);
           
            Dongusscript.atacando = false;
            }
           
        }
    }
}
