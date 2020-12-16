using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemRafaga : MonoBehaviour
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
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Jugador")
        { GameManager.Rafaga += 1;
            
          Destroy(gameObject);
            
        }
    }
}