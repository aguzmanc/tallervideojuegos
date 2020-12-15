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
    public bool enRfaga;
    public float contRafaga;
    public bool disparoNormal = true;
    public bool shootPower;
   
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
            if(Input.GetKey(KeyCode.R) && rafTiempo >5)
            {
               
                t = 0.3f;
               
            }
           



        }


       
        



     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Rafaga")
        {
            rafTiempo = 0;

            contRafaga += 1;
            enRfaga = true;
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

    

   



}
