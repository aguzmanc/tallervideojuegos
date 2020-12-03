using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
   
    public GameObject Bala;
    public Transform instanciador;
    public float timp;
    public float t = 100;
    void Start()
    {
        
    }

    
    void Update()
    {
        timp += 1;
        if (Input.GetKeyDown(KeyCode.Mouse0) && timp > t)
        {
            
            Instantiate(Bala,instanciador.position,instanciador.rotation);
            timp = 0;
        }
    }
}
