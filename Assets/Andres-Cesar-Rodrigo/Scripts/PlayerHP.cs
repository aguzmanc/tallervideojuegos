using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public float health;
    public float maxHp = 100f;
    public bool inmortal = false;
    public float invincibleTimeAfterHurt = 2f;
    private GameObject healthbar;
    HealthBarPJ barravida;
    

    private AnimController anim;
    private void Start()
    {
        healthbar = GameObject.FindGameObjectWithTag("HpYilda");
        barravida = healthbar.GetComponent<HealthBarPJ>();
        
    }
    public void DamagePlayer(float damage)
    {
        barravida.Taking(damage);
        if (inmortal) return;
        health -= damage;
        StartCoroutine(TiempoInmortal());
        
      
    }
    public void Curar (float vida)
    {
        health += vida;
    }
    void Die()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        if (health > maxHp)
            health = maxHp;
        if (health <= 0)
            Die();
        //BarraUI
        
    }
    IEnumerator TiempoInmortal()
    {
        inmortal = true;
        yield return new WaitForSeconds(invincibleTimeAfterHurt);
        inmortal = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        EnemyDongus enemy1 = collision.collider.GetComponent<EnemyDongus>();

        if (enemy1 != null)
        {
            DamagePlayer(enemy1.enemyDamage);
            
        }
    }



}
