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
    GameObject tower1;
    GameObject tower2;
    Vector3 initialposition;//posicion inicial
    public float ataque = 30;
    public GameObject prefabLuz;
    private bool juegoActivo;
    int variacionAtaque; 
    void Start()
    {
        variacionAtaque = Random.Range(0, 4);
        player = GameObject.FindGameObjectWithTag("Player");
        tower = GameObject.FindGameObjectWithTag("Towers");
        tower1 = GameObject.FindGameObjectWithTag("Towers1");
        tower2 = GameObject.FindGameObjectWithTag("Castle");
        initialposition = transform.position;
      
    }


    void FixedUpdate()
    {
        Vector3 target = initialposition;
        Debug.Log("num " + variacionAtaque);

        if (variacionAtaque == 0)
        {
           // Vector3 target = initialposition;

            float dist = Vector3.Distance(player.transform.position, transform.position);
            if (dist < vidionRadio) target = player.transform.position;

            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
           // GetComponent<Rigidbody>().MovePosition(Vector3.MoveTowards(transform.position, target, fixedSpeed));

            Debug.DrawLine(transform.position, target, Color.green);
        }
        
        
            if (variacionAtaque == 1)
            {
                //Vector3 target = initialposition;

                float dist = Vector3.Distance(tower.transform.position, transform.position);
                if (dist < vidionRadio) target = tower.transform.position;

                float fixedSpeed = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
                //GetComponent<Rigidbody>().MovePosition(Vector3.MoveTowards(transform.position, target, fixedSpeed));
                Debug.DrawLine(transform.position, target, Color.green);
            }
            if (variacionAtaque == 2)
            {
                //Vector3 target = initialposition;

                float dist = Vector3.Distance(tower1.transform.position, transform.position);
                if (dist < vidionRadio) target = tower1.transform.position;

                float fixedSpeed = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
                // GetComponent<Rigidbody>().MovePosition(Vector3.MoveTowards(transform.position, target, fixedSpeed));
                Debug.DrawLine(transform.position, target, Color.green);
            }
            if (variacionAtaque == 3)
            {
              

                float dist = Vector3.Distance(tower2.transform.position, transform.position);
                if (dist < vidionRadio) target = tower2.transform.position;

                float fixedSpeed = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
                //GetComponent<Rigidbody>().MovePosition(Vector3.MoveTowards(transform.position, target, fixedSpeed));
                Debug.DrawLine(transform.position, target, Color.green);
            }
        

    }
    //IEnumerator generaObjetivo()
   // {
       // while(juegoActivo)
       // {
           // yield return new WaitForSeconds(variacionAtaque);

        //}
    //}
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, vidionRadio);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("flecha"))
        {
            generaPowerUp();

        }
    }
    void generaPowerUp()
    {
     float PowerUp =Random.Range(0, 2);
        if(PowerUp ==0)
        {
            Instantiate(prefabLuz,gameObject.transform.position, prefabLuz.transform.rotation);
        }

    }
}
