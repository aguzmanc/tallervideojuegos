using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDongus : MonoBehaviour
{

    public int health = 100;
    public Gradient hit;
    public int enemyDamage = 50 ;

    private Collider2D col;
    //private Animator animat;
    //public AnimationClip death;


    private void Start()
    {
        col = GetComponent<Collider2D>();
   
    }

    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }

    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHP player = collision.collider.GetComponent<PlayerHP>();
        if (player != null)
        {
            player.damagePlayer(enemyDamage);
        }
    }*/

    void Die ()
    {
        Destroy(gameObject);
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Background")
        {
            Physics2D.IgnoreCollision(collision.collider, col);
        }     
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {

       if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHP>().DamagePlayer(enemyDamage);
            Debug.Log("Dañando");
        }
        if (collision.gameObject.tag == "Background")
        {
            Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), col);
        }
    }

}
