using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiPrimerComportamiento : MonoBehaviour
{
    int edad;
    

    // Start es llamado antes del primer Update del primer cuadro (frame)
    void Start()
    {
        name = "Rogelio";
        edad = 0;
    }

    // Update es llamado una vez cada frame
    void Update()
    {
        edad = edad+1;

        name = "Rogelio: " + edad;
    }
}
