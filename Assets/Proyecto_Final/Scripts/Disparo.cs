using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{

    private Transform Cuerpo;
    private Rigidbody2D Fuerza;
    public GameObject BalaPrefab;
    public float FuerzaDeDisparo= 30;
    public Transform Posicionjugador;
    // Start is called before the first frame update
    void Start()
    {
        Cuerpo = GetComponent<Transform>();
        Fuerza = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 positionmouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Cuerpo.position = new Vector2(positionmouse.x, positionmouse.y);



        if (Input.GetMouseButtonDown(0))
        {

            Instantiate(BalaPrefab, new Vector3(Posicionjugador.position.x, Posicionjugador.position.y, Posicionjugador.position.z), Quaternion.identity);



        }
    }
}
