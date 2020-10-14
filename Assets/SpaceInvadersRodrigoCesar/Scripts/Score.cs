using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static float scoreTabla = 0;
    private Text scoreText;
   
    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    
    void Update()
    {
        scoreText.text = "Score: " + scoreTabla;
    }
}
