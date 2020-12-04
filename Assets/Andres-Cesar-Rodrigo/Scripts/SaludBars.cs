using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaludBars : MonoBehaviour
{
    public float maxHealth = 100f;
    float curHealth;
    public Image heatlBar;
    Animator myAnim;
    void Start()
    {
        myAnim = GetComponent<Animator>();
        curHealth = maxHealth;
        heatlBar.fillAmount = curHealth / maxHealth;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("bullet"))
        {
            //curHealth -= collision.GetComponent<>().damageValue;
            heatlBar.fillAmount = curHealth / maxHealth;
            if ( curHealth<=0)
            {
                myAnim.SetBool("dead", true);
            }
        }
    }
}
