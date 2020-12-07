using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public float radiusPlayer;
    public float radiusBase;
    public float speed;

    GameObject player;
    GameObject house;

    Vector3 initialPosition;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        house = GameObject.FindGameObjectWithTag("Base");

        initialPosition = transform.position;
    }


    void Update()
    {
        Vector3 target = initialPosition;

        float dist = Vector3.Distance(player.transform.position, transform.position);

        /*if(dist < radiusBase)
        {
            target = house.transform.position;
        }
        else
        {
            target = player.transform.position;
        }*/


        if (dist < radiusPlayer)
        {
            target = player.transform.position;
        }

        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);

        Debug.DrawLine(transform.position, target, Color.green);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radiusPlayer);

        /*Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusBase);*/
    }
}
