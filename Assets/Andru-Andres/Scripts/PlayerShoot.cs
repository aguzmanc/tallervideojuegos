using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float velocidadBala;
    public GameObject Bala;
    void Start()
    {
        
    }

    
    void Update()
    {
        Bala.transform.Translate(Vector3.forward * velocidadBala * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            Instantiate(Bala,transform.parent);
            
        }
    }
}
