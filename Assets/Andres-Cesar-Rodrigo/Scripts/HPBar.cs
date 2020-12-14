using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public float health = 100;
    public GameObject dongusPrefab;
    public GameObject playerPrefab;
    public Image bar;

    private void Start()
    {
        //player = GameObject.FindWithTag("Player").GetComponent<PlayerHP>();
    }

    void Update()
    {
        if (dongusPrefab)
        {
            health = GetComponent<EnemyDongus>().health;
        }

        if (playerPrefab)
        {
            health = GetComponent<PlayerHP>().health;
        }
        health = Mathf.Clamp(health, 0, 100);
        bar.fillAmount = health / 100;
    }
}
