using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteJugador : MonoBehaviour
{

    private Rigidbody rb;
    public float velCaida;
    private Animator ju;
    public bool muerte;
    bool animacion;
    void Start()
    {
        ju = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        if (muerte)
        {
            ju.SetBool("muerte", true);
            StartCoroutine("Espera");


        }
        if (animacion)
        {
            Destroy(this.gameObject, 3);
            transform.Translate(Vector3.down * 4 * Time.deltaTime);
        }
    }
    IEnumerator Espera()
    {
        yield return new WaitForSeconds(2f);
        animacion = true;
    }


  
}
