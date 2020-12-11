using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    private Transform Cuerpo;
    private Rigidbody2D Fuerza;
    public GameObject BalaPrefab;
    public float FuerzaDeDisparo;
    public Transform Posicionjugador;
    // Start is called before the first frame update
    void Start()
    {
        Cuerpo = GetComponent<Transform>();
        Fuerza = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    public Vector3 positionmouse;

    void Update()
    {
        //positionmouse = Input.mousePosition;
        positionmouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Cuerpo.position = new Vector2(positionmouse.x, positionmouse.y);



        if (Input.GetMouseButtonDown(0))
        {

            Instantiate(BalaPrefab,(Posicionjugador.position), Quaternion.identity);



        }
        
    }
}
