using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoActive : MonoBehaviour
{
    public float cooldownEscudo;
    void Start()
    {
        
    }
     void OnEnable()
    {
        cooldownEscudo = 0;
    }

    void Update()
    {
        cooldownEscudo += Time.deltaTime;

    if(cooldownEscudo>1.2)
        {
            gameObject.SetActive(false);
        }
    }
}
