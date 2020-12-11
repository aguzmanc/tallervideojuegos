using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public float health = 100;

    public Image bar;

    private void Start()
    {
        //player = GameObject.FindWithTag("Player").GetComponent<PlayerHP>();
    }

    void Update()
    {
        health = GetComponent<EnemyDongus>().health;
        health = Mathf.Clamp(health, 0, 100);
        bar.fillAmount = health / 100;
    }
}
