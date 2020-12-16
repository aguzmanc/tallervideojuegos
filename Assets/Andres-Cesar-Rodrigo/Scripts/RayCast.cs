using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public float radiusPlayer;
    public float radiusBase;
    public float speed;
    public Animator dongus;


    GameObject player;
    GameObject house;

    Vector3 initialPosition;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        house = GameObject.FindWithTag("Base");
        initialPosition = transform.position;
    }


    void Update()
    {
        Vector3 target = initialPosition;

        float dist = Vector3.Distance(player.transform.position, transform.position);
        float dist2 = Vector3.Distance(house.transform.position, transform.position);

        if (dist < radiusPlayer)
        {
            target = player.transform.position;
            if (dist2 < radiusBase)
            {
                target = house.transform.position;
            }
        }

        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);

        Debug.DrawLine(transform.position, target, Color.green);

        if (dist == 0)
        {
            Debug.Log("You Lose");
            Time.timeScale = 0f;
            enabled = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radiusPlayer);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusBase);
    }
}
