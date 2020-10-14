using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bloque : MonoBehaviour
{
  static int contadorsimple=0;
    public Text pts;
    public GameObject soundDestroy;
    private void Start()
    {
        pts = GameObject.FindGameObjectWithTag("puntos").GetComponent<Text>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(soundDestroy);
        StartCoroutine(Corutina());
        contadorsimple++;
        pts.text = contadorsimple.ToString();
    }
    IEnumerator Corutina()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
    } 

    public void Reset()
    {
        gameObject.SetActive(true);
    }
  

}
