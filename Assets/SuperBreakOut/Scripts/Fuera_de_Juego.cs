using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Fuera_de_Juego : MonoBehaviour
{
    private float cont = 0;
    public Text gameOver;
   public static int vidas = 3;

    public Text vi;
    public GameObject soundfin;
    public GameObject gameoverl;
    void Start()
    {
        gameOver = GetComponent<Text>();
       gameOver.enabled = true;
        vi = GetComponent<Text>();
     
    }
     void Update()
    {

        vi.text = " " + (vidas - cont);
        if (Input.GetKeyDown(KeyCode.R))
        {

            SceneManager.LoadScene("Super");
            vi.text = " " + vidas;
            cont = 0;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //FindObjectOfType<Bola>().Reset();
        //FindObjectOfType<Pad>().Reset();
        cont++;
        Debug.Log("conta "+cont);
        Debug.Log(vidas);
        if (cont == vidas)
        {
            Instantiate(soundfin);

            Time.timeScale = 0;
            //gameOver.enabled = false;
        
            vi.text = cont.ToString();
            gameoverl.SetActive(true);
            
        }
        else
        {
            FindObjectOfType<Bola>().Reset();
            FindObjectOfType<Pad>().Reset();
        }
    }
}

