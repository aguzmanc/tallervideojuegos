using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    private Transform enemyHolder;
    public float speed;

    public GameObject proyectilEnemigo;
    public Text winText;
    public float fireRate = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        winText.enabled = false;
        InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
        enemyHolder = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        Instantiate(proyectilEnemigo, transform.position, Quaternion.identity);
    }
    // Update is called once per frame
    void MoveEnemy()
    {
        enemyHolder.position += Vector3.right * speed;

        foreach (Transform Enemigo in enemyHolder)
        {
            if (Enemigo.position.x < -10.5 || Enemigo.position.x > 10.5)
            {
                speed = -speed;
                enemyHolder.position += Vector3.down * 0.5f;
                return;
            }

            if (Random.value > fireRate)
            {
                Instantiate(proyectilEnemigo, Enemigo.position, Enemigo.rotation);
            }

            if (Enemigo.position.y <= -4)
            {
                GameOver.isPlayerDead = true;
                Time.timeScale = 0;
            }
        }

        if (enemyHolder.childCount == 1)
        {
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.1f, 0.25f);
        }

        if (enemyHolder.childCount == 0)
        {
            winText.enabled = true;
        }
    }
}
