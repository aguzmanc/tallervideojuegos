using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
   
    public GameObject Bala;
    public Transform instanciador;
    public float timp;
    public float t ;
   
    void Start()
    {
        
    }

    
    void Update()
    {
        timp += Time.deltaTime ;
        if (Input.GetKey(KeyCode.Mouse0) && timp > t)
        {
            SoundSystem.instance.PlayFlecha();
            Instantiate(Bala,instanciador.position,instanciador.rotation);
            timp = 0;
        }



     
    }

}
