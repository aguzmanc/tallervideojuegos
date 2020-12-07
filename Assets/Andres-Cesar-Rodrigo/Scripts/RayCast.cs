using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public float radiusPlayer;
    public float radiusBase;
    public float speed;

    private EnemyAnimations anim;

    GameObject player;
    GameObject house;

    Vector3 initialPosition;

    void Start()
    {
        anim = FindObjectOfType<EnemyAnimations>();
        player = GameObject.FindGameObjectWithTag("Player");
        house = GameObject.FindGameObjectWithTag("Base");

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


        /*if (dist < radiusPlayer)
        {
            target = player.transform.position;
        }*/

        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);

        Debug.DrawLine(transform.position, target, Color.green);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.animator.SetBool("isAttacking", true);
        anim.AttackFalse();
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radiusPlayer);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusBase);
    }
}
