using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static bool isPlayerDead = false;
    private Text Gameover;

    // Start is called before the first frame update
    void Start()
    {
        Gameover = GetComponent<Text>();
        Gameover.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerDead)
        {
            Time.timeScale = 0;
            Gameover.enabled = true;
        }
    }
}
