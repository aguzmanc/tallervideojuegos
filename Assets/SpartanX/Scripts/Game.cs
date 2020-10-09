using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Game : MonoBehaviour
{
    public float health = 1;
    public GameObject HealthBar;
    void Start()
    {
        
    }

   
    void Update()
    {
        if (health > 0)
        {
            HealthBar.transform.localScale = new Vector3(health, 1, 1);
        }
        
    }
}
