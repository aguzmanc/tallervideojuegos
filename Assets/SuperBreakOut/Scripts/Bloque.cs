using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque : MonoBehaviour
{
    public GameObject soundDestroy;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(soundDestroy);   
        gameObject.SetActive(false); 
    }
    public void Reset()
    {
        gameObject.SetActive(true);
    }

}
