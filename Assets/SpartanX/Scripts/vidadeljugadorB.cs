using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidadeljugadorB : MonoBehaviour
{
    bool atacado;
    public GameObject control;
    Game gm;
    private Animator Detect;

    void Start()
    {
        gm = control.GetComponent<Game>();
        Detect = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (atacado)
        {
            gm.health -= 0.001f;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        atacado = true;
       

        //Detect.SetBool("golpeado", true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        atacado = false;

        //Detect.SetBool("golpeado", false);
    }
}
