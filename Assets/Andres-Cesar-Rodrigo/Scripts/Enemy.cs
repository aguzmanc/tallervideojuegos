using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;
    private EnemyAnimations anim;

    //private Animator animat;
    //public AnimationClip death;

    void Start()
    {
        anim = FindObjectOfType<EnemyAnimations>();
    }

    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            anim.animator.SetBool("isDead", true);
            Die();
        }
    }

    void Die ()
    {
        Destroy(gameObject, anim.death.length);
    }
}
