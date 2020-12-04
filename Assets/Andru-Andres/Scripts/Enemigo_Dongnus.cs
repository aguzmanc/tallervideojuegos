using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_Dongnus : MonoBehaviour
{
    //variable para la vision velocidad
    public float speed;
    public float vidionRadio;
    GameObject player; //para guardar jugador
    Vector3 initialposition;//posicion inicial
    public float ataque = 30;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initialposition = transform.position;
    }

    void Update()
    {
        Vector3 target = initialposition;

        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < vidionRadio) target = player.transform.position;

        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);

        Debug.DrawLine(transform.position, target, Color.green);


    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, vidionRadio);
    }
}
