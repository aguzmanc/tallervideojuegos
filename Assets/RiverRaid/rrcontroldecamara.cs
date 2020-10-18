using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rrcontroldecamara : MonoBehaviour
{
    public GameObject jugador;
    public Vector3 distanciaCamara;
    void Start()
    {
        transform.LookAt(jugador.transform.position);
        distanciaCamara = transform.position - jugador.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = jugador.transform.position + distanciaCamara;
    }
}
