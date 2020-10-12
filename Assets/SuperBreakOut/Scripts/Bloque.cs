using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bloque : MonoBehaviour
{
    int contadorsimple=0;
    public Text pts;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        contadorsimple++;
        pts.text = contadorsimple.ToString();
    }

}
