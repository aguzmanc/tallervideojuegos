using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rrIAJet : MonoBehaviour
{
    float VeloJet = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        VeloJet = 5f;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(VeloJet, 0, 0);
        //controlador que cambia posicion de jet cuando llega al margen
        if (transform.position.x < -1.65f ||transform.position.x > 1.65f)
        {
            Debug.Log("jet salio de la pantalla");
            Destroy(this);
        }
    }
}
