using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUps : MonoBehaviour
{   
    PlayerBasicAttacks scriptAttack;

    public GameObject PowerBullet;
    public AudioClip PowershotLaunch;
    AudioSource AS;

    [Header ("Rafaga")]
    public float RafagaDuracion;
    void Start()
    {
        scriptAttack = GetComponent<PlayerBasicAttacks>();
        AS = GetComponent<AudioSource>();
    }

 
    void Update()
    {   //Activa la Rafaga con la flecha
        if (Input.GetKeyDown(KeyCode.Q)|| Input.GetKeyDown(KeyCode.F))
        {            
            if (GameManager.Rafaga > 0)
            {
                GameManager.Rafaga -= 1;
                StartCoroutine("Rafaga");
            }
        }

        //Activa el PowerShot
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (GameManager.PowerShot > 0)
            {
                GameManager.PowerShot -= 1;
              PowerShot();
            }
        }

       
    }

    IEnumerator Rafaga()
    {
        scriptAttack.shotRate = 0.2f;
        yield return new WaitForSeconds(RafagaDuracion);
        scriptAttack.shotRate = 1f;
    }

    void PowerShot()
    {
        AS.PlayOneShot(PowershotLaunch, 0.2f);
        Instantiate(PowerBullet, transform.position, transform.rotation);
    }
}
