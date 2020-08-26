using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesplazamientoMario : MonoBehaviour
{
    public float velocidad;


    public bool apretado;


    void Start()
    {
        
    }



    void Update()
    {
        
        apretado = Input.GetKey(KeyCode.UpArrow);

        if(apretado) {
            transform.Translate(velocidad,0,0, Space.Self);
        }
        



        /*
        // GetKeyDown solo funciona una vez
        apretado = Input.GetKeyDown(KeyCode.Space);

        if(apretado) {
            Debug.Log("apretado");
        }
        */


        //transform.position = new Vector3(x,0,0); (manipulacion manual)
        //x = x + velocidad;
        //transform.position
        // transform.localPosition  (investigar)
        // Transform  no es igual a transform


        
    }
}
