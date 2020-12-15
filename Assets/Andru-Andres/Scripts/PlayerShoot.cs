using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
   
    public GameObject Bala;
    public GameObject powerShoot;
    public Transform instanciador;
    public float tiemp;
    public float t ;
    public float rafTiempo;
    public int contadorPowerShoot;
    public bool enRfaga;
    public float contRafaga;
    public bool disparoNormal = true;
    public bool shootPower;
    public bool tiempoDeRafaga;
   
    void Start()
    {
        
    }

    
    void Update()
    {
        tiemp += Time.deltaTime ;
        rafTiempo += Time.deltaTime;
        if(disparoNormal ==true)
        {
            if (Input.GetKey(KeyCode.Mouse0) && tiemp > t)
            {
                DisparoNormal();
                tiemp = 0;
            }
        }

        if(enRfaga==true)
        {
            if(Input.GetKey(KeyCode.R))
            {
                rafTiempo = 0;
                t = 0.3f;
                tiempoDeRafaga = true;
            }

            if (tiempoDeRafaga == true) 
            {
                if(rafTiempo >3)
                {
                    t = 0.7f;
                    enRfaga = false;
                    tiempoDeRafaga = false;
                }

            }

        }

        if(shootPower ==true)
        {
            if(Input.GetKey(KeyCode.E))
            {
                PowerShoot();
            }
        }
       
        



     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Rafaga")
        {
            enRfaga = true;
            contRafaga += 1;
            Destroy(other.gameObject);
        }




        if (other.tag =="powerShoot")
        {
            disparoNormal = false;
            shootPower = true;
            Destroy(other.gameObject);
        }




    }


    void DisparoNormal()
    {
        SoundSystem.instance.PlayFlecha();
        Instantiate(Bala, instanciador.position, instanciador.rotation);
    }


    void PowerShoot()
    {
        Instantiate(powerShoot, instanciador.position, instanciador.transform.rotation);
        contadorPowerShoot += 1;
        if (contadorPowerShoot > 0)
        {
            shootPower = false;
            disparoNormal = true;
        }
    }






}
