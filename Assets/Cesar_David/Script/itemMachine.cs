using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemMachine : MonoBehaviour
{
    GameManager gameManager;
    public int duracion;
    void Start()
    {
        gameManager = GameObject.Find("GameControl").GetComponent<GameManager>();
        Destroy(gameObject, duracion);

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "Jugador")
        {if (gameManager.Metralla < 3) { gameManager.Metralla += 1; }
            
            Destroy(gameObject);
            
        }
    }
}