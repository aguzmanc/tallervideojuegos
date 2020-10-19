using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bloque : MonoBehaviour
{
  static int contadorsimple=0;
    private  Text pts;
    public GameObject soundDestroy;
    public GameObject textwin;
    public GameObject winsound;
    private void Start()
    {
        pts = GameObject.FindGameObjectWithTag("puntos").GetComponent<Text>();
    }
    void Update()
    {
        if (contadorsimple == 210)
        {
            textwin.SetActive(true);
            Instantiate(winsound);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(soundDestroy);
        StartCoroutine(Corutina());
        if (collision.otherCollider.tag == "uno")
        {
            contadorsimple++;
        }
        if (collision.otherCollider.tag == "dos")
        {
            contadorsimple += 2;
        }
        if (collision.otherCollider.tag == "tres")
        {
            contadorsimple += 3;
        }
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
