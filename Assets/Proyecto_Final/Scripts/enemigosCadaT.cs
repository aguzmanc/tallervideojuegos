using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigosCadaT : MonoBehaviour
{
    public Transform prefab, player;
    public float minRadio = 5f;
    public float maxRadio = 10f;
    
    public bool stopEnemies = false;
    public float segundos = 1;

    
    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        if(!stopEnemies){
        StartCoroutine(ExampleCoroutine());
        }
    }

    IEnumerator ExampleCoroutine()
    {

        while (!stopEnemies)
        {
            //Print the time of when the function is first called.
            Debug.Log("Started Coroutine at timestamp : " + Time.time);
            //isntanciar enemigos
            //float angle = Mathf.Round(Time.time) * Mathf.PI * 2f / (Mathf.Round(Time.time)+10);
            float rangoRadio = Random.Range(minRadio, maxRadio);
            Vector2 newPos = new Vector2((Mathf.Cos(Random.Range(-360,360)) * rangoRadio) + player.position.x, (Mathf.Sin(Random.Range(-360,360)) * rangoRadio) + player.position.y);
            Debug.Log(newPos);
            //GameObject go = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), newPos, Quaternion.identity);

            Instantiate(prefab, newPos, Quaternion.identity);

            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(segundos);
        }



        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    

}
