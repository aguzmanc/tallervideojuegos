using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPJ : MonoBehaviour
{
    public Image vida;
    
    float hp, maxHp = 100f;
    void Start()

    {
        hp = maxHp;
        
    }
    public void Taking (float amount)
    {
        hp = Mathf.Clamp(hp - amount, 0f, maxHp);
        vida.transform.localScale = new Vector2(hp / maxHp, 1);
    }
}
