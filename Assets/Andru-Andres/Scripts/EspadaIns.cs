using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadaIns : MonoBehaviour
{
    
    public Transform posicion;
    public float velRot;
    
    public float coolDown;
    public float tiempoRot;

    void Start()
    {
    }
     void OnEnable()
     {
        coolDown = 0;
     }

    void OnDisable()
    {
        
    }


    void Update()
    {
        transform.Rotate(Vector3.forward * velRot);
        coolDown += Time.deltaTime;
        if (Input.GetKey(KeyCode.R))
        {
            gameObject.SetActive(true);
        }

        if (coolDown > 2)
        {
            gameObject.SetActive(false);
        }
    }



}


