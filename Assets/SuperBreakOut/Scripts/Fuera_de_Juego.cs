using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Fuera_de_Juego : MonoBehaviour
{
    private float cont = 3;
   public static int vidas = 0;

    public Text textovidas;
    public GameObject soundfin;
    public GameObject gameoverl;
    void Start()
    {
        textovidas = GetComponent<Text>();
       // textovidas.text = cont.ToString();
    }
     void Update()
    {
   
        //reset escena 
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Super");
          
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        cont = cont -1;
         textovidas.text = cont.ToString();
   
        if (cont == vidas)
        {
            gameoverl.SetActive(true);
            Instantiate(soundfin);
            Destroy(FindObjectOfType<Bola>().gameObject);
            Destroy(FindObjectOfType<Pad>().gameObject);
        }
        else
        {
            FindObjectOfType<Bola>().Reset();
            FindObjectOfType<Pad>().Reset();
        }
    }
}

