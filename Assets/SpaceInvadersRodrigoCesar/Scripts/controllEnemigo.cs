using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controllEnemigo : MonoBehaviour
{
    private Transform enemyHolder;
    public float speed;
    public GameObject shot;
    public GameObject shot1;
    public GameObject shot2;
    public Text winText;
    public float Cdisparo = 0.997f;
    void Start()
    {
        winText.enabled = false;
        InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
        enemyHolder = GetComponent<Transform>();

    }
    void MoveEnemy()

    {
        enemyHolder.position += Vector3.right * speed;
        foreach(Transform enemy in enemyHolder)
        {
            if (enemy.position.x< -70 || enemy.position.x > 70)
            {
                speed = -speed;
                enemyHolder.position += Vector3.down * 0.5f;
                return;
            }
            if (enemy.position.y<= -10)
            {
                GameOver.isPlayerDead = true;
                Time.timeScale = 0;
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

        //Movimiento pausado de los enemigos
    }
}
