using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    public AudioClip patada;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) 
        { 
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().PlayOneShot(patada);
            StartCoroutine("Reinicia");
        }
    }

   IEnumerator Reinicia()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Principal");

    }
}
