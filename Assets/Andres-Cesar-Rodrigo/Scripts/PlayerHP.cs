using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int health = 100;
    public float invincibleTimeAfterHurt = 2f;

    private AnimController anim;

    public void DamagePlayer(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
        else
        {
            anim.TriggerHurt(invincibleTimeAfterHurt);
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyDongus enemy1 = collision.collider.GetComponent<EnemyDongus>();
        if(enemy1 != null)
        {
            DamagePlayer(enemy1.enemyDamage);
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
