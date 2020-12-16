using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPowerShot : MonoBehaviour
{
    
    public int duracion;
    void Start()
    {
        
        Destroy(gameObject, duracion);

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Jugador")
        {   
             GameManager.PowerShot += 1;
            
            Destroy(gameObject);            
        }
    }
}
