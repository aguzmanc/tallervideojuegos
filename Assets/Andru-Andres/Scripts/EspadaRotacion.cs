using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadaRotacion : MonoBehaviour
{
    public float velRot;
    void Start()
    {
        
    }

   
    void Update()
    {
        transform.Rotate(Vector3.forward * velRot );

    }




    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="enemigo")
        {
            Destroy(other.gameObject);
        }
    }
}
