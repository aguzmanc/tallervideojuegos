using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadaIns : MonoBehaviour
{
    public GameObject espada;
    public Transform posicion;
    public float timepo;
   
    void Start()
    {
        
    }

    
    void Update()
    {

        espada.transform.Translate(transform.position.x, transform.position.y, transform.position.z);
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
           Instantiate(espada,posicion.transform.position,transform.rotation);
           
        }

      
    }
}
