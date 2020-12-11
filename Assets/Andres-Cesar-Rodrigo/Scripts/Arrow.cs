using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float arrowSpeed = 20f;
    public int arrowDamage = 45;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.up * arrowSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyDongus enemy = collision.GetComponent<EnemyDongus>();
        if (enemy != null)
        {
            enemy.TakeDamage(arrowDamage);
        }

        Destroy(gameObject);
    }
}

