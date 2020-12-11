using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadaRotacion : MonoBehaviour
{
    public float velRot;
    public float coolDown;
    public float tiempoIns;
    void Start()
    {  
    }

    void OnEnable()
    {
         coolDown = 0;
    }

    private void OnDisable()
    {
        tiempoIns = 0;
    }




    void Update()
    {
       
        transform.Rotate(Vector3.forward * velRot);
        coolDown += Time.deltaTime;
        if (coolDown > 2)
        {
           gameObject.SetActive(false);
        }
    }




    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="enemigo")
        {
            Destroy(other.gameObject);
        }
    }
}
