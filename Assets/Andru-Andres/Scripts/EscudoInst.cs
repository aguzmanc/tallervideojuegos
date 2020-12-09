using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoInst : MonoBehaviour
{
    public bool activo;
    public GameObject escudo;
    void Start()
    {
        
    }

   
    void Update()
    {
        escudo.transform.localPosition = Vector3.zero;
        if(Input.GetKey(KeyCode.E) && activo==true)
        {
            escudo.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("escudo"))
        {
            activo = true;
        }

    }
}
