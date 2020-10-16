using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rrIAEnemyRiver : MonoBehaviour
{
    // Start is called before the first frame update
        float rrAleatorio;
        float rrcomienzaPatrulla;
        float rrcontadorpatrulla;
        float rrEnMovimiento = 0;
    void Start()
    {
        rrAleatorio = Random.Range(1.0f, 10.0f);
        rrcontadorpatrulla = 0.0f;
        rrcomienzaPatrulla = rrAleatorio;
        
    }


    // Update is called once per frame
    void Update()
    {
        rrcontadorpatrulla = rrcontadorpatrulla + 0.01f;
        transform.Translate(rrEnMovimiento, 0, 0);
        if (rrcontadorpatrulla > rrcomienzaPatrulla)
        {
            rrEnMovimiento = Time.deltaTime;
            rrcontadorpatrulla = -10.0f;
        }
    }

    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.tag == "rrborde")
        {
            rrEnMovimiento = -1*Time.deltaTime;
            Debug.Log("detectado");
        }
    }

}
