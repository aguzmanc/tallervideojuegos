using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosdelJugador : MonoBehaviour
{
    AudioSource AS;
    public AudioClip golpe;
    public AudioClip patada;
    public AudioClip muerte;

    void Start()
    {
        AS = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            AS.PlayOneShot(golpe);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            AS.PlayOneShot(patada);
        }
    }
}
