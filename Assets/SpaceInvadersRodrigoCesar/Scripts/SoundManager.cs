using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Sostiene la instancia individual del SoundManager que 
    // puede acceder de cualquier script
    public static SoundManager Instance = null;

    // Todos los efectos de sonidos en el juego
    // Todos  publicos para prepararlos en el inspector

    public AudioClip alienBuzz1;
    public AudioClip alienBuzz2;
    public AudioClip alienDies;
    public AudioClip bulletFire;
    public AudioClip shipExplosion;

    private AudioSource soundEffectAudio;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        AudioSource theSource = GetComponent<AudioSource>();
        soundEffectAudio = theSource;
    }
    // otros GameObjects pueden llamar para reproducir estos sonidos
    
    public void PlayOneShot(AudioClip clip)
    {
        soundEffectAudio.PlayOneShot(clip);
    }


}
