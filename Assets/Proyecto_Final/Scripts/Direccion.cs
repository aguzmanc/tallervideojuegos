using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direccion : MonoBehaviour {

    public Transform ObjectToFollow = null;
    public float Speed = 2;

    void Awake()
    {

        ObjectToFollow = GameObject.FindGameObjectWithTag ("Player").transform ;

    }


    void Update()
    {
        if(ObjectToFollow == null)
        return;

        //Vector3 DirectionToFollow = ObjectToFollow.position - transform.position;

       //ransform.position = Vector3.MoveTowards(transform.position,ObjectToFollow.transform.position,Speed * Time.deltaTime);
        //transform.up = ObjectToFollow.position - transform.position;

        transform.LookAt(ObjectToFollow.transform);
        transform.Translate(0,0, Speed * Time.deltaTime);
        
    }
}