using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Reset : MonoBehaviour
{
    public gameOver GameOverbase;
    
    void Start()
    {
        GameOverbase = GameObject.Find("Jugador").GetComponent<gameOver>(); 
    }

  
    void Update()
    {
        if(GameOverbase.ResetBase==true && Input.GetKey(KeyCode.F))
        {
            SceneManager.LoadScene(0);
        }
    }
}
