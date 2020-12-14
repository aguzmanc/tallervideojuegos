using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int life = 3;
    public int health = 100;
    public float invincibleTimeAfterHurt = 2f;
    public Transform respawnPoint;
    public GameObject playerPrefab;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    private AnimController anim;

    public void DamagePlayer(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            life--;
            if (life == 2)
            {
                heart3.SetActive(false);
            }

            if (life == 1)
            {
                heart2.SetActive(false);
            }

            if (life == 0)
            {
                heart1.SetActive(false);
            }

            Respawn();
            if (life <= 0)
            {
                Die();
                Debug.Log("GAME OVER");
            }
        }
        else
        {
            anim.TriggerHurt(invincibleTimeAfterHurt);
        }

    }

    void Respawn ()
    {
        StartCoroutine(RespawnTime());
        health = 100;
        playerPrefab.transform.position = respawnPoint.transform.position;
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

    IEnumerator RespawnTime ()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(true);
    }
}
