using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PantallaInicio : MonoBehaviour
{
   
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void GameStart()
    {
        SceneManager.LoadScene("Principal");
    }
}
