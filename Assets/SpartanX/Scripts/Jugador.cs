using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public bool atacado = false;
    public bool canwalk = true;
    Game gm;
    public GameObject control;
    Enemy1Move enem;
    public GameObject enemigo;
    public float speed;
    

    void Start()
    {
        gm = control.GetComponent<Game>();
        enem = enemigo.GetComponent<Enemy1Move>();
    }

    
    void Update()
    {   if (atacado)
        {
            gm.health -= 0.001f;           
        }
       
       
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            if (canwalk) { transform.Translate(speed * Time.deltaTime, 0, 0); }        
        }

        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            if (canwalk) { transform.Translate(speed * Time.deltaTime, 0, 0); }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        atacado = true;
        canwalk = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        atacado = false;
        canwalk = true;
    }
}
