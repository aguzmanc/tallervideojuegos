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
        bool rrSeMueve = false;
        float rrDirEnemy = 0.3f;
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
        if (rrcontadorpatrulla > rrcomienzaPatrulla)
        {
           rrSeMueve = true;
            transform.Translate(rrEnMovimiento, 0, 0);
        }
        if (rrSeMueve == true)
        {
            rrEnMovimiento = rrDirEnemy * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.tag == "rrborde")
        {
            rrDirEnemy = -rrDirEnemy;
            //Debug.Log("detectado");
        }
        if  (otro.tag == "rrProyectil")
        {
            Destroy(this.gameObject);
            Debug.Log("deveria explotar");
        }
    }

}
