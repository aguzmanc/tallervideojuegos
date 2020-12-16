﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUps : MonoBehaviour
{   
    PlayerBasicAttacks scriptAttack;

    [Header ("Rafaga")]
    public float RafagaDuracion;
    void Start()
    {
        scriptAttack = GetComponent<PlayerBasicAttacks>();
    }

 
    void Update()
    {   //Activa la Rafaga con la flecha
        if (Input.GetKeyDown(KeyCode.Q)|| Input.GetKeyDown(KeyCode.F))
        {            
            if (GameManager.Rafaga > 0)
            {
                GameManager.Rafaga -= 1;
                StartCoroutine("Rafaga");
            }
        }
    }

    IEnumerator Rafaga()
    {
        scriptAttack.shotRate = 0.2f;
        yield return new WaitForSeconds(RafagaDuracion);
        scriptAttack.shotRate = 1f;
    }
}
