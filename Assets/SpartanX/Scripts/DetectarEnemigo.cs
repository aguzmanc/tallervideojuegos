using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarEnemigo : MonoBehaviour
{
    public Animator Detect;
    void Start()
    {

        Detect = GetComponent<Animator>();



    }

    
    void Update()
    {
        
    }




    private void OnCollision(Collision other)
    {
        if(other.gameObject.tag=="Enemigo")
        {
            Debug.Log(other.gameObject.name);
            Detect.SetBool("golpeado",true);

        }
      
    }
}
