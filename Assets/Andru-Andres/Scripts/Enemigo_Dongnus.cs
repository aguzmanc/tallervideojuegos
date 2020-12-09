using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_Dongnus : MonoBehaviour
{
    //variable para la vision velocidad
    public float speed;
    public float vidionRadio;
    GameObject player; //para guardar jugador
    GameObject tower;
    Vector3 initialposition;//posicion inicial
    public float ataque = 30;
    public GameObject prefabLuz;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        tower = GameObject.FindGameObjectWithTag("Towers");
        initialposition = transform.position;
     
    }

    void FixedUpdate()
    {


        float variacionAtaque = Random.Range(0, 1);



        if (variacionAtaque ==1)
        {
            Vector3 target = initialposition;

            float dist = Vector3.Distance(player.transform.position, transform.position);
            if (dist < vidionRadio) target = player.transform.position;

            float fixedSpeed = speed * Time.deltaTime;
            // transform.position =;
            GetComponent<Rigidbody>().MovePosition(Vector3.MoveTowards(transform.position, target, fixedSpeed));

            Debug.DrawLine(transform.position, target, Color.green);
        }
        else if(variacionAtaque==0)
        {
            Vector3 target = initialposition;

            float dist = Vector3.Distance(tower.transform.position, transform.position);
            if (dist < vidionRadio) target = tower.transform.position;

            float fixedSpeed = speed * Time.deltaTime;
            //transform.position = ;
            GetComponent<Rigidbody>().MovePosition(Vector3.MoveTowards(transform.position, target, fixedSpeed));
            Debug.DrawLine(transform.position, target, Color.green);
        }

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, vidionRadio);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject)
        {
            generaPowerUp();

        }
    }
    void generaPowerUp()
    {
     float PowerUp =Random.Range(0, 2);
        if(PowerUp ==0)
        {
            Instantiate(prefabLuz, transform.position.normalized, prefabLuz.transform.rotation);
        }

    }
}
