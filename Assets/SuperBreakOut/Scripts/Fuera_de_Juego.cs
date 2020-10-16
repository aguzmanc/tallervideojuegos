using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Fuera_de_Juego : MonoBehaviour
{
    private float cont = 0;
    public Text gameOver;
    private float vidas = 3;
    public static bool isPlayerDead = false;
    public Text vi;

    void Start()
    {
        gameOver = GetComponent<Text>();
        gameOver.enabled = false;
        vi = GetComponent<Text>();
        vi.text = " "+vidas;
    }
    private void Update()
    {

        vi.text = " " + (vidas-cont);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<Bola>().Reset();
        FindObjectOfType<Pad>().Reset();
        cont++;
        if (cont == vidas)
        {
            Time.timeScale = 0;
            gameOver.enabled = true;
            vi.text = cont.ToString();
        }
    }
}

