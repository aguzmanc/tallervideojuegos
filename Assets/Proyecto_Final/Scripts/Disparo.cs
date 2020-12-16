using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{

    private Transform Cuerpo;
    private Rigidbody2D Fuerza;
    public GameObject BalaPrefab;
    public float FuerzaDeDisparo =500;
    public Transform Posicionjugador;
    // Start is called before the first frame update
    void Start()
    {
        Cuerpo = GetComponent<Transform>();
        Fuerza = GetComponent<Rigidbody2D>();
    }
    public Vector3 positionmouse;
    public Vector3 mouse;
    // Update is called once per frame
    void Update()
    {
        mouse = Input.mousePosition;
        positionmouse = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x,mouse.y,10));
        Cuerpo.position = positionmouse;


        if (Input.GetMouseButtonDown(0))
        {

            Instantiate(BalaPrefab, new Vector3(Posicionjugador.position.x, Posicionjugador.position.y, Posicionjugador.position.z), Quaternion.identity);



        }
    }
}
