using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigoAtaca : MonoBehaviour
{
    //public 
    Transform player;
    Vector2 positionPlayer;
    public float velocidad=0.005f;

    void Start()
    {
        //solo busca por nombre de GameObject
        //player = GameObject.Find("Player").transform;
        player = GameObject.FindWithTag("Player").transform;
        positionPlayer = new Vector2(player.position.x,player.position.y);       
    }


    void Update(){
        positionPlayer = new Vector2(player.position.x,player.position.y);
        transform.position = Vector2.Lerp(transform.position, positionPlayer,velocidad);
    }
    
}
